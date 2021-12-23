using System;
using System.Collections.Generic;

namespace CryptographyClassLybrary
{
    public static class SERPENTEncryptor
    {
        private static byte SBox0(byte input)
        {
            return input switch
            {
                0 => 3,
                1 => 8,
                2 => 15,
                3 => 1,
                4 => 10,
                5 => 6,
                6 => 5,
                7 => 11,
                8 => 14,
                9 => 13,
                10 => 4,
                11 => 2,
                12 => 7,
                13 => 0,
                14 => 9,
                15 => 12,
                _ => 16,
            };
        }

        private static byte SBox1(byte input)
        {
            return input switch
            {
                0 => 15,
                1 => 12,
                2 => 2,
                3 => 7,
                4 => 9,
                5 => 0,
                6 => 5,
                7 => 10,
                8 => 1,
                9 => 11,
                10 => 14,
                11 => 8,
                12 => 6,
                13 => 13,
                14 => 3,
                15 => 4,
                _ => 16,
            };
        }
        private static byte SBox2(byte input)
        {
            return input switch
            {
                0 => 8,
                1 => 6,
                2 => 7,
                3 => 9,
                4 => 3,
                5 => 12,
                6 => 10,
                7 => 15,
                8 => 13,
                9 => 1,
                10 => 14,
                11 => 4,
                12 => 0,
                13 => 11,
                14 => 5,
                15 => 2,
                _ => 16,
            };
        }
        private static byte SBox3(byte input)
        {
            return input switch
            {
                0 => 0,
                1 => 15,
                2 => 11,
                3 => 8,
                4 => 12,
                5 => 9,
                6 => 6,
                7 => 3,
                8 => 13,
                9 => 1,
                10 => 2,
                11 => 4,
                12 => 10,
                13 => 7,
                14 => 5,
                15 => 14,
                _ => 16,
            };
        }
        private static byte SBox4(byte input)
        {
            return input switch
            {
                0 => 1,
                1 => 15,
                2 => 8,
                3 => 3,
                4 => 12,
                5 => 0,
                6 => 11,
                7 => 6,
                8 => 2,
                9 => 5,
                10 => 4,
                11 => 10,
                12 => 9,
                13 => 14,
                14 => 7,
                15 => 13,
                _ => 16,
            };
        }
        private static byte SBox5(byte input)
        {
            return input switch
            {
                0 => 15,
                1 => 5,
                2 => 2,
                3 => 11,
                4 => 4,
                5 => 10,
                6 => 9,
                7 => 12,
                8 => 0,
                9 => 3,
                10 => 14,
                11 => 8,
                12 => 13,
                13 => 6,
                14 => 7,
                15 => 1,
                _ => 16,
            };
        }
        private static byte SBox6(byte input)
        {
            return input switch
            {
                0 => 7,
                1 => 2,
                2 => 12,
                3 => 5,
                4 => 8,
                5 => 4,
                6 => 6,
                7 => 11,
                8 => 14,
                9 => 9,
                10 => 1,
                11 => 15,
                12 => 13,
                13 => 3,
                14 => 10,
                15 => 0,
                _ => 16,
            };
        }
        private static byte SBox7(byte input)
        {
            return input switch
            {
                0 => 1,
                1 => 13,
                2 => 15,
                3 => 0,
                4 => 14,
                5 => 8,
                6 => 2,
                7 => 11,
                8 => 7,
                9 => 4,
                10 => 12,
                11 => 10,
                12 => 9,
                13 => 3,
                14 => 5,
                15 => 6,
                _ => 16,
            };
        }

