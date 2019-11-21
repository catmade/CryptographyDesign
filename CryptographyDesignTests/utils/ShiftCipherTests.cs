using NUnit.Framework;
using CryptographyDesign.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptographyDesignTests.utils;
using System.Diagnostics;

namespace CryptographyDesign.utils.Tests
{
    [TestFixture()]
    public class ShiftCipherTests
    {
        [Test()]
        public void ShiftCipherTest()
        {
            // 测试次数
            int time = 100;
            for (int i = 0; i < time; i++)
            {
                for (int mod = 1; mod <= 300; mod++)
                {
                    var shift = new Random().Next(0, 300);
                    var cipher = new ShiftCipher(shift, mod);
                    var data = RandomHelper.GetPlain();
                    Assert.AreEqual(data, cipher.Decrypt(cipher.Encrypt(data)));
                }
            }
        }

        [Test()]
        public void ShiftCipherTest1()
        {
            
        }

        [Test()]
        public void DecryptTest()
        {

        }

        [Test()]
        public void EncryptTest()
        {

        }
    }
}