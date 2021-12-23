using System;
using System.Collections.Generic;

namespace CryptographyClassLybrary
{
    public static class MD5Encryptor
    {
        private static uint F(uint X, uint Y, uint Z)
        {
            return (X & Y) | (~X & Y);
        }
        private static uint G(uint X, uint Y, uint Z)
        {
            return (X & Z) | (Y & ~Z);
        }
        private static uint H(uint X, uint Y, uint Z)
        {
            return X ^ Y ^ Z;
        }
        private static uint I(uint X, uint Y, uint Z)
        {
            return Y ^ (~Z | X);
        }

        private static uint cycleRotateLeft(uint X, int n)
        {
            return (X << n) | (X >> (32 - n));
        }

        public static string MD5Encryption(string message)
        {
            long messageLength = message.Length;
            List<byte> messageByteCode = new List<byte>();
            for (int i = 0; i < messageLength; i++)
            {
                messageByteCode.Add((byte)message[i]);
            }

            messageByteCode.Add(128);

            while (messageByteCode.Count % 64 != 56)
            {
                messageByteCode.Add(0);
            }

            byte[] messageLengthBytes;
            messageLengthBytes = BitConverter.GetBytes(messageLength);
            if (!BitConverter.IsLittleEndian)
            {
                messageLengthBytes = BigEndianToLittleEndianConverter.ConvertToLittleEndian(messageLengthBytes);
            }
            messageByteCode.AddRange(messageLengthBytes);

            UInt32 A = 0x67452301;
            UInt32 B = 0xEFCDAB89;
            UInt32 C = 0x98BADCFE;
            UInt32 D = 0x10325476;

            UInt32[] T = new UInt32[64];
            for (int i = 0; i < 64; i++)
            {
                T[i] = (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin((double)(i + 1))));
            }

            int doubleWordsBlocksAmount = messageByteCode.Count / 64;
            uint[,] doubleWordsBlocks = new uint[doubleWordsBlocksAmount, 16];
            int doubleWordsCounter = 0;
            int blocksCounter = 0;
            for (int i = 0; i < messageByteCode.Count; i += 4)
            {
                doubleWordsBlocks[blocksCounter, doubleWordsCounter] += ((uint)messageByteCode[i + 0]) << 0;
                doubleWordsBlocks[blocksCounter, doubleWordsCounter] += ((uint)messageByteCode[i + 1]) << 8;
                doubleWordsBlocks[blocksCounter, doubleWordsCounter] += ((uint)messageByteCode[i + 2]) << 16;
                doubleWordsBlocks[blocksCounter, doubleWordsCounter] += ((uint)messageByteCode[i + 3]) << 24;
                doubleWordsCounter++;
                if (doubleWordsCounter > 15)
                {
                    blocksCounter++;
                    doubleWordsCounter = 0;
                }
            }

