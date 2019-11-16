using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Plain">明文类型</typeparam>
    /// <typeparam name="Cipher">密文类型</typeparam>
    interface ICipher<Plain, Cipher>
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        Cipher Encrypt(Plain plain);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns></returns>
        Plain Decrypt(Cipher cipher);
    }
}