        private static byte InverseSBox0(byte input)
        {
            return input switch
            {
                0 => 13,
                1 => 3,
                2 => 11,
                3 => 0,
                4 => 10,
                5 => 6,
                6 => 5,
                7 => 12,
                8 => 1,
                9 => 14,
                10 => 4,
                11 => 7,
                12 => 15,
                13 => 9,
                14 => 8,
                15 => 2,
                _ => 16,
            };
        }
        private static byte InverseSBox1(byte input)
        {
            return input switch
            {
                0 => 5,
                1 => 8,
                2 => 2,
                3 => 14,
                4 => 15,
                5 => 6,
                6 => 12,
                7 => 3,
                8 => 11,
                9 => 4,
                10 => 7,
                11 => 9,
                12 => 1,
                13 => 13,
                14 => 10,
                15 => 0,
                _ => 16,
            };
        }
        private static byte InverseSBox2(byte input)
        {
            return input switch
            {
                0 => 12,
                1 => 9,
                2 => 15,
                3 => 4,
                4 => 11,
                5 => 14,
                6 => 1,
                7 => 2,
                8 => 0,
                9 => 3,
                10 => 6,
                11 => 13,
                12 => 5,
                13 => 8,
                14 => 10,
                15 => 7,
                _ => 16,
            };
        }
        private static byte InverseSBox3(byte input)
        {
            return input switch
            {
                0 => 0,
                1 => 9,
                2 => 10,
                3 => 7,
                4 => 11,
                5 => 14,
                6 => 6,
                7 => 13,
                8 => 3,
                9 => 5,
                10 => 12,
                11 => 2,
                12 => 4,
                13 => 8,
                14 => 15,
                15 => 1,
                _ => 16,
            };
        }
        private static byte InverseSBox4(byte input)
        {
            return input switch
            {
                0 => 5,
                1 => 0,
                2 => 8,
                3 => 3,
                4 => 10,
                5 => 9,
                6 => 7,
                7 => 14,
                8 => 2,
                9 => 12,
                10 => 11,
                11 => 6,
                12 => 4,
                13 => 15,
                14 => 13,
                15 => 1,
                _ => 16,
            };
        }
        private static byte InverseSBox5(byte input)
        {
            return input switch
            {
                0 => 8,
                1 => 15,
                2 => 2,
                3 => 9,
                4 => 4,
                5 => 1,
                6 => 13,
                7 => 14,
                8 => 11,
                9 => 6,
                10 => 5,
                11 => 3,
                12 => 7,
                13 => 12,
                14 => 10,
                15 => 0,
                _ => 16,
            };
        }
        private static byte InverseSBox6(byte input)
        {
            return input switch
            {
                0 => 15,
                1 => 10,
                2 => 1,
                3 => 13,
                4 => 5,
                5 => 3,
                6 => 6,
                7 => 0,
                8 => 4,
                9 => 9,
                10 => 14,
                11 => 7,
                12 => 2,
                13 => 12,
                14 => 8,
                15 => 11,
                _ => 16,
            };
        }
        private static byte InverseSBox7(byte input)
        {
            return input switch
            {
                0 => 3,
                1 => 0,
                2 => 6,
                3 => 13,
                4 => 9,
                5 => 14,
                6 => 15,
                7 => 8,
                8 => 5,
                9 => 12,
                10 => 11,
                11 => 7,
                12 => 10,
                13 => 1,
                14 => 4,
                15 => 2,
                _ => 16,
            };
        }

        private delegate byte SBoxes(byte input);
        private static SBoxes[] sBoxes = new SBoxes[8] 
        { SBox0, SBox1, SBox2, SBox3, SBox4, SBox5, SBox6, SBox7 };
        private static SBoxes[] inverseSBoxes = new SBoxes[8] 
        { InverseSBox7, InverseSBox6, InverseSBox5, InverseSBox4, InverseSBox3, 
            InverseSBox2, InverseSBox1, InverseSBox0 };

        private static uint CycleRotateLeft(uint X, int n)
        {
            return (X << n) | (X >> (32 - n));
        }

        private static uint CycleRotateRight(uint X, int n)
        {
            return (X >> n) | (X << (32 - n));
        }

