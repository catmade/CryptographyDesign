using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    class MyCipher : ICipher<string, string>
    {
        private int[][] key1;

        private int[] key2;

        private HillCipher hillCipher;

        public MyCipher(int[][] key)
        {
            //this.hillCipher = new HillCipher(key);
        }

        public string Decrypt(string cipher)
        {
            //// 先使用移位算法，再用仿射密码，再用希尔密码
            //var bytes = Convert.FromBase64String(cipher);

            //var  s = Encoding.UTF8.GetString(bytes);

            //return hillCipher.Decrypt(b);
            return null;
        }

        public string Encrypt(string plain)
        {
            //var a = hillCipher.Encrypt(plain);
            //var b = wigenereCipher.Encrypt(a);

            //// 将List<char> 转成string
            //StringBuilder builder = new StringBuilder();
            //for (int i = 0; i < b.Count; i++)
            //{
            //    builder.Append(b[i]);
            //}

            //var bytes = Encoding.UTF8.GetBytes(builder.ToString());

            //return Convert.ToBase64String(bytes);
            return null;
        }
    }
}
