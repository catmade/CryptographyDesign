using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 仿射密码 e(x) = (ax + b) mod 26
    /// </summary>
    class AffineCipher : ICipher<List<char>, List<char>>
    {
        private int a;

        private int b;

        private int mod;

        public AffineCipher(int a, int b, int mod)
        {

        }

        public List<char> Decrypt(List<char> cipher)
        {
            throw new NotImplementedException();
        }

        public List<char> Encrypt(List<char> plain)
        {
            throw new NotImplementedException();
        }
    }
}
