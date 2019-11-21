using NUnit.Framework;
using CryptographyDesign.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils.Tests
{
    [TestFixture()]
    public class HillCipherTests
    {
        double[,] m1 = new double[,] { { 11, 8 }, { 3, 7 } };
        double[,] m1i = new double[,] { { 7, 18 }, { 23, 11 } };
        

        [Test()]
        public void HillCipherTest()
        {
            // 进行随机测试，测试加密密文和解密密文是否相等
            Assert.AreEqual(new HillCipher(m1), null);
        }

        [Test()]
        public void HillCipherTest1()
        {
            List<char> a = new List<char>();
            for (char i = (char)0; i < 20; i++)
            {
                a.Add(i);
            }
            var aa = a.GetRange(0, 6);
            var ab = a.GetRange(6, 6);

            Assert.Fail();
        }

        [Test()]
        public void DecryptTest()
        {
            // 进行随机测试，测试加密密文和解密密文是否相等
            int time = 10;          // 测试次数
            List<char> plain;       // 明文
            int maxGroupNum = 100;    // 明文最大长度
            int minGroupNum = 1;      // 明文最小长度
            Random random = new Random();
            HillCipher cipher = new HillCipher(m1);

            // 进行time次测试
            for (int i = 0; i < time; i++)
            {
                // 随机生成测试明文
                plain = new List<char>();
                int length = random.Next(minGroupNum, maxGroupNum) * 2;
                for (int j = 0; j < length; j++)
                {
                    plain.Add((char)random.Next(0, 25));
                }

                // 测试加密功能
                try
                {
                    cipher.Decrypt(plain);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }

            }
        }

        [Test()]
        public void EncryptTest()
        {
            // 进行随机测试，测试加密密文和解密密文是否相等
            int time = 10;          // 测试次数
            List<char> plain;       // 明文
            int maxLength = 100;    // 明文最大长度
            int minLength = 1;      // 明文最小长度
            Random random = new Random();
            HillCipher cipher = new HillCipher(m1);

            // 进行time次测试
            for (int i = 0; i < time; i++)
            {
                // 随机生成测试明文
                plain = new List<char>();
                int length = random.Next(minLength, maxLength);
                for (int j = 0; j < length; j++)
                {
                    plain.Add((char)random.Next(0, 25));
                }

                // 测试加密功能
                try
                {
                    cipher.Encrypt(plain);
                }
                catch (Exception)
                {
                    Assert.Fail();
                }

            }
        }
    }
}