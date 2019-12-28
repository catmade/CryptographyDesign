using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.CipherKey
{
    [Serializable]
    public class HillCipherKey
    {
        private int[,] HillMatrix { get; set; }

        public HillCipherKey(int[,] matrix)
        {
            HillMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    HillMatrix[i, j] = matrix[i, j];
                }
            }
        }
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
