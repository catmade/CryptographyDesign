using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    public class VigenereCipher : ICipher<List<char>, List<char>>
    {
        private int[] vigenereKey;

        public VigenereCipher(int[] vigenereKey)
        {
            this.vigenereKey = vigenereKey;
        }

        public List<char> Decrypt(List<char> cipher)
        {
            return cipher;
        }

        public List<char> Encrypt(List<char> plain)
        {
            return plain;
        }
    }
}
