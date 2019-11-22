﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    public class MyCipher : ICipher<string, string>
    {
        /// <summary>
        /// 符号集
        /// </summary>
        private readonly char[] Characters = new char[]
               {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
               };

        private VigenereCipher vigenereCipher;

        private AffineCipher affineCipher;

        private HillCipher hillCipher;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="vigenereKey">维吉尼亚密码密钥</param>
        /// <param name="affineKeyA">仿射密码密钥a</param>
        /// <param name="affineKeyB">仿射密码密钥b</param>
        /// <param name="hillMatrix">希尔密码加密矩阵</param>
        public MyCipher(int[] vigenereKey, int affineKeyA, int affineKeyB, int[,] hillMatrix)
        {
            this.vigenereCipher = new VigenereCipher(vigenereKey);
            this.affineCipher = new AffineCipher(affineKeyA, affineKeyB);
            this.hillCipher = new HillCipher(hillMatrix);
        }

        public string Decrypt(string cipher)
        {
            var data = cipher.ToList();
            for (int i = 0; i < data.Count; i++)
            {
                data[i] -= 'a';
            }

            var hill = this.hillCipher.Decrypt(data);

            var affine = this.affineCipher.Decrypt(hill);

            var vigenere = this.vigenereCipher.Decrypt(affine);

            StringBuilder builder = new StringBuilder();

            // 将List<char> 转成string
            for (int i = 0; i < vigenere.Count; i++)
            {
                builder.Append(Characters[vigenere[i]]);
            }

            return builder.ToString();
        }

        public string Encrypt(string plain)
        {
            var data = plain.ToList();
            for (int i = 0; i < data.Count; i++)
            {
                data[i] -= 'a';
            }

            //// 先使用维吉尼亚，再用仿射密码，再用希尔密码

            var vigenere = this.vigenereCipher.Encrypt(data);

            var affine = this.affineCipher.Encrypt(vigenere);

            var hill = this.hillCipher.Encrypt(affine);

            StringBuilder builder = new StringBuilder();

            // 将List<char> 转成string
            for (int i = 0; i < hill.Count; i++)
            {
                builder.Append(Characters[hill[i]]);
            }

            return builder.ToString();
        }
    }
}
