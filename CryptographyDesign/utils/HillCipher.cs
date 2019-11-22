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
        /// 分组数据不够时填充的字符
        /// </summary>
        private const char Append_Char = (char)0;

        /// <summary>
        /// 终结符，类似于转义符号“\”，如果需要输入该符号的话，需要连续输入两个
        /// </summary>
        private const char Transfer_Char = (char)25;

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
            var _ = CreateMatrix.DenseOfArray(ds);
            this.DKEY = (_.Inverse() * _.Determinant()).ToArray();
            this.DKEY = SolveDouble(this.DKEY);
            this.groupLength = ekey.GetLength(0);   // 如果执行到这里，已经说明矩阵是方阵
        }

        public List<char> Decrypt(List<char> cipher)
        {
            if (cipher.Count % groupLength != 0)
            {
                throw new FormatException("密文的格式出错，请检查是否缺失数据");
            }

            // 解密
            int groupNums = cipher.Count / groupLength;   // 总分组数
            List<char> result = new List<char>();   // 结果
            for (int i = 0; i < groupNums; i++)
            {
                // 使用加密矩阵将分组解密，然后添加到结果中
                result.AddRange(MultiplyMod26(cipher.GetRange(i * groupLength, groupLength).ToArray(), DKEY));
            }

            // 去冗余，去除终结符之后的数据
            var index = result.LastIndexOf(Transfer_Char);
            if(index == -1)
            {
                //throw new Exception("数据出错，或者数据和希尔密码的密钥不匹配");
            }
            result.RemoveRange(index, result.Count - index);

            // 合并连续的两个终结符
            for (int i = 1; i < result.Count; i++)
            {
                if(result[i] == Transfer_Char)
                {
                    if (result[i - 1] == Transfer_Char)
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            return result;
        }

        public List<char> Encrypt(List<char> plain)
        {
            // 拷贝plain
            var copy = new List<char>();
            for (int i = 0; i < plain.Count; i++)
            {
                copy.Add(plain[i]);
            }

            // 将终结符转义，即将一个终结符换成两个连续的终结符
            for (int i = 0; i < copy.Count; i++)
            {
                if(copy[i] == Transfer_Char)
                {
                    copy.Insert(i, Transfer_Char);
                    i++;
                }
            }

            // 在数据的最后加上终结符
            copy.Add(Transfer_Char);

            // 检查数据总长度，如果最后一组数量不够，需要填充数据
            int appendLength = copy.Count % groupLength;// 填充数
            if(appendLength != 0)
            {
                appendLength = groupLength - appendLength;
            }

            for (int i = 0; i < appendLength; i++)
            {
                copy.Add(Append_Char);
            }

            int groupNums = copy.Count / groupLength + ((copy.Count % groupLength) == 0 ? 0 : 1);   // 总分组数

            List<char> result = new List<char>();   // 结果
            for (int i = 0; i < groupNums; i++)
            {
                // 使用加密矩阵将分组加密，然后添加到结果中
                result.AddRange(MultiplyMod26(copy.GetRange(i * groupLength, groupLength).ToArray(), EKEY));
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

                // 精确化
                temp = (int)(temp + e);

                result[i] = (char)(((int)temp) % 26); 
            }

            return result;
        }

        /// <summary>
        /// 将 double 转成整数，并且mod 26
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private double[,] SolveDouble(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // 精确化
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] = (int)(matrix[i, j] + e);
                    }
                    else
                    {
                        matrix[i, j] = (int)(matrix[i, j] - e);
                    }

                    // 求余
                    matrix[i, j] %= 26;

                    // 余数转正数
                    if(matrix[i, j] < 0)
                    {
                        matrix[i, j] += 26;
                    }
                }
            }
            return matrix;
        }
    }

}