        private static List<string> GenerateKeys(string key)
        {
            string mainKey = SHA_2Encryptor.SHA_256Encryption(key);
            uint[] mainLongWordKeys = new uint[140];
            for (int i = 0; i < 8; i++)
            {
                mainLongWordKeys[i] = Convert.ToUInt32(mainKey.Substring(i * 8, 8), 16);
            }
            uint coefficient = 0x9e3779b9;
            for (uint i = 8; i < 140; i++)
            {
                mainLongWordKeys[i] = CycleRotateLeft((mainLongWordKeys[i - 8] ^ mainLongWordKeys[i - 5] ^
                    mainLongWordKeys[i - 3] ^ mainLongWordKeys[i - 1] ^ coefficient ^ (i - 8)), 11);
            }
            List<List<byte>> keys4bit = new List<List<byte>>();
            List<byte> tempList = new List<byte>();
            for (uint i = 8; i < 140; i++)
            {
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 28) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 24) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 20) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 16) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 12) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 8) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 4) << 4) >> 4));
                tempList.Add((byte)((byte)((byte)(mainLongWordKeys[i] >> 0) << 4) >> 4));
                keys4bit.Add(tempList);
                tempList = new List<byte>();

            }

            int s_BoxCounter = 3;
            List<List<byte>> subRoundKeys = new List<List<byte>>();
            for (int i = 0; i < 132; i += 4)
            {
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][0]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][1]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][2]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][3]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][4]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][5]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][6]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 0][7]));
                subRoundKeys.Add(tempList);
                tempList = new List<byte>();

                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][0]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][1]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][2]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][3]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][4]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][5]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][6]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 1][7]));
                subRoundKeys.Add(tempList);
                tempList = new List<byte>();

                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][0]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][1]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][2]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][3]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][4]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][5]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][6]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 2][7]));
                subRoundKeys.Add(tempList);
                tempList = new List<byte>();

                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][0]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][1]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][2]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][3]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][4]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][5]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][6]));
                tempList.Add(sBoxes[s_BoxCounter](keys4bit[i + 3][7]));
                subRoundKeys.Add(tempList);
                tempList = new List<byte>();

                s_BoxCounter--;
                if (s_BoxCounter <= -1)
                {
                    s_BoxCounter = 7;
                }
            }

            uint[] roundLongWordKeys = new uint[132];
            for (int i = 0; i < 132; i++)
            {
                uint temp = 0;
                temp += (uint)(subRoundKeys[i][0] << 28);
                temp += (uint)(subRoundKeys[i][1] << 24);
                temp += (uint)(subRoundKeys[i][2] << 20);
                temp += (uint)(subRoundKeys[i][3] << 16);
                temp += (uint)(subRoundKeys[i][4] << 12);
                temp += (uint)(subRoundKeys[i][5] << 8);
                temp += (uint)(subRoundKeys[i][6] << 4);
                temp += (uint)(subRoundKeys[i][7] << 0);
                roundLongWordKeys[i] = temp;
            }

            List<string> roundKeys = new List<string>();
            for (int i = 0; i < 132; i += 4)
            {
                string tempString0 = Convert.ToString(roundLongWordKeys[i + 0], 16);
                while (tempString0.Length < 8)
                {
                    tempString0 = '0' + tempString0;
                }
                string tempString1 = Convert.ToString(roundLongWordKeys[i + 1], 16);
                while (tempString1.Length < 8)
                {
                    tempString1 = '0' + tempString1;
                }
                string tempString2 = Convert.ToString(roundLongWordKeys[i + 2], 16);
                while (tempString2.Length < 8)
                {
                    tempString2 = '0' + tempString2;
                }
                string tempString3 = Convert.ToString(roundLongWordKeys[i + 3], 16);
                while (tempString3.Length < 8)
                {
                    tempString3 = '0' + tempString3;
                }
                roundKeys.Add(tempString0 + tempString1 + tempString2 + tempString3);
            }

            return roundKeys;
        }

        public static string SERPENTEncryption(string message, string key)
        {
            List<string> roundKeys = GenerateKeys(key);
            List<List<uint>> roundDoubleWordKeys = new List<List<uint>>();
            List<uint> tempDoubleWordList = new List<uint>();
            for (int i = 0; i < roundKeys.Count; i++)
            {
                tempDoubleWordList.Add(Convert.ToUInt32(roundKeys[i].Substring(0, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(roundKeys[i].Substring(8, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(roundKeys[i].Substring(16, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(roundKeys[i].Substring(24, 8), 16));
                roundDoubleWordKeys.Add(tempDoubleWordList);
                tempDoubleWordList = new List<uint>();
            }

            List<byte> messageByteCode = new List<byte>();
            for (int i = 0; i < message.Length; i++)
            {
                messageByteCode.Add((byte)message[i]);
            }
            while (messageByteCode.Count % 16 != 0)
            {
                messageByteCode.Add(0);
            }

            List<List<uint>> message128bitBlocks = new List<List<uint>>();
            tempDoubleWordList = new List<uint>();
            for (int i = 0; i < messageByteCode.Count; i += 16)
            {
                uint temp = 0;
                temp += (uint)(messageByteCode[i + 0] << 24);
                temp += (uint)(messageByteCode[i + 1] << 16);
                temp += (uint)(messageByteCode[i + 2] << 8);
                temp += (uint)(messageByteCode[i + 3] << 0);
                tempDoubleWordList.Add(temp);

                temp = 0;
                temp += (uint)(messageByteCode[i + 4] << 24);
                temp += (uint)(messageByteCode[i + 5] << 16);
                temp += (uint)(messageByteCode[i + 6] << 8);
                temp += (uint)(messageByteCode[i + 7] << 0);
                tempDoubleWordList.Add(temp);

                temp = 0;
                temp += (uint)(messageByteCode[i + 8] << 24);
                temp += (uint)(messageByteCode[i + 9] << 16);
                temp += (uint)(messageByteCode[i + 10] << 8);
                temp += (uint)(messageByteCode[i + 11] << 0);
                tempDoubleWordList.Add(temp);

                temp = 0;
                temp += (uint)(messageByteCode[i + 12] << 24);
                temp += (uint)(messageByteCode[i + 13] << 16);
                temp += (uint)(messageByteCode[i + 14] << 8);
                temp += (uint)(messageByteCode[i + 15] << 0);
                tempDoubleWordList.Add(temp);

                message128bitBlocks.Add(tempDoubleWordList);
                tempDoubleWordList = new List<uint>();
            }

            for (int c = 0; c < message128bitBlocks.Count; c++)
            {
                int sBoxCounter = 0;
                List<List<byte>> temp4bitBlocks = new List<List<byte>>();
                List<byte> tempList = new List<byte>();
                for (int i = 0; i < 31; i++)
                {
                    message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ roundDoubleWordKeys[i][0];
                    message128bitBlocks[c][1] = message128bitBlocks[c][1] ^ roundDoubleWordKeys[i][1];
                    message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ roundDoubleWordKeys[i][2];
                    message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ roundDoubleWordKeys[i][3];

                    temp4bitBlocks = new List<List<byte>>();
                    tempList = new List<byte>();
                    for (int j = 0; j < 4; j++)
                    {
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 28) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 24) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 20) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 16) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 12) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 8) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 4) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 0) << 4) >> 4));
                        temp4bitBlocks.Add(tempList);
                        tempList = new List<byte>();
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            temp4bitBlocks[j][k] = sBoxes[sBoxCounter](temp4bitBlocks[j][k]);
                        }
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        uint temp = 0;
                        temp += (uint)(temp4bitBlocks[j][0] << 28);
                        temp += (uint)(temp4bitBlocks[j][1] << 24);
                        temp += (uint)(temp4bitBlocks[j][2] << 20);
                        temp += (uint)(temp4bitBlocks[j][3] << 16);
                        temp += (uint)(temp4bitBlocks[j][4] << 12);
                        temp += (uint)(temp4bitBlocks[j][5] << 8);
                        temp += (uint)(temp4bitBlocks[j][6] << 4);
                        temp += (uint)(temp4bitBlocks[j][7] << 0);
                        message128bitBlocks[c][j] = temp;
                    }

                    message128bitBlocks[c][0] = CycleRotateLeft(message128bitBlocks[c][0], 13);
                    message128bitBlocks[c][2] = CycleRotateLeft(message128bitBlocks[c][2], 3);
                    message128bitBlocks[c][1] = message128bitBlocks[c][0] ^ message128bitBlocks[c][1] ^ message128bitBlocks[c][2];
                    message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ message128bitBlocks[c][2] ^ (message128bitBlocks[c][0] << 3);
                    message128bitBlocks[c][1] = CycleRotateLeft(message128bitBlocks[c][1], 1);
                    message128bitBlocks[c][3] = CycleRotateLeft(message128bitBlocks[c][3], 7);
                    message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ message128bitBlocks[c][1] ^ message128bitBlocks[c][3];
                    message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ message128bitBlocks[c][3] ^ (message128bitBlocks[c][1] << 7);
                    message128bitBlocks[c][0] = CycleRotateLeft(message128bitBlocks[c][0], 5);
                    message128bitBlocks[c][2] = CycleRotateLeft(message128bitBlocks[c][2], 22);

                    sBoxCounter++;
                    if (sBoxCounter > 7)
                    {
                        sBoxCounter = 0;
                    }
                }

                message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ roundDoubleWordKeys[31][0];
                message128bitBlocks[c][1] = message128bitBlocks[c][1] ^ roundDoubleWordKeys[31][1];
                message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ roundDoubleWordKeys[31][2];
                message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ roundDoubleWordKeys[31][3];

                temp4bitBlocks = new List<List<byte>>();
                tempList = new List<byte>();
                for (int j = 0; j < 4; j++)
                {
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 28) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 24) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 20) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 16) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 12) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 8) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 4) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 0) << 4) >> 4));
                    temp4bitBlocks.Add(tempList);
                    tempList = new List<byte>();
                }
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        temp4bitBlocks[j][k] = sBoxes[sBoxCounter](temp4bitBlocks[j][k]);
                    }
                }
                for (int j = 0; j < 4; j++)
                {
                    uint temp = 0;
                    temp += (uint)(temp4bitBlocks[j][0] << 28);
                    temp += (uint)(temp4bitBlocks[j][1] << 24);
                    temp += (uint)(temp4bitBlocks[j][2] << 20);
                    temp += (uint)(temp4bitBlocks[j][3] << 16);
                    temp += (uint)(temp4bitBlocks[j][4] << 12);
                    temp += (uint)(temp4bitBlocks[j][5] << 8);
                    temp += (uint)(temp4bitBlocks[j][6] << 4);
                    temp += (uint)(temp4bitBlocks[j][7] << 0);
                    message128bitBlocks[c][j] = temp;
                }

                message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ roundDoubleWordKeys[32][0];
                message128bitBlocks[c][1] = message128bitBlocks[c][1] ^ roundDoubleWordKeys[32][1];
                message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ roundDoubleWordKeys[32][2];
                message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ roundDoubleWordKeys[32][3];
            }

            string output = "";
            for (int i = 0; i < message128bitBlocks.Count; i++)
            {
                string temp0 = Convert.ToString(message128bitBlocks[i][0], 16);
                while (temp0.Length < 8)
                {
                    temp0 = '0' + temp0;
                }
                string temp1 = Convert.ToString(message128bitBlocks[i][1], 16);
                while (temp1.Length < 8)
                {
                    temp1 = '0' + temp1;
                }
                string temp2 = Convert.ToString(message128bitBlocks[i][2], 16);
                while (temp2.Length < 8)
                {
                    temp2 = '0' + temp2;
                }
                string temp3 = Convert.ToString(message128bitBlocks[i][3], 16);
                while (temp3.Length < 8)
                {
                    temp3 = '0' + temp3;
                }
                output += temp0 + temp1 + temp2 + temp3;
            }
            return output;
        }

        public static string SERPENTDecryption(string message, string key)
        {
            List<string> roundKeys = GenerateKeys(key);
            List<string> roundDecryptionKeys = new List<string>();
            for (int i = roundKeys.Count - 1; i >= 0; i--)
            {
                roundDecryptionKeys.Add(roundKeys[i]);
            }
            List<List<uint>> roundDoubleWordKeys = new List<List<uint>>();
            List<uint> tempDoubleWordList = new List<uint>();
            for (int i = 0; i < roundKeys.Count; i++)
            {
                tempDoubleWordList.Add(Convert.ToUInt32(roundDecryptionKeys[i].Substring(0, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(roundDecryptionKeys[i].Substring(8, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(roundDecryptionKeys[i].Substring(16, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(roundDecryptionKeys[i].Substring(24, 8), 16));
                roundDoubleWordKeys.Add(tempDoubleWordList);
                tempDoubleWordList = new List<uint>();
            }

            List<List<uint>> message128bitBlocks = new List<List<uint>>();
            tempDoubleWordList = new List<uint>();
            for (int i = 0; i < message.Length / 32; i++)
            {
                tempDoubleWordList.Add(Convert.ToUInt32(message.Substring(i * 32 + 0, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(message.Substring(i * 32 + 8, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(message.Substring(i * 32 + 16, 8), 16));
                tempDoubleWordList.Add(Convert.ToUInt32(message.Substring(i * 32 + 24, 8), 16));
                message128bitBlocks.Add(tempDoubleWordList);
                tempDoubleWordList = new List<uint>();
            }

            for (int c = 0; c < message128bitBlocks.Count; c++)
            {
                int sBoxCounter = 0;
                List<List<byte>> temp4bitBlocks = new List<List<byte>>();
                List<byte> tempList = new List<byte>();

                message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ roundDoubleWordKeys[0][0];
                message128bitBlocks[c][1] = message128bitBlocks[c][1] ^ roundDoubleWordKeys[0][1];
                message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ roundDoubleWordKeys[0][2];
                message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ roundDoubleWordKeys[0][3];

                temp4bitBlocks = new List<List<byte>>();
                tempList = new List<byte>();
                for (int j = 0; j < 4; j++)
                {
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 28) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 24) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 20) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 16) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 12) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 8) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 4) << 4) >> 4));
                    tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 0) << 4) >> 4));
                    temp4bitBlocks.Add(tempList);
                    tempList = new List<byte>();
                }
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        temp4bitBlocks[j][k] = inverseSBoxes[sBoxCounter](temp4bitBlocks[j][k]);
                    }
                }
                for (int j = 0; j < 4; j++)
                {
                    uint temp = 0;
                    temp += (uint)(temp4bitBlocks[j][0] << 28);
                    temp += (uint)(temp4bitBlocks[j][1] << 24);
                    temp += (uint)(temp4bitBlocks[j][2] << 20);
                    temp += (uint)(temp4bitBlocks[j][3] << 16);
                    temp += (uint)(temp4bitBlocks[j][4] << 12);
                    temp += (uint)(temp4bitBlocks[j][5] << 8);
                    temp += (uint)(temp4bitBlocks[j][6] << 4);
                    temp += (uint)(temp4bitBlocks[j][7] << 0);
                    message128bitBlocks[c][j] = temp;
                }

                message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ roundDoubleWordKeys[1][0];
                message128bitBlocks[c][1] = message128bitBlocks[c][1] ^ roundDoubleWordKeys[1][1];
                message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ roundDoubleWordKeys[1][2];
                message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ roundDoubleWordKeys[1][3];

                sBoxCounter++;

                for (int i = 2; i <= 32; i++)
                {
                    message128bitBlocks[c][2] = CycleRotateRight(message128bitBlocks[c][2], 22);
                    message128bitBlocks[c][0] = CycleRotateRight(message128bitBlocks[c][0], 5);
                    message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ message128bitBlocks[c][3] ^ (message128bitBlocks[c][1] << 7);
                    message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ message128bitBlocks[c][1] ^ message128bitBlocks[c][3];
                    message128bitBlocks[c][3] = CycleRotateRight(message128bitBlocks[c][3], 7);
                    message128bitBlocks[c][1] = CycleRotateRight(message128bitBlocks[c][1], 1);
                    message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ message128bitBlocks[c][2] ^ (message128bitBlocks[c][0] << 3);
                    message128bitBlocks[c][1] = message128bitBlocks[c][0] ^ message128bitBlocks[c][1] ^ message128bitBlocks[c][2];
                    message128bitBlocks[c][2] = CycleRotateRight(message128bitBlocks[c][2], 3);
                    message128bitBlocks[c][0] = CycleRotateRight(message128bitBlocks[c][0], 13);

                    temp4bitBlocks = new List<List<byte>>();
                    tempList = new List<byte>();
                    for (int j = 0; j < 4; j++)
                    {
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 28) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 24) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 20) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 16) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 12) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 8) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 4) << 4) >> 4));
                        tempList.Add((byte)((byte)((byte)(message128bitBlocks[c][j] >> 0) << 4) >> 4));
                        temp4bitBlocks.Add(tempList);
                        tempList = new List<byte>();
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            temp4bitBlocks[j][k] = inverseSBoxes[sBoxCounter](temp4bitBlocks[j][k]);
                        }
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        uint temp = 0;
                        temp += (uint)(temp4bitBlocks[j][0] << 28);
                        temp += (uint)(temp4bitBlocks[j][1] << 24);
                        temp += (uint)(temp4bitBlocks[j][2] << 20);
                        temp += (uint)(temp4bitBlocks[j][3] << 16);
                        temp += (uint)(temp4bitBlocks[j][4] << 12);
                        temp += (uint)(temp4bitBlocks[j][5] << 8);
                        temp += (uint)(temp4bitBlocks[j][6] << 4);
                        temp += (uint)(temp4bitBlocks[j][7] << 0);
                        message128bitBlocks[c][j] = temp;
                    }

                    message128bitBlocks[c][0] = message128bitBlocks[c][0] ^ roundDoubleWordKeys[i][0];
                    message128bitBlocks[c][1] = message128bitBlocks[c][1] ^ roundDoubleWordKeys[i][1];
                    message128bitBlocks[c][2] = message128bitBlocks[c][2] ^ roundDoubleWordKeys[i][2];
                    message128bitBlocks[c][3] = message128bitBlocks[c][3] ^ roundDoubleWordKeys[i][3];

                    sBoxCounter++;
                    if (sBoxCounter > 7)
                    {
                        sBoxCounter = 0;
                    }
                }
            }

            List<byte> messageByteCode = new List<byte>();
            for (int i = 0; i < message128bitBlocks.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    messageByteCode.Add((byte)(message128bitBlocks[i][j] >> 24));
                    messageByteCode.Add((byte)(message128bitBlocks[i][j] >> 16));
                    messageByteCode.Add((byte)(message128bitBlocks[i][j] >> 8));
                    messageByteCode.Add((byte)(message128bitBlocks[i][j] >> 0));
                }
            }

            string output = "";
            for (int i = 0; i < messageByteCode.Count; i++)
            {
                output += Convert.ToChar(messageByteCode[i]);
            }
            return output;
        }
    }
}
