using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.Cipher
{
    public abstract class CipherAbstract
    {
        /// <summary>
        /// 加密算法的名称
        /// </summary>
        protected static string name;

        protected CipherAbstract(string name) => CipherAbstract.name = name;
    }
}
