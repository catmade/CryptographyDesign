using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.CipherKey
{
    [Serializable]
    public class AffineCipherKey
    {
        public int AffineKeyA { get; set; } = int.MaxValue;

        public int AffineKeyB { get; set; } = int.MaxValue;

        /// <summary>
        /// 判断密钥格式是否正确
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="message">信息，如果不正确，则返回错误信息</param>
        /// <param name="sender">信息的来源，显示信息是从哪个类中返回的</param>
        /// <returns>是否正确</returns>
        public static bool IsKeySuitable(out string message, out string sender, params object[] key)
        {
            throw new NotImplementedException();
        }
    }
}
