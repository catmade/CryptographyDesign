using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign
{
    /// <summary>
    /// 约束数据
    /// </summary>
    public class DataConfig
    {
        #region 最大值和最小值限制
        /// <summary>
        /// 每个明文符号对应的最大数值
        /// </summary>
        public const int Max_Character_Value = 25;

        /// <summary>
        /// 每个明文符号对应的最小数值
        /// </summary>
        public const int Min_Character_Value = 0;

        /// <summary>
        /// 希尔密码加密矩阵中，每个数的最大值
        /// </summary>
        public const int Max_Hill_Item_Value = Max_Character_Value;

        /// <summary>
        /// 希尔密码加密矩阵中，每个数的最小值
        /// </summary>
        public const int Min_Hill_Item_Value = Min_Character_Value + 1;

        /// <summary>
        /// 维吉尼亚密码的分组密钥，每个数的最大值
        /// </summary>
        public const int Max_Vigenere_Item_Value = Max_Character_Value;

        /// <summary>
        /// 维吉尼亚密码的分组密钥，每个数的最小值
        /// </summary>
        public const int Min_Vigenere_Item_Value = Min_Character_Value;

        /// <summary>
        /// 仿射密码e(x) = (ax + b) mod m，系数a的判断方法
        /// </summary>
        public static int Is_Affine_Key_A_Values(int i)
        {
            // TODO
            return 0;
        }

        /// <summary>
        /// 仿射密码e(x) = (ax + b) mod m，系数b的最大值
        /// </summary>
        public const int Max_Affine_Key_B_Value = Max_Character_Value;

        /// <summary>
        /// 仿射密码e(x) = (ax + b) mod m，系数b的最大值
        /// </summary>
        public const int Min_Affine_Key_B_Value = Min_Character_Value;

        #endregion

        #region 正则表达式显示数据格式

        #endregion
    }
}
