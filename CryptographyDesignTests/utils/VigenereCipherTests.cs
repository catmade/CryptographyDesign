using NUnit.Framework;
using CryptographyDesign.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptographyDesignTests.utils;

namespace CryptographyDesign.utils.Tests
{
    [TestFixture()]
    public class VigenereCipherTests
    {
        [Test()]
        public void VigenereCipherTest()
        {
            int time = 100;
            for (int i = 0; i < time; i++)
            {
                var plain = RandomHelper.GetPlain();
                var vigenere = new VigenereCipher(RandomHelper.GetVigenereKey());
                Assert.AreEqual(plain, vigenere.Decrypt(vigenere.Encrypt(plain)));
            }
        }

        [Test()]
        public void DecryptTest()
        {
           // Assert.Fail();
        }

        [Test()]
        public void EncryptTest()
        {
           // Assert.Fail();
        }
    }
}