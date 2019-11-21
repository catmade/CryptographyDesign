using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
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
    public class HillCipher : ICipher<List<char>, List<char>>
    {
        /// <summary>
        /// 加密密钥
        /// </summary>
        private readonly double[,] EKEY;

        /// <summary>
        /// 解密密钥
        /// </summary>
        private readonly double[,] DKEY;

        /// <summary>
        /// 分组长度
        /// </summary>
        private readonly int groupLength;

        /// <summary>
        /// 精度
        /// </summary>
        private readonly double e = 1.0E-1;

        /// <summary>
        /// 分组数据不够时填充的数据
        /// </summary>
        private const char Append_Item = (char)255;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ekey">密钥，必须是可逆的方阵</param>
        public HillCipher(double[,] ekey)
        {
            this.EKEY = ekey;
            this.DKEY = CreateMatrix.DenseOfArray(ekey).Inverse().ToArray();
            this.groupLength = ekey.GetLength(0);   // 如果执行到这里，已经说明矩阵是方阵
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ekey">密钥，必须是可逆的方阵</param>
        public HillCipher(int[,] ekey)
        {
            var row = ekey.GetLength(0);
            var column = ekey.GetLength(1);
            var ds = new double[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    ds[i, j] = ekey[i, j];
                }
            }

            this.EKEY = ds;
            this.DKEY = CreateMatrix.DenseOfArray(ds).Inverse().ToArray();
            this.groupLength = ekey.GetLength(0);   // 如果执行到这里，已经说明矩阵是方阵
        }

        public List<char> Decrypt(List<char> cipher)
        {
            if (cipher.Count % groupLength != 0)
            {
                throw new FormatException("密文的格式出错，请检查是否缺失数据");
            }

            int groupNums = cipher.Count / groupLength;   // 总分组数
            List<char> result = new List<char>();   // 结果
            for (int i = 0; i < groupNums; i++)
            {
                // 使用加密矩阵将分组解密，然后添加到结果中
                result.AddRange(MultiplyMod26(cipher.GetRange(i, groupLength).ToArray(), DKEY));
            }

            return result;
        }

        public List<char> Encrypt(List<char> plain)
        {
            // 检查数据总长度，如果最后一组数量不够，需要填充数据
            int appendLength = groupLength - (plain.Count % groupLength);  // 填充数
            for (int i = 0; i < appendLength; i++)
            {
                plain.Add(Append_Item);
            }

            int groupNums = plain.Count / groupLength + plain.Count % groupLength == 0 ? 0 : 1;   // 总分组数

            List<char> result = new List<char>();   // 结果
            for (int i = 0; i < groupNums; i++)
            {
                // 使用加密矩阵将分组加密，然后添加到结果中
                result.AddRange(MultiplyMod26(plain.GetRange(i, groupLength).ToArray(), EKEY));
            }

            return result;
        }

        /// <summary>
        /// 计算向量和矩阵的模26乘积，同时根据精度，对结果进行修正
        /// </summary>
        /// <param name="vector">向量</param>
        /// <param name="matrix">矩阵</param>
        /// <returns>乘积</returns>
        private char[] MultiplyMod26(char[] vector, double[,] matrix)
        {
            if (vector.Length != matrix.GetLength(0))
            {
                throw new Exception("无法进行乘法运算，向量的维度和矩阵的行数不相等");
            }
            var result = new char[vector.Length];

            double temp;
            for (int i = 0; i < result.Length; i++)
            {
                temp = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp += vector[j] * matrix[j,i];
                }
                if (temp - (int)temp > e)
                {
                    throw new FormatException("无法解决浮点数陷阱");
                }
                result[i] = (char)(((int)(temp + 0.5)) % 26); 
            }

            return result;
        }

        /// <summary>
        /// 获取指定组的数据
        /// </summary>
        /// <param name="index">下标</param>
        /// <param name="count">长度</param>
        /// <param name="data">数据源</param>
        /// <returns></returns>
        private char[] GetRange(int index, int count, char[] data)
        {
            if (index < 0 || count < 0 || data.Length - index < count)
            {
                throw new ArgumentOutOfRangeException("获取子数组越界");
            }

            var result = new char[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = data[index + i];
            }

            return result;
        }
    }

}
