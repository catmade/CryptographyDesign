using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 移位密码
    /// </summary>
    public class ShiftCipher : ICipher<List<char>, List<char>>
    {
        /// <summary>
        /// 是否限制为模运算
        /// </summary>
        private readonly int Mod = -1;

        /// <summary>
        /// 偏移量
        /// </summary>
        private readonly int shift;

        public ShiftCipher(int shift)
        {
            this.shift = shift;
        }

        public ShiftCipher(int shift, int mod) : this(shift)
        {
            this.Mod = mod;
        }

        public List<char> Decrypt(List<char> cipher)
        {
            for (int i = 0; i < cipher.Count; i++)
            {
                var t = cipher[i] + shift;
                if (Mod != -1)
                {
                    t %= Mod;
                }
                else
                {
                    t %= char.MaxValue;
                }

                cipher[i] = (char)t;
            }
            return cipher;
        }

        public List<char> Encrypt(List<char> plain)
        {
            for (int i = 0; i < plain.Count; i++)
            {
                var t = plain[i] - shift;
                if (Mod != -1)
                {
                    t %= Mod;
                }
                else
                {
                    t %= char.MaxValue;
                }

                plain[i] = (char)t;
            }
            return plain;
        }
    }
}
