using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyClassLybrary
{
    public static class SiveOfEratosthenes
    {
        public static List<uint> GeneratePrimeNumbers(long upperBound)
        {
            //bool[] isPrime = new bool[upperBound + 1];
            List<bool> isPrime = new List<bool> { false, false };
            for (uint i = 2; i <= upperBound; i++)
            {
                //isPrime[i] = true;
                isPrime.Add(true);
            }

            List<uint> primeNumbers = new List<uint>();
            for (uint i = 2; i <= upperBound; i++)
            {
                if (isPrime[(int)i])
                {
                    primeNumbers.Add(i);
                    if (i*i <= upperBound)
                    {
                        for (uint j = i*i; j <= upperBound; j += i)
                        {
                            isPrime[(int)j] = false;
                        }
                    }
                }
            }
            return primeNumbers;
        }
    }
    public static class RSAEncryptor
    {
        /*private static bool IsCoPrime(ulong number0, ulong number1)
        {
            if (number0 == number1)
            {
                return number0 == 1;
            }
            else
            {
                if (number0 > number1)
                {
                    return IsCoPrime(number0 - number1, number1);
                }
                else
                {
                    return IsCoPrime(number1 - number0, number0);
                }
            }
        }*/

        private static ulong GetMultiplicativeInversion(ulong number, ulong module)
        {
            ulong r1 = module;
            ulong r2 = number;
            long t1 = 0;
            long t2 = 1;
            while (r2 != 0)
            {
                long q = (long)(r1 / r2);
                ulong r = (ushort)(r1 - (ulong)q * r2);
                long t = (long)(t1 - q * t2);
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            ulong multiplicativeInversion = 0;
            if (t1 < 0)
            {
                multiplicativeInversion = (ulong)((long)module + t1);
            }
            else
            {
                multiplicativeInversion = (ulong)(t1 % (long)module);
            }
            return multiplicativeInversion;
        }

        private static uint GetModularExponentiation(uint number, ulong exponent, ulong module)
        {
            ulong result = 1;
            ulong subExponent = 0;
            while (subExponent != exponent)
            {
                subExponent++;
                result = ((number * result) % module);
            }
            return (uint)result;
        }

        public static void GenerateKeys(ref ulong publicExponent, ref ulong secreteExponent, ref ulong modulus)
        {
            //List<uint> tempPrimalNumbers = SiveOfEratosthenes.GeneratePrimeNumbers(1048576);
            List<uint> tempPrimalNumbers = SiveOfEratosthenes.GeneratePrimeNumbers(512);
            List<uint> primalNumbersPool = new List<uint>();
            for (int i = 0; i < tempPrimalNumbers.Count; i++)
            {
                if (tempPrimalNumbers[i] >= 256)
                {
                    primalNumbersPool.AddRange(tempPrimalNumbers.GetRange(i, tempPrimalNumbers.Count - i));
                    break;
                }
            }

            Random randomGenerator = new Random();
            int firsPrimalNumber = randomGenerator.Next(primalNumbersPool.Count - 1);
            int secondPrimalNumber = randomGenerator.Next(primalNumbersPool.Count - 1);
            while (firsPrimalNumber == secondPrimalNumber)
            {
                secondPrimalNumber = randomGenerator.Next(primalNumbersPool.Count - 1);
            }
            uint firstPrimal = primalNumbersPool[firsPrimalNumber];
            uint secondPrimal = primalNumbersPool[secondPrimalNumber];

            modulus = (ulong)firstPrimal * (ulong)secondPrimal;
            ulong eulerFunctionValue = (firstPrimal - 1) * (secondPrimal - 1);
            int tempNumber = randomGenerator.Next(primalNumbersPool.Count - 1);
            while (!(primalNumbersPool[tempNumber] < eulerFunctionValue && eulerFunctionValue < primalNumbersPool[tempNumber] * primalNumbersPool[tempNumber]))
            {

                tempNumber = randomGenerator.Next(primalNumbersPool.Count - 1);
            }

            publicExponent = primalNumbersPool[tempNumber];
            secreteExponent = GetMultiplicativeInversion(publicExponent, eulerFunctionValue);
        }

        public static Tuple<string, string> RSAEncryption(string message, ulong publicExponent, ulong modulus)
        {
            Random randomGenerator = new Random();

            string sessionKey = "";
            for (int i = 0; i < 16; i++)
            {
                sessionKey += Convert.ToChar(randomGenerator.Next(255));
            }

            List<byte> sessionKeyByteCode = new List<byte>();
            for (int i = 0; i < sessionKey.Length; i++)
            {
                sessionKeyByteCode.Add((byte)sessionKey[i]);
            }
            List<ushort> sessionKeyWordCode = new List<ushort>();
            for (int i = 0; i < sessionKeyByteCode.Count; i += 2)
            {
                ushort temp = 0;
                temp += (ushort)(sessionKeyByteCode[i + 0] << 8);
                temp += (ushort)(sessionKeyByteCode[i + 1] << 0);
                sessionKeyWordCode.Add(temp);
            }

            List<uint> encryptedKeyCode = new List<uint>();
            for (int i = 0; i < sessionKeyWordCode.Count; i++)
            {
                encryptedKeyCode.Add(GetModularExponentiation((uint)sessionKeyWordCode[i], publicExponent, modulus));
            }

            string encryptedKey = "";
            for (int i = 0; i < encryptedKeyCode.Count; i++)
            {
                string tempString = Convert.ToString(encryptedKeyCode[i], 16);
                while (tempString.Length < 6)
                {
                    tempString = 0 + tempString;
                }
                encryptedKey += tempString;
            }

            string encryptedMessage = IDEAEncryptor.IDEAEncryption(message, sessionKey);

            return new Tuple<string, string> (encryptedKey, encryptedMessage);
        }

        public static string RSADecryption(Tuple<string, string> encryptedPair, ulong secreteExponent, ulong modulus)
        {
            string encryptedSessionKey = encryptedPair.Item1;
            string encryptedMessage = encryptedPair.Item2;

            List<uint> sessionKeyWordCode = new List<uint>();
            for (int i = 0; i < encryptedSessionKey.Length; i += 6)
            {
                sessionKeyWordCode.Add(Convert.ToUInt32(encryptedSessionKey.Substring(i, 6), 16));
            }
            List<byte> sessionKeyByteCode = new List<byte>();
            for (int i = 0; i < sessionKeyWordCode.Count; i++)
            {
                sessionKeyWordCode[i] = GetModularExponentiation(sessionKeyWordCode[i], secreteExponent, modulus);
                sessionKeyByteCode.Add((byte)((ushort)sessionKeyWordCode[i] >> 8));
                sessionKeyByteCode.Add((byte)((ushort)sessionKeyWordCode[i] >> 0));
            }
            string sessionKey = "";
            for (int i = 0; i < sessionKeyByteCode.Count; i++)
            {
                sessionKey += Convert.ToChar(sessionKeyByteCode[i]);
            }

            string decryptedMessage = IDEAEncryptor.IDEADecryption(encryptedMessage, sessionKey);
            return decryptedMessage;
        }
    }
}
