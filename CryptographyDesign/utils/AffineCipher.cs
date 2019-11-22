using System;
using System.Collections.Generic;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 仿射密码 e(x) = (ax + b) mod 26
    /// </summary>
    public class AffineCipher : ICipher<List<char>, List<char>>
    {
        private int a;

        private int b;

        public AffineCipher(int a, int b)
        {
            if (!IsKeyASuitable(a))
            {
                throw new Exception("仿射密码的参数a必须要与26互素数，必须为以下值中的一个：\n" +
                    "1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25");
            }
            this.a = a;
            this.b = b;
        }

        public List<char> Decrypt(List<char> cipher)
        {
            int ap = AAP[a]; // a的逆元
            for (int i = 0; i < cipher.Count; i++)
            {
                cipher[i] = (char)(((ap * (cipher[i] - b)) % 26 + 26) % 26);
            }
            return cipher;
        }

        public List<char> Encrypt(List<char> plain)
        {
            for (int i = 0; i < plain.Count; i++)
            {
                plain[i] = (char)(((a * plain[i] + b) % 26 + 26) % 26);
            }
            return plain;
        }

        private static Dictionary<int, int> aap;

        private static Dictionary<int, int> AAP
        {
            get
            {
                if (aap == null)
                {
                    aap = new Dictionary<int, int>();
                    aap.Add(1, 1);
                    aap.Add(3, 9);
                    aap.Add(5, 21);
                    aap.Add(7, 15);
                    aap.Add(9, 3);
                    aap.Add(11, 19);
                    aap.Add(15, 7);
                    aap.Add(17, 23);
                    aap.Add(19, 11);
                    aap.Add(21, 5);
                    aap.Add(23, 17);
                    aap.Add(25, 25);
                }
                return aap;
            }
        }

        private static HashSet<int> aa;

        private static HashSet<int> AA
        {
            get
            {
                if (aa == null)
                {
                    aa = new HashSet<int>();
                    aa.Add(1);
                    aa.Add(3);
                    aa.Add(5);
                    aa.Add(7);
                    aa.Add(9);
                    aa.Add(11);
                    aa.Add(15);
                    aa.Add(17);
                    aa.Add(19);
                    aa.Add(21);
                    aa.Add(23);
                    aa.Add(25);
                }
                return aa;
            }
        }

        /// <summary>
        /// 判断系数 a 是否符合要求
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsKeyASuitable(int a)
        {
            return AA.Contains(a);
        }
    }
}
