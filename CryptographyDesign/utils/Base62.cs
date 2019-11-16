using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    class Base62 : ICipher<List<char>, string>
    {
        /// <summary>
        /// 密文空间
        /// </summary>
        private readonly char[] cs = new char[]{
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            '-', '+'
        };

        public List<char> Decrypt(string cipher)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(List<char> plain)
        {
            //// 3.模仿base64，用8个‘cs‘表中的符号表示3个char型（6byte）
            //StringBuilder builder = new StringBuilder();

            //int groupL = 3; // 分组长度
            //int n = plain.Count / groupL;  // 商
            //int r = plain.Count % groupL;  // 余

            //List<char> group;
            //for (int i = 0; i < n; i++)
            //{
            //    // 将3个char转成二进制并拼接起来
            //    string s = "";
            //    group = plain.GetRange(i, groupL);
            //    foreach (var item in group)
            //    {
            //        s += Convert.ToString(item, 2).PadLeft(16, '0');
            //    }

            //    // 将二进制每6位分割开
            //    var arr = s.ToCharArray().ToList();
            //    for (int j = 0; j < arr.Count / 6; j++)
            //    {
            //        var g = arr.GetRange(j, 6);
            //        var nn = "";
            //        foreach (var ii in g)
            //        {
            //            nn += ii;
            //        }
            //        builder.Append(cs[int.Parse(nn)]);
            //    }
            //}

            //return builder.ToString();
            return null;
        }
    }
}
