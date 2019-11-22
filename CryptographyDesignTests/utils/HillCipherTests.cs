using NUnit.Framework;
using CryptographyDesign.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CryptographyDesignTests.utils;

namespace CryptographyDesign.utils.Tests
{
    [TestFixture()]
    public class HillCipherTests
    {
        int[,] m1 = new int[,] { { 11, 8 }, { 3, 7 } };
        int[,] m1i = new int[,] { { 7, 18 }, { 23, 11 } };


        [Test()]
        public void HillCipherTest()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    // 随机生成测试明文
            //    var plain = new List<char>();
            //    plain.Add((char)12);
            //    plain.Add((char)10);
            //    plain.Add((char)1);
            //    plain.Add((char)6);
            //    plain.Add((char)18);
            //    plain.Add((char)25);
            //    plain.Add((char)6);
            //    plain.Add((char)20);
            //    plain.Add((char)25);
            //    plain.Add((char)25);

            //    HillCipher cipher = new HillCipher(m1);
            //    // 测试加密功能
            //    Assert.AreEqual(plain, cipher.Decrypt(cipher.Encrypt(plain)));
            //}
        }

        [Test()]
        public void HillCipherTest1()
        {
            // 进行随机测试，测试加密密文和解密密文是否相等
            int time = 10;          // 测试次数
            Random random = new Random();
            HillCipher cipher = new HillCipher(RandomHelper.GetHillMatrix());

            // 进行time次测试
            for (int i = 0; i < time; i++)
            {
                // 随机生成测试明文
                var plain = RandomHelper.GetCharList();
                var re = cipher.Decrypt(cipher.Encrypt(plain));
                Assert.AreEqual(plain, re);
            }
        }

        [Test()]
        public void DecryptTest()
        {

        }

        [Test()]
        public void EncryptTest()
        {
            //// 进行随机测试，测试加密密文和解密密文是否相等
            //int time = 10;          // 测试次数
            //List<char> plain;       // 明文
            //int maxLength = 100;    // 明文最大长度
            //int minLength = 1;      // 明文最小长度
            //Random random = new Random();
            //HillCipher cipher = new HillCipher(m1);

            //// 进行time次测试
            //for (int i = 0; i < time; i++)
            //{
            //    // 随机生成测试明文
            //    plain = new List<char>();
            //    int length = random.Next(minLength, maxLength);
            //    for (int j = 0; j < length; j++)
            //    {
            //        plain.Add((char)random.Next(0, 25));
            //    }

            //    // 测试加密功能
            //    try
            //    {
            //        cipher.Encrypt(plain);
            //    }
            //    catch (Exception e)
            //    {
            //        Assert.Fail();
            //    }

            //}
        }

        [Test()]
        public void MultiplyMod26Test()
        {
            //double[] a = new double[] { 9, 20 };
            //double[] b = new double[] { 11, 24 };
            //double[] c = new double[] { 1, 6 };

            //double[,] e = new double[,] { {11, 8 }, {3, 7 } };
            //double[,] d = new double[,] { {7, 18 }, {23, 11 } };

            //double[] aa = new double[] {12, 0, 1, 6, 18, 25, 25, 6, 20, 25, 25, 25, 25, 25 };
            //for (int i = 0; i < 7; i++)
            //{
            //    c[0] = aa[2 * i];
            //    c[1] = aa[2 * i + 1];
            //    var _ = MultiplyMod26(c, e);
            //    Debug.Write(_[0] + " " + _[1] + " ");
            //}
            //for (int i = 0; i < 26; i++)
            //{
            //    for (int j = 0; j < 26; j++)
            //    {
            //        c[0] = i; c[1] = j;
            //        Assert.AreEqual(c, MultiplyMod26(MultiplyMod26(c, e), d));
            //    }
            //}
        }

        private static double[] MultiplyMod26(double[] vector, double[,] matrix)
        {
            if (vector.Length != matrix.GetLength(0))
            {
                throw new Exception("无法进行乘法运算，向量的维度和矩阵的行数不相等");
            }
            var result = new double[vector.Length];

            double temp;
            for (int i = 0; i < result.Length; i++)
            {
                temp = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp += vector[j] * matrix[j, i];
                }

                // 精确化
                temp = (int)(temp + 0.1);

                result[i] = (char)(((int)temp) % 26);
            }

            return result;
        }
    }
}