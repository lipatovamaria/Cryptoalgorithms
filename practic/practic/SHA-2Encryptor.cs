using System;
using System.Collections.Generic;

namespace CryptographyClassLybrary
{
    public static class LittleEndianToBigEndianConverter
    {
        public static byte[] ConvertToBigEndian(byte[] littleEndianByteBuffer)
        {
            byte[] bigEndianBuffer = new byte[littleEndianByteBuffer.Length];
            int counter = 0;
            for (int i = littleEndianByteBuffer.Length - 1; i >= 0; i--)
            {
                bigEndianBuffer[counter] = littleEndianByteBuffer[i];
                counter++;
            }
            return bigEndianBuffer;
        }
    }
    public static class SHA_2Encryptor
    {
        private static uint cycleRotateRight(uint X, int n)
        {
            return (X >> n) | (X << (32 - n));
        }
        public static string SHA_256Encryption(string message)
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

            byte[] messageByteLength = BitConverter.GetBytes(messageLength);
            if (BitConverter.IsLittleEndian)
            {
                messageByteLength = LittleEndianToBigEndianConverter.ConvertToBigEndian(messageByteLength);
            }
            messageByteCode.AddRange(messageByteLength);

            uint h0 = 0x6a09e667;
            uint h1 = 0xbb67ae85;
            uint h2 = 0x3c6ef372;
            uint h3 = 0xa54ff53a;
            uint h4 = 0x510e527f;
            uint h5 = 0x9b05688c;
            uint h6 = 0x1f83d9ab;
            uint h7 = 0x5be0cd19;

            uint[] k = new uint[64] {0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
                                    0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
                                    0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
                                    0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
                                    0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
                                    0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
                                    0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
                                    0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2 };

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

            uint[,] doubleWordsBlocksModified = new uint[doubleWordsBlocksAmount, 64];
            for (int i = 0; i < doubleWordsBlocksAmount; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    if (j < 16)
                    {
                        doubleWordsBlocksModified[i, j] = doubleWordsBlocks[i, j];
                    }
                    else
                    {
                        doubleWordsBlocksModified[i, j] = 0;
                    }
                }

                for (int j = 16; j < 64; j++)
                {
                    uint s0 = cycleRotateRight(doubleWordsBlocksModified[i, j - 15], 7) ^
                        cycleRotateRight(doubleWordsBlocksModified[i, j - 15], 18) ^
                        (doubleWordsBlocksModified[i, j - 15] >> 3);
                    uint s1 = cycleRotateRight(doubleWordsBlocksModified[i, j - 2], 17) ^
                        cycleRotateRight(doubleWordsBlocksModified[i, j - 2], 19) ^
                        (doubleWordsBlocksModified[i, j - 2] >> 10);
                    doubleWordsBlocksModified[i, j] = (UInt32)(doubleWordsBlocksModified[i, j - 16] + s0 +
                        doubleWordsBlocksModified[i, j - 7] + s1);
                }

                uint a = h0;
                uint b = h1;
                uint c = h2;
                uint d = h3;
                uint e = h4;
                uint f = h5;
                uint g = h6;
                uint h = h7;

                for (int j = 0; j < 64; j++)
                {
                    uint s1 = cycleRotateRight(e, 6) ^ cycleRotateRight(e, 11) ^ cycleRotateRight(e, 25);
                    uint ch = (e & f) ^ (~e & g);
                    uint temp1 = h + s1 + ch + k[j] + doubleWordsBlocksModified[i, j];
                    uint s0 = cycleRotateRight(a, 2) ^ cycleRotateRight(a, 13) ^ cycleRotateRight(a, 22);
                    uint maj = (a & b) ^ (a & c) ^ (b & c);
                    uint temp2 = s0 + maj;
                    h = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }

                h0 += a;
                h1 += b;
                h2 += c;
                h3 += d;
                h4 += e;
                h5 += f;
                h6 += g;
                h7 += h;
            }

            string h0Sentence = Convert.ToString(h0, 16);
            while (h0Sentence.Length < 8)
            {
                h0Sentence = '0' + h0Sentence;
            }
            string h1Sentence = Convert.ToString(h1, 16);
            while (h1Sentence.Length < 8)
            {
                h1Sentence = '0' + h1Sentence;
            }
            string h2Sentence = Convert.ToString(h2, 16);
            while (h2Sentence.Length < 8)
            {
                h2Sentence = '0' + h2Sentence;
            }
            string h3Sentence = Convert.ToString(h3, 16);
            while (h3Sentence.Length < 8)
            {
                h3Sentence = '0' + h3Sentence;
            }
            string h4Sentence = Convert.ToString(h4, 16);
            while (h4Sentence.Length < 8)
            {
                h4Sentence = '0' + h4Sentence;
            }
            string h5Sentence = Convert.ToString(h5, 16);
            while (h5Sentence.Length < 8)
            {
                h5Sentence = '0' + h5Sentence;
            }
            string h6Sentence = Convert.ToString(h6, 16);
            while (h6Sentence.Length < 8)
            {
                h6Sentence = '0' + h6Sentence;
            }
            string h7Sentence = Convert.ToString(h7, 16);
            while (h7Sentence.Length < 8)
            {
                h7Sentence = '0' + h7Sentence;
            }
            string output = h0Sentence + h1Sentence + h2Sentence + h3Sentence + h4Sentence + 
                h5Sentence + h6Sentence + h7Sentence;
            return output;
        }
    }
}
