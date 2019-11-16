using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    class WigenereCipher : ICipher<List<char>, List<char>>
    {
        private int[] key;

        private int groupLength;

        public WigenereCipher(int[] key)
        {
            this.groupLength = key.Length;
            this.key = key;
        }

        public List<char> Decrypt(List<char> cipher)
        {
            int groupNums = cipher.Count / groupLength + cipher.Count % groupLength == 0 ? 0 : 1;   // 总分组数

            var result = new List<char>();
            for (int i = 0; i < groupNums; i++)
            {
                var g = cipher.GetRange(i, groupLength);

                for (int j = 0; j < g.Count; j++)
                {
                    result.Add((char)((g[j] - key[j]) % char.MaxValue));
                }
            }

            return result;
        }

        public List<char> Encrypt(List<char> plain)
        {
            int groupNums = plain.Count / groupLength + plain.Count % groupLength == 0 ? 0 : 1;   // 总分组数

            var result = new List<char>();
            for (int i = 0; i < groupNums; i++)
            {
                var g = plain.GetRange(i, groupLength);

                for (int j = 0; j < g.Count; j++)
                {
                    result.Add((char)((g[j] + key[j]) % char.MaxValue));
                }
            }

            return result;
        }
    }
}
