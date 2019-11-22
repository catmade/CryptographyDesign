using NUnit.Framework;
using CryptographyDesign.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CryptographyDesign.utils.Tests
{
    [TestFixture()]
    public class MatrixIntTests
    {
        [Test()]
        public void MatrixIntTest()
        {
            //int[,] m = new int[,] { { 11, 8 }, { 3, 7 } };
            //var a = new MatrixInt(m);
            //var ap = a.Inverse();
            int[] aas = new int[] { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 }; // a的取值范围
            int[] result = new int[aas.Length];
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < aas.Length; i++)
            {
                int r = 1;
                while((aas[i] * r) % 26 != 1)
                {
                    r++;
                }
                builder.AppendLine($"aap.Add({aas[i]}, {r});");
            }
            Debug.WriteLine(builder);
        }

        [Test()]
        public void MatrixIntTest1()
        {
            var num = "\\b|0\\b|1\\b|2[0-5]";
            var line = $"({num} )*({num})";
            var newLine = "\\r|\\n|\\r\\n";
            var matrix = $"^(({line})({newLine}))*({line})$";
            Regex regex = new Regex(matrix);
            string s = "1 2 3 6\n4 5 8 6\r7 8 9 9\r\n1 1 1 1";
            regex.IsMatch(s);
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