            for (int i = 0; i < doubleWordsBlocksAmount; i++)
            {
                uint AA = A;
                uint BB = B;
                uint CC = C;
                uint DD = D;

                //round 1
                A = B + cycleRotateLeft((A + F(B, C, D) + doubleWordsBlocks[i, 0] + T[0]), 7);
                D = A + cycleRotateLeft((D + F(A, B, C) + doubleWordsBlocks[i, 1] + T[1]), 12);
                C = D + cycleRotateLeft((C + F(D, A, B) + doubleWordsBlocks[i, 2] + T[2]), 17);
                B = C + cycleRotateLeft((B + F(C, D, A) + doubleWordsBlocks[i, 3] + T[3]), 22);

                A = B + cycleRotateLeft((A + F(B, C, D) + doubleWordsBlocks[i, 4] + T[4]), 7);
                D = A + cycleRotateLeft((D + F(A, B, C) + doubleWordsBlocks[i, 5] + T[5]), 12);
                C = D + cycleRotateLeft((C + F(D, A, B) + doubleWordsBlocks[i, 6] + T[6]), 17);
                B = C + cycleRotateLeft((B + F(C, D, A) + doubleWordsBlocks[i, 7] + T[7]), 22);

                A = B + cycleRotateLeft((A + F(B, C, D) + doubleWordsBlocks[i, 8] + T[8]), 7);
                D = A + cycleRotateLeft((D + F(A, B, C) + doubleWordsBlocks[i, 9] + T[9]), 12);
                C = D + cycleRotateLeft((C + F(D, A, B) + doubleWordsBlocks[i, 10] + T[10]), 17);
                B = C + cycleRotateLeft((B + F(C, D, A) + doubleWordsBlocks[i, 11] + T[11]), 22);

                A = B + cycleRotateLeft((A + F(B, C, D) + doubleWordsBlocks[i, 12] + T[12]), 7);
                D = A + cycleRotateLeft((D + F(A, B, C) + doubleWordsBlocks[i, 13] + T[13]), 12);
                C = D + cycleRotateLeft((C + F(D, A, B) + doubleWordsBlocks[i, 14] + T[14]), 17);
                B = C + cycleRotateLeft((B + F(C, D, A) + doubleWordsBlocks[i, 15] + T[15]), 22);

                //round 2
                A = B + cycleRotateLeft((A + G(B, C, D) + doubleWordsBlocks[i, 1] + T[16]), 5);
                D = A + cycleRotateLeft((D + G(A, B, C) + doubleWordsBlocks[i, 6] + T[17]), 9);
                C = D + cycleRotateLeft((C + G(D, A, B) + doubleWordsBlocks[i, 11] + T[18]), 14);
                B = C + cycleRotateLeft((B + G(C, D, A) + doubleWordsBlocks[i, 0] + T[19]), 20);

                A = B + cycleRotateLeft((A + G(B, C, D) + doubleWordsBlocks[i, 5] + T[20]), 5);
                D = A + cycleRotateLeft((D + G(A, B, C) + doubleWordsBlocks[i, 10] + T[21]), 9);
                C = D + cycleRotateLeft((C + G(D, A, B) + doubleWordsBlocks[i, 15] + T[22]), 14);
                B = C + cycleRotateLeft((B + G(C, D, A) + doubleWordsBlocks[i, 4] + T[23]), 20);

                A = B + cycleRotateLeft((A + G(B, C, D) + doubleWordsBlocks[i, 9] + T[24]), 5);
                D = A + cycleRotateLeft((D + G(A, B, C) + doubleWordsBlocks[i, 14] + T[25]), 9);
                C = D + cycleRotateLeft((C + G(D, A, B) + doubleWordsBlocks[i, 3] + T[26]), 14);
                B = C + cycleRotateLeft((B + G(C, D, A) + doubleWordsBlocks[i, 8] + T[27]), 20);

                A = B + cycleRotateLeft((A + G(B, C, D) + doubleWordsBlocks[i, 13] + T[28]), 5);
                D = A + cycleRotateLeft((D + G(A, B, C) + doubleWordsBlocks[i, 2] + T[29]), 9);
                C = D + cycleRotateLeft((C + G(D, A, B) + doubleWordsBlocks[i, 7] + T[30]), 14);
                B = C + cycleRotateLeft((B + G(C, D, A) + doubleWordsBlocks[i, 12] + T[31]), 20);

                //round 3
                A = B + cycleRotateLeft((A + H(B, C, D) + doubleWordsBlocks[i, 5] + T[32]), 4);
                D = A + cycleRotateLeft((D + H(A, B, C) + doubleWordsBlocks[i, 8] + T[33]), 11);
                C = D + cycleRotateLeft((C + H(D, A, B) + doubleWordsBlocks[i, 11] + T[34]), 16);
                B = C + cycleRotateLeft((B + H(C, D, A) + doubleWordsBlocks[i, 14] + T[35]), 23);

                A = B + cycleRotateLeft((A + H(B, C, D) + doubleWordsBlocks[i, 1] + T[36]), 4);
                D = A + cycleRotateLeft((D + H(A, B, C) + doubleWordsBlocks[i, 4] + T[37]), 11);
                C = D + cycleRotateLeft((C + H(D, A, B) + doubleWordsBlocks[i, 7] + T[38]), 16);
                B = C + cycleRotateLeft((B + H(C, D, A) + doubleWordsBlocks[i, 10] + T[39]), 23);

                A = B + cycleRotateLeft((A + H(B, C, D) + doubleWordsBlocks[i, 13] + T[40]), 4);
                D = A + cycleRotateLeft((D + H(A, B, C) + doubleWordsBlocks[i, 0] + T[41]), 11);
                C = D + cycleRotateLeft((C + H(D, A, B) + doubleWordsBlocks[i, 3] + T[42]), 16);
                B = C + cycleRotateLeft((B + H(C, D, A) + doubleWordsBlocks[i, 6] + T[43]), 23);

                A = B + cycleRotateLeft((A + H(B, C, D) + doubleWordsBlocks[i, 9] + T[44]), 4);
                D = A + cycleRotateLeft((D + H(A, B, C) + doubleWordsBlocks[i, 12] + T[45]), 11);
                C = D + cycleRotateLeft((C + H(D, A, B) + doubleWordsBlocks[i, 15] + T[46]), 16);
                B = C + cycleRotateLeft((B + H(C, D, A) + doubleWordsBlocks[i, 2] + T[47]), 23);

                //round 4
                A = B + cycleRotateLeft((A + I(B, C, D) + doubleWordsBlocks[i, 0] + T[48]), 6);
                D = A + cycleRotateLeft((D + I(A, B, C) + doubleWordsBlocks[i, 7] + T[49]), 10);
                C = D + cycleRotateLeft((C + I(D, A, B) + doubleWordsBlocks[i, 14] + T[50]), 15);
                B = C + cycleRotateLeft((B + I(C, D, A) + doubleWordsBlocks[i, 5] + T[51]), 21);

                A = B + cycleRotateLeft((A + I(B, C, D) + doubleWordsBlocks[i, 12] + T[52]), 6);
                D = A + cycleRotateLeft((D + I(A, B, C) + doubleWordsBlocks[i, 3] + T[53]), 10);
                C = D + cycleRotateLeft((C + I(D, A, B) + doubleWordsBlocks[i, 10] + T[54]), 15);
                B = C + cycleRotateLeft((B + I(C, D, A) + doubleWordsBlocks[i, 1] + T[55]), 21);

                A = B + cycleRotateLeft((A + I(B, C, D) + doubleWordsBlocks[i, 8] + T[56]), 6);
                D = A + cycleRotateLeft((D + I(A, B, C) + doubleWordsBlocks[i, 15] + T[57]), 10);
                C = D + cycleRotateLeft((C + I(D, A, B) + doubleWordsBlocks[i, 6] + T[58]), 15);
                B = C + cycleRotateLeft((B + I(C, D, A) + doubleWordsBlocks[i, 13] + T[59]), 21);

                A = B + cycleRotateLeft((A + I(B, C, D) + doubleWordsBlocks[i, 4] + T[60]), 6);
                D = A + cycleRotateLeft((D + I(A, B, C) + doubleWordsBlocks[i, 11] + T[61]), 10);
                C = D + cycleRotateLeft((C + I(D, A, B) + doubleWordsBlocks[i, 2] + T[62]), 15);
                B = C + cycleRotateLeft((B + I(C, D, A) + doubleWordsBlocks[i, 9] + T[63]), 21);

                A = AA + A;
                B = BB + B;
                C = CC + C;
                D = DD + D;
            }


