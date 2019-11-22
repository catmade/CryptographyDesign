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
    public class AffineCipherTests
    {
        [Test()]
        public void AffineCipherTest()
        {
            Random random = new Random();
            int time = 100;
            for (int i = 0; i < time; i++)
            {
                var _ = RandomHelper.GetPlain();
                int a = RandomHelper.GetAffineKeyA();
                int b = RandomHelper.GetAffineKeyB();
                var affine = new AffineCipher(a, b);
                Assert.AreEqual(_, affine.Decrypt(affine.Encrypt(_)));
            }
        }

        [Test()]
        public void DecryptTest()
        {
            //Assert.Fail();
        }

        [Test()]
        public void EncryptTest()
        {
            //Assert.Fail();
        }

        [Test()]
        public void IsKeyASuitableTest()
        {
            //Assert.Fail();
        }
    }
}