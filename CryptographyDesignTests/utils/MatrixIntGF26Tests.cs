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
    public class MatrixIntGF26Tests
    {
        [Test()]
        public void MatrixIntGF26Test()
        {
            int time = 100;
            for (int i = 0; i < time; i++)
            {
                var matrix = new MatrixIntGF26(RandomHelper.GetHillMatrix());
                var inverse = matrix.Inverse();
                var multify = matrix.MultifyMod(inverse);
                Assert.IsTrue(multify.IsUnit());
            }
        }

        [Test()]
        public void MatrixIntGF26Test1()
        {
            Assert.Fail();
        }

        [Test()]
        public void MatrixIntGF26Test2()
        {
            Assert.Fail();
        }

        [Test()]
        public void InverseTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ToIntMatrixTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void MultifyModTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void HasInverseTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetReverseTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ModTest()
        {
            Assert.Fail();
        }
    }
}