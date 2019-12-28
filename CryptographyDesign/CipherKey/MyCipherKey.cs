using Newtonsoft.Json;
using System;

namespace CryptographyDesign.CipherKey
{
    [Serializable]
    public class MyCipherKeys
    {
        /// <summary>
        /// 维吉尼亚密码
        /// </summary>
        [JsonProperty]
        public VigenereCipherKey VigenereKey { get; set; }

        /// <summary>
        /// 仿射密码
        /// </summary>
        [JsonProperty]
        public AffineCipherKey AffineKey { get; set; }

        /// <summary>
        /// 希尔密码
        /// </summary>
        [JsonProperty]
        public HillCipherKey HillMatrix { get; set; }

        /// <summary>
        /// 判断密钥格式是否正确
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="message">信息，如果不正确，则返回错误信息</param>
        /// <param name="sender">信息的来源，显示信息是从哪个类中返回的</param>
        /// <returns>是否正确</returns>
        public static bool IsKeySuitable(out string message, out string sender, params object[] key)
        {
            sender = "组合加密密钥";
            message = "suitable";

            if (key == null || key.Length != 3)
            {
                message = "密钥不能为空，或者密钥数目错误";
                return false;
            }

            var types = new Type[3];
            types[0] = typeof(VigenereCipherKey);
            types[1] = typeof(VigenereCipherKey);
            types[2] = typeof(VigenereCipherKey);

            foreach (var item in key)
            {
                // 判断密钥是否符合三种密钥中的一种
                for (int i = 0; i < types.Length; i++)
                {
                    Type type = types[i];
                    if (typeof(VigenereCipherKey) == item.GetType())
                    {
                        if (!VigenereCipherKey.IsKeySuitable(out message, out sender, item))
                        {
                            return false;
                        }
                        break;  // 如果符合，就跳出本循环
                    }
                    else if (i == types.Length - 1) // 如果item不是上诉三种密钥，格式错误
                    {
                        sender = "组合加密密钥";
                        message = "密钥格式错误";
                        return false;
                    }
                }


            }

            return true;
        }
    }
}
