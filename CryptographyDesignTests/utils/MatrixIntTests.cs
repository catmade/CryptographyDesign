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
    public class MatrixIntTests
    {
        [Test()]
        public void MatrixIntTest()
        {
            int[,] m = new int[,] { { 11, 8 }, { 3, 7 } };
            var a = new MatrixInt(m);
            var ap = a.Inverse();
        }

        [Test()]
        public void MatrixIntTest1()
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
        public void simplifyTest()
        {
            Assert.Fail();
        }
    }
}