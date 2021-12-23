using System;
using System.Collections.Generic;

namespace CryptographyClassLybrary
{
    public static class IDEAEncryptor
    {
        private static string cycleShiftStringLeft(string sentence, int shiftsAmount)
        {
            for (int i = 0; i < shiftsAmount; i++)
            {
                string tempSentence = sentence.Substring(1, sentence.Length - 1);
                tempSentence += sentence[0];
                sentence = tempSentence;
            }
            return sentence;
        }

        private static ushort MultiplicationByModulus(ushort multiplier1, ushort multiplier2, int modulus)
        {
            long mul1 = multiplier1;
            if (multiplier1 == 0)
            {
                mul1 = (long)Math.Pow(2, 16);
            }
            long mul2 = multiplier2;
            if (multiplier2 == 0)
            {
                mul2 = (long)Math.Pow(2, 16);
            }
            long multiplicationResult = mul1 * mul2;
            int result = (int)(multiplicationResult % modulus);
            return (ushort)result;
        }

        private static ushort AdditionByModulus(ushort summand1, ushort summand2, int modulus)
        {
            long additionResult = (long)summand1 + (long)summand2;
            int result = (int)(additionResult % modulus);
            return (ushort)result;
        }

        private static ushort GetMultiplicativeInversion(ushort number, int module)
        {
            int r1 = module;
            ushort r2 = number;
            short t1 = 0;
            short t2 = 1;
            while (r2 != 0)
            {
                int q = r1 / r2;
                ushort r = (ushort)(r1 - q * r2);
                short t = (short)(t1 - q * t2);
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            ushort multiplicativeInversion = 0;
            if (t1 < 0)
            {
                multiplicativeInversion = (ushort)(module + t1);
            }
            else
            {
                multiplicativeInversion = (ushort)(t1 % module);
            }
            return multiplicativeInversion;
        }

        private static ushort GetAdditiveInversion(ushort number, int module)
        {
            return (ushort)(module - number);
        }

        private static List<ushort> GenerateKeys(string keySentence)
        {
            List<ushort> subKeys = new List<ushort>();
            string mainKey = MD5Encryptor.MD5Encryption(keySentence);

            uint intA = Convert.ToUInt32(mainKey.Substring(0, 8), 16);
            uint intB = Convert.ToUInt32(mainKey.Substring(8, 8), 16);
            uint intC = Convert.ToUInt32(mainKey.Substring(16, 8), 16);
            uint intD = Convert.ToUInt32(mainKey.Substring(24, 8), 16);
            string outputA = Convert.ToString(intA, 2);
            while (outputA.Length < 32)
            {
                outputA = '0' + outputA;
            }
            string outputB = Convert.ToString(intB, 2);
            while (outputB.Length < 32)
            {
                outputB = '0' + outputB;
            }
            string outputC = Convert.ToString(intC, 2);
            while (outputC.Length < 32)
            {
                outputC = '0' + outputC;
            }
            string outputD = Convert.ToString(intD, 2);
            while (outputD.Length < 32)
            {
                outputD = '0' + outputD;
            }

            string bitMainKey = outputA + outputB + outputC + outputD;

            for (int c = 0; c < 6; c++)
            {
                for (int i = 0; i < 8; i++)
                {
                    ushort temp = Convert.ToUInt16(bitMainKey.Substring(i * 16, 16), 2);
                    subKeys.Add(temp);
                }

                bitMainKey = cycleShiftStringLeft(bitMainKey, 25);
            }
            for (int i = 0; i < 4; i++)
            {
                ushort temp = Convert.ToUInt16(bitMainKey.Substring(i * 16, 16), 2);
                subKeys.Add(temp);
            }

            return subKeys;
        }

        public static string IDEAEncryption(string message, string key)
        {
            List<ushort> subKeys = GenerateKeys(key);
            List<List<ushort>> roundKeys = new List<List<ushort>>();
            List<ushort> tempList = new List<ushort>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    tempList.Add(subKeys[i * 6 + j]);
                }
                roundKeys.Add(tempList);
                tempList = new List<ushort>();
            }
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(subKeys[48 + i]);
            }
            roundKeys.Add(tempList);
            tempList = new List<ushort>();

            List<byte> messageByteCode = new List<byte>();
            for (int i = 0; i < message.Length; i++)
            {
                messageByteCode.Add((byte)message[i]);
            }
            while (messageByteCode.Count % 8 != 0)
            {
                messageByteCode.Add(0);
            }

