using System.Collections.Generic;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 维吉尼亚密码：e(x1..xm) = (x1 + k1...xm + km)
    /// </summary>
    public class VigenereCipher : ICipher<List<char>, List<char>>
    {
        private int[] vigenereKey;

        private int m = 26;

        public VigenereCipher(int[] vigenereKey)
        {
            this.vigenereKey = vigenereKey;
        }

        public List<char> Decrypt(List<char> cipher)
        {
            var result = new List<char>();
            int groupLength = vigenereKey.Length;

            for (int i = 0; i < cipher.Count; i++)
            {
                var _ = cipher[i] - vigenereKey[i % groupLength];
                result.Add((char)((_ % m + m) % m));
            }

            return result;
        }

        public List<char> Encrypt(List<char> plain)
        {
            var result = new List<char>();
            int groupLength = vigenereKey.Length;

            for (int i = 0; i < plain.Count; i++)
            {
                var _ = plain[i] + vigenereKey[i % groupLength];
                result.Add((char)(_ % m));
            }

            return result;
        }
    }
}
