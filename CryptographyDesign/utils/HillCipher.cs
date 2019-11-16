using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 希尔密码
    /// </summary>
    class HillCipher : ICipher<string, List<char>>
    {
        /// <summary>
        /// 密文空间
        /// </summary>
        private readonly char[] cs = new char[]{
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        /// <summary>
        /// 加密密钥
        /// </summary>
        private readonly Matrix EKEY;

        /// <summary>
        /// 解密密钥
        /// </summary>
        private readonly Matrix DKEY;

        /// <summary>
        /// 精度
        /// </summary>
        private readonly double e = 1.0E-10;

        /// <summary>
        /// 矩阵加密
        /// </summary>
        /// <param name="ekey">密钥，必须是可逆的方阵</param>
        public HillCipher(int[,] ekey)
        {
            // 是否是方阵
            if (ekey.GetLength(0) != ekey.GetLength(1))
            {
                throw new Exception("密钥必须是方阵");
            }

            this.EKEY = new Matrix(ekey);

            // 如果不可逆，会抛出异常
            this.DKEY = EKEY.Inverse();
        }

        /// <summary>
        /// 矩阵加密
        /// </summary>
        /// <param name="ekey">密钥，必须是可逆的方阵</param>
        public HillCipher(int[][] ekey)
        {
            // 是否是方阵
            if (ekey.Length != ekey[0].Length)
            {
                throw new Exception("密钥必须是方阵");
            }

            this.EKEY = new Matrix(ekey);

            // 如果不可逆，会抛出异常
            this.DKEY = EKEY.Inverse();

            var t1 = EKEY * DKEY;
        }

        public string Decrypt(List<char> cipher)
        {
            int groupLength = EKEY.Rows;    // 分组长度
            int groupNums = cipher.Count / groupLength + cipher.Count % groupLength == 0 ? 0 : 1;   // 总分组数

            var result = new List<char>();    // 第一次处理后得到的数据
            char[] group;
            int temp;
            for (int i = 0; i < groupNums; i++)
            {
                group = cipher.GetRange(i, groupLength).ToArray();

                // 分组加密
                foreach (var item in (new Matrix(group) * DKEY)[0])
                {
                    temp = (int)item;
                    // 如果不是整数，进一法取整
                    if (Math.Abs(item - temp) > e)
                    {
                        temp += 1;
                    }
                    result.Add((char)(temp % char.MaxValue));
                }
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in result)
            {
                if (item != 0)
                {
                    builder.Append(item.ToString());
                }
            }

            return builder.ToString();
        }

        public List<char> Encrypt(string plain)
        {
            int groupLength = EKEY.Rows;    // 分组长度
            var array = plain.ToCharArray(); // 源数据
            int groupNums = array.Length / groupLength + array.Length % groupLength == 0 ? 0 : 1;   // 总分组数

            var result = new List<char>();    // 第一次处理后得到的数据
            char[] group;

            for (int i = 0; i < groupNums; i++)
            {
                group = GetGroup(i, groupLength, array);

                // 分组加密
                foreach (var item in (new Matrix(group) * EKEY)[0])
                {
                    result.Add((char)(item % char.MaxValue));
                }
            }
            return result;
        }

        /// <summary>
        /// 获取指定组的数据
        /// </summary>
        /// <param name="groupNum">组号，从0开始</param>
        /// <param name="groupLength">每个分组的长度</param>
        /// <param name="data">总数据</param>
        /// <returns></returns>
        private char[] GetGroup(int groupNum, int groupLength, char[] data)
        {
            var result = new char[groupLength];
            int beginIndex = groupLength * groupNum;
            if (beginIndex >= data.Length)
            {
                throw new IndexOutOfRangeException("下标越界");
            }

            for (int i = 0; i < groupLength; i++)
            {
                // 如果不足，则填充0
                try
                {
                    result[i] = data[i + beginIndex];
                }
                catch
                {
                    result[i] = '\0';
                }
            }

            return result;
        }
    }
}