            List<List<ushort>> messageBloks = new List<List<ushort>>();
            List<ushort> subList = new List<ushort>();
            int subListCounter = 0;
            for (int i = 0; i < messageByteCode.Count; i += 2)
            {
                ushort temp = 0;
                temp += (ushort)(messageByteCode[i + 0] << 8);
                temp += (ushort)(messageByteCode[i + 1] << 0);

                subList.Add(temp);
                subListCounter++;
                if (subListCounter >= 4)
                {
                    subListCounter = 0;
                    messageBloks.Add(subList);
                    subList = new List<ushort>();
                }
            }

            int modulus = (int)Math.Pow(2, 16) + 1;
            for (int i = 0; i < messageBloks.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ushort A = MultiplicationByModulus(messageBloks[i][0], roundKeys[j][0], modulus);
                    ushort B = AdditionByModulus(messageBloks[i][1], roundKeys[j][1], modulus);
                    ushort C = AdditionByModulus(messageBloks[i][2], roundKeys[j][2], modulus);
                    ushort D = MultiplicationByModulus(messageBloks[i][3], roundKeys[j][3], modulus);
                    ushort E = (ushort)(A ^ C);
                    ushort F = (ushort)(B ^ D);

                    messageBloks[i][0] = (ushort)(A ^ MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundKeys[j][4], modulus), modulus), roundKeys[j][5], modulus));
                    messageBloks[i][1] = (ushort)(C ^ MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundKeys[j][4], modulus), modulus), roundKeys[j][5], modulus));
                    messageBloks[i][2] = (ushort)(B ^ AdditionByModulus(MultiplicationByModulus(E, roundKeys[j][4], modulus), MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundKeys[j][4], modulus), modulus), roundKeys[j][5], modulus), modulus));
                    messageBloks[i][3] = (ushort)(D ^ AdditionByModulus(MultiplicationByModulus(E, roundKeys[j][4], modulus), MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundKeys[j][4], modulus), modulus), roundKeys[j][5], modulus), modulus));
                }

                ushort temp0 = messageBloks[i][0];
                ushort temp1 = messageBloks[i][1];
                ushort temp2 = messageBloks[i][2];
                ushort temp3 = messageBloks[i][3];

                messageBloks[i][0] = MultiplicationByModulus(temp0, roundKeys[8][0], modulus);
                messageBloks[i][1] = AdditionByModulus(temp2, roundKeys[8][1], modulus);
                messageBloks[i][2] = AdditionByModulus(temp1, roundKeys[8][2], modulus);
                messageBloks[i][3] = MultiplicationByModulus(temp3, roundKeys[8][3], modulus);
            }

            List<byte> outputMessageByteCode = new List<byte>();
            for (int i = 0; i < messageBloks.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    byte temp0 = (byte)(messageBloks[i][j] >> 0);
                    byte temp1 = (byte)(messageBloks[i][j] >> 8);
                    outputMessageByteCode.Add(temp1);
                    outputMessageByteCode.Add(temp0);
                }
            }

            string output = "";
            for (int i = 0; i < outputMessageByteCode.Count; i++)
            {
                string temp = Convert.ToString(outputMessageByteCode[i], 16);
                if (temp.Length < 2)
                {
                    temp = 0 + temp;
                }
                output += temp;
            }
            return output;
        }

        public static string IDEADecryption(string message, string key)
        {
            List<ushort> subKeys = GenerateKeys(key);
            List<List<ushort>> roundKeys = new List<List<ushort>>();
            List<ushort> tempList = new List<ushort>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    tempList.Add(subKeys[i * 6 + j]);
                }
                roundKeys.Add(tempList);
                tempList = new List<ushort>();
            }
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(subKeys[48 + i]);
            }
            roundKeys.Add(tempList);
            tempList = new List<ushort>();

            int module = (int)Math.Pow(2, 16) + 1;
            List<List<ushort>> roundDecryptKeys = new List<List<ushort>>();
            tempList.Add(GetMultiplicativeInversion(roundKeys[8][0], module));
            tempList.Add(GetAdditiveInversion(roundKeys[8][1], module));
            tempList.Add(GetAdditiveInversion(roundKeys[8][2], module));
            tempList.Add(GetMultiplicativeInversion(roundKeys[8][3], module));
            tempList.Add(roundKeys[7][4]);
            tempList.Add(roundKeys[7][5]);
            roundDecryptKeys.Add(tempList);
            tempList = new List<ushort>();

            for (int i = 7; i > 0; i--)
            {
                tempList.Add(GetMultiplicativeInversion(roundKeys[i][0], module));
                tempList.Add(GetAdditiveInversion(roundKeys[i][2], module));
                tempList.Add(GetAdditiveInversion(roundKeys[i][1], module));
                tempList.Add(GetMultiplicativeInversion(roundKeys[i][3], module));
                tempList.Add(roundKeys[i - 1][4]);
                tempList.Add(roundKeys[i - 1][5]);
                roundDecryptKeys.Add(tempList);
                tempList = new List<ushort>();
            }

            tempList.Add(GetMultiplicativeInversion(roundKeys[0][0], module));
            tempList.Add(GetAdditiveInversion(roundKeys[0][1], module));
            tempList.Add(GetAdditiveInversion(roundKeys[0][2], module));
            tempList.Add(GetMultiplicativeInversion(roundKeys[0][3], module));
            roundDecryptKeys.Add(tempList);
            tempList = new List<ushort>();

            List<byte> messageByteCode = new List<byte>();
            for (int i = 0; i < message.Length; i += 2)
            {
                messageByteCode.Add(Convert.ToByte(message.Substring(i, 2), 16));
            }

            List<List<ushort>> messageBloks = new List<List<ushort>>();
            List<ushort> subList = new List<ushort>();
            int subListCounter = 0;
            for (int i = 0; i < messageByteCode.Count; i += 2)
            {
                ushort temp = 0;
                temp += (ushort)(messageByteCode[i + 0] << 8);
                temp += (ushort)(messageByteCode[i + 1] << 0);

                subList.Add(temp);
                subListCounter++;
                if (subListCounter >= 4)
                {
                    subListCounter = 0;
                    messageBloks.Add(subList);
                    subList = new List<ushort>();
                }
            }

            int modulus = (int)Math.Pow(2, 16) + 1;
            for (int i = 0; i < messageBloks.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ushort A = MultiplicationByModulus(messageBloks[i][0], roundDecryptKeys[j][0], modulus);
                    ushort B = AdditionByModulus(messageBloks[i][1], roundDecryptKeys[j][1], modulus);
                    ushort C = AdditionByModulus(messageBloks[i][2], roundDecryptKeys[j][2], modulus);
                    ushort D = MultiplicationByModulus(messageBloks[i][3], roundDecryptKeys[j][3], modulus);
                    ushort E = (ushort)(A ^ C);
                    ushort F = (ushort)(B ^ D);

                    messageBloks[i][0] = (ushort)(A ^ MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundDecryptKeys[j][4], modulus), modulus), roundDecryptKeys[j][5], modulus));
                    messageBloks[i][1] = (ushort)(C ^ MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundDecryptKeys[j][4], modulus), modulus), roundDecryptKeys[j][5], modulus));
                    messageBloks[i][2] = (ushort)(B ^ AdditionByModulus(MultiplicationByModulus(E, roundDecryptKeys[j][4], modulus), MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundDecryptKeys[j][4], modulus), modulus), roundDecryptKeys[j][5], modulus), modulus));
                    messageBloks[i][3] = (ushort)(D ^ AdditionByModulus(MultiplicationByModulus(E, roundDecryptKeys[j][4], modulus), MultiplicationByModulus(AdditionByModulus(F, MultiplicationByModulus(E, roundDecryptKeys[j][4], modulus), modulus), roundDecryptKeys[j][5], modulus), modulus));
                }

                ushort temp0 = messageBloks[i][0];
                ushort temp1 = messageBloks[i][1];
                ushort temp2 = messageBloks[i][2];
                ushort temp3 = messageBloks[i][3];

                messageBloks[i][0] = MultiplicationByModulus(temp0, roundDecryptKeys[8][0], modulus);
                messageBloks[i][1] = AdditionByModulus(temp2, roundDecryptKeys[8][1], modulus);
                messageBloks[i][2] = AdditionByModulus(temp1, roundDecryptKeys[8][2], modulus);
                messageBloks[i][3] = MultiplicationByModulus(temp3, roundDecryptKeys[8][3], modulus);
            }

            List<byte> outputMessageByteCode = new List<byte>();
            for (int i = 0; i < messageBloks.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    byte temp0 = (byte)(messageBloks[i][j] >> 0);
                    byte temp1 = (byte)(messageBloks[i][j] >> 8);
                    outputMessageByteCode.Add(temp1);
                    outputMessageByteCode.Add(temp0);
                }
            }

            string output = "";
            for (int i = 0; i < outputMessageByteCode.Count; i++)
            {
                output += Convert.ToChar(outputMessageByteCode[i]);
            }
            return output;
        }
    }
}
