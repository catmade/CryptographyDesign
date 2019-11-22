using CryptographyDesign.utils;
using CryptographyDesignTests.utils;
using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils.Tests
{
    [TestFixture()]
    public class MyCipherTests
    {
        [Test()]
        public void MyCipherTest()
        {
            int time = 100;
            int[] vigenereKey;
            int affineKeyA;
            int affineKeyB;
            int[,] hillMatrix;

            for (int i = 0; i < time; i++)
            {
                GetRandomKeys(out vigenereKey, out affineKeyA, out affineKeyB, out hillMatrix);
                var mycipher = new MyCipher(vigenereKey, affineKeyA, affineKeyB, hillMatrix);
                var plain = RandomHelper.GetString();
                Assert.AreEqual(plain, mycipher.Decrypt(mycipher.Encrypt(plain)));
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

        private void GetRandomKeys(out int[] vigenereKey, out int affineKeyA, out int affineKeyB, out int[,] hillMatrix)
        {
            vigenereKey = RandomHelper.GetVigenereKey();

            affineKeyA = RandomHelper.GetAffineKeyA();
            affineKeyB = RandomHelper.GetAffineKeyB();

            hillMatrix = RandomHelper.GetHillMatrix();
        }
    }
}