            if (!BitConverter.IsLittleEndian)
            {
                byte[] tempA = BitConverter.GetBytes(A);
                byte[] tempB = BitConverter.GetBytes(B);
                byte[] tempC = BitConverter.GetBytes(C);
                byte[] tempD = BitConverter.GetBytes(D);

                tempA = BigEndianToLittleEndianConverter.ConvertToLittleEndian(tempA);
                tempB = BigEndianToLittleEndianConverter.ConvertToLittleEndian(tempB);
                tempC = BigEndianToLittleEndianConverter.ConvertToLittleEndian(tempC);
                tempD = BigEndianToLittleEndianConverter.ConvertToLittleEndian(tempD);

                A = Convert.ToUInt32(tempA);
                B = Convert.ToUInt32(tempB);
                C = Convert.ToUInt32(tempC);
                D = Convert.ToUInt32(tempD);
            }

            string outputA = Convert.ToString(A, 16);
            if (outputA.Length < 8)
            {
                outputA = "0" + outputA;
            }
            string outputB = Convert.ToString(B, 16);
            if (outputB.Length < 8)
            {
                outputB = "0" + outputB;
            }
            string outputC = Convert.ToString(C, 16);
            if (outputC.Length < 8)
            {
                outputC = "0" + outputC;
            }
            string outputD = Convert.ToString(D, 16);
            if (outputD.Length < 8)
            {
                outputD = "0" + outputD;
            }

            string output = outputA + outputB + outputC + outputD;
            return output;
        }
    }

    public static class BigEndianToLittleEndianConverter
    {
        public static byte[] ConvertToLittleEndian(byte[] bigEndianByteBuffer)
        {
            byte[] littleEndianBuffer = new byte[bigEndianByteBuffer.Length];
            int counter = 0;
            for (int i = bigEndianByteBuffer.Length - 1; i >= 0; i--)
            {
                littleEndianBuffer[counter] = bigEndianByteBuffer[i];
                counter++;
            }
            return littleEndianBuffer;
        }
    }
}