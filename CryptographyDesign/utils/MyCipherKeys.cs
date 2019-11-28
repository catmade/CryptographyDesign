using Newtonsoft.Json;
using System;

namespace CryptographyDesign.utils
{
    [Serializable]
    public class MyCipherKeys
    {
        /// <summary>
        /// int值的默认值，如果某个属性为此值，说明其值不可用
        /// </summary>
        [JsonProperty]
        public const int InvalidIntValue = int.MaxValue;

        /// <summary>
        /// 维吉尼亚密码
        /// </summary>
        [JsonProperty]
        public int[] VigenereKey { get; set; }

        [JsonProperty]
        public int AffineKeyA { get; set; } = int.MaxValue;


        [JsonProperty]
        public int AffineKeyB { get; set; } = int.MaxValue;

        /// <summary>
        /// 希尔密码
        /// </summary>
        [JsonProperty]
        public int[,] HillMatrix { get; set; }

        /// <summary>
        /// 判断是否所有的密钥是否都被初始化
        /// </summary>
        public bool AllKeysReady
        {
            get
            {
                return VigenereKey != null
                    && AffineKeyA != InvalidIntValue
                    && AffineKeyB != InvalidIntValue
                    && HillMatrix != null;
            }
        }
    }
}
