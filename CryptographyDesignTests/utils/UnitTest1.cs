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
    public class UnitTest1
    {
        [Test()]
        public void TestMethod1()
        {
            string s = "1 2 3 4\r4 5 6 7\n1 2 3 4\r\n5 7 9 1";
            string num = "(\\b|0\\b|1\\b|2[0-5])";
            string line = $"(({num} )*({num}))";
            string newLine = "(\r|\n|\r\n)";
            //Regex regex = new Regex($"^(({line}{newLine})*({line}))$");
            // regex.Matches(s);

        }

        [Test()]
        public void TestList()
        {
            for (int m = 0; m < 3; m++)
            {
                List<int> list = new List<int>();
                list.Add(0);
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(1);
                list.Add(1);
                list.Add(9);
                list.Add(1);
                list.Add(1);
                list.Add(1);
                list.Add(1);

                Debug.WriteLine(list);
                Debug.WriteLine(list.ToArray());

                //for (int i = 1; i < list.Count; i++)
                //{
                //    if (list[i] == 1 && list[i - 1] == 1)
                //    {
                //        list.RemoveAt(i);
                //    }
                //}
            }
        }
    }
}
