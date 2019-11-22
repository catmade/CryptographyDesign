using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesign.utils
{
    /// <summary>
    /// 有限域下的整型矩阵
    /// </summary>
    public class MatrixIntGF26
    {
        #region 属性
        private readonly double[,] elements;
        private readonly int row;
        private readonly int column;

        /// <summary>
        /// 限定计算为模运算，默认为模1
        /// </summary>
        private static int mod = 26;

        /// <summary>
        /// 行列式
        /// </summary>
        private readonly double determinant;

        /// <summary>
        /// 行列式的逆元
        /// </summary>
        private readonly int detInverse = -1;
        #endregion

        public MatrixIntGF26(int[,] elements)
        {
            this.row = elements.GetLength(0);
            this.column = elements.GetLength(1);
            this.elements = new double[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    this.elements[i, j] = elements[i, j];
                }
            }
            // A的逆 = A的伴随式 / A的行列式
            //        = A的伴随式 × A的行列式的逆元
            var matrix = CreateMatrix.DenseOfArray(this.elements);
            determinant = matrix.Determinant();     // 行列式
            var _ = Mod(SolveDouble(determinant));
            if (InverseNum.ContainsKey(_))
            {
                detInverse = InverseNum[_];
            }
            
        }

        /// <summary>
        /// 将double矩阵转化成int矩阵，注意精度
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[,] ToIntMatrix(Matrix<double> matrix)
        {
            var result = new int[matrix.RowCount, matrix.ColumnCount];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    result[i, j] = SolveDouble(matrix[i, j]);
                }
            }

            return result;
        }

        #region 计算方法

        /// <summary>
        /// 两个矩阵相乘
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public MatrixIntGF26 MultifyMod(MatrixIntGF26 b)
        {
            if (this.column != b.row)
            {
                throw new Exception($"{this.row}行{this.column}列和{b.row}行{b.column}列的两个矩阵无法进行计算");
            }

            var result = new int[this.row, b.column];
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < this.column; k++)
                    {
                        temp += this.elements[i, k] * b.elements[k, j];
                    }
                    result[i, j] = Mod(SolveDouble(temp));
                }
            }

            return new MatrixIntGF26(result);
        }

        /// <summary>
        /// 向量和矩阵相乘
        /// </summary>
        /// <param name="vector">向量</param>
        /// <param name="matrix">矩阵</param>
        /// <returns>乘积</returns>
        public static char[] MultiplyMod26(char[] vector, MatrixIntGF26 matrix)
        {
            if (vector.Length != matrix.row)
            {
                throw new Exception("无法进行乘法运算，向量的维度和矩阵的行数不相等");
            }
            var result = new char[vector.Length];

            double temp;
            for (int i = 0; i < result.Length; i++)
            {
                temp = 0;
                for (int j = 0; j < matrix.column; j++)
                {
                    temp += vector[j] * matrix.elements[j, i];
                }

                result[i] = (char)Mod(SolveDouble(temp));
            }

            return result;
        }

        /// <summary>
        /// 求矩阵的逆
        /// </summary>
        /// <returns></returns>
        public MatrixIntGF26 Inverse()
        {
            if (detInverse == -1)
            {
                throw new Exception("希尔密码的加密矩阵无法求出其在有限域内的逆矩阵");
            }

            // A的逆 = A的伴随式 / A的行列式
            //        = A的伴随式 × A的行列式的逆元
            var matrix = CreateMatrix.DenseOfArray(elements);
            var inverse = matrix.Inverse();             // 逆矩阵
            var adjoint = inverse * determinant;        // 伴随矩阵

            // 将矩阵化为整数
            var adjointInt = new int[row, column];
            adjointInt = ToIntMatrix(adjoint);

            // 再求矩阵的有限域下的逆
            var result = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    result[i, j] = Mod(adjointInt[i, j] * detInverse);
                }
            }

            return new MatrixIntGF26(result);
        }

        /// <summary>
        /// 求一个数模 m 后的正数值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Mod(int n)
        {
            return (n % mod + mod) % mod;
        }

        #region mod 下求 a 的逆元

        private static Dictionary<int, int> inverseNum;

        private static Dictionary<int, int> InverseNum
        {
            get
            {
                if (inverseNum == null)
                {
                    inverseNum = new Dictionary<int, int>();
                    inverseNum.Add(1, 1);
                    inverseNum.Add(3, 9);
                    inverseNum.Add(5, 21);
                    inverseNum.Add(7, 15);
                    inverseNum.Add(9, 3);
                    inverseNum.Add(11, 19);
                    inverseNum.Add(15, 7);
                    inverseNum.Add(17, 23);
                    inverseNum.Add(19, 11);
                    inverseNum.Add(21, 5);
                    inverseNum.Add(23, 17);
                    inverseNum.Add(25, 25);
                }
                return inverseNum;
            }
        }
        #endregion

        #endregion

        #region 判断

        /// <summary>
        /// 判断矩阵是否有逆
        /// </summary>
        /// <returns></returns>
        public bool HasInverse()
        {
            if (row != column)
            {
                return false;
            }

            // 如果行列式不为0，且逆元存在，说明可以计算逆矩阵
            if(determinant == 0)
            {
                return false;
            }

            if(detInverse == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断矩阵是否是单位矩阵
        /// </summary>
        /// <returns></returns>
        public bool IsUnit()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == j && elements[i, j] != 1)
                    {
                        return false;
                    }

                    if (i != j && elements[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 数据处理

        /// <summary>
        /// 在一定精度下，将double 转成int，
        /// </summary>
        /// <param name="d">数</param>
        /// <returns></returns>
        private static int SolveDouble(double d)
        {
            double e = 1.0E-2;  // 精度
            int sign = d >= 0 ? 1 : -1; // d的正负

            d = Math.Abs(d);    // d取绝对值
            // 2.999 = 3，2.001 = 2
            int integer = (int)d;       // 整数位
            double ddd = d - integer;   // 小数位
            if (ddd + e >= 1)
            {
                return sign * (integer + 1);
            }

            if (ddd - e < 0)
            {
                return sign * integer;
            }

            throw new Exception("精度过高，转换成整数时数据差错过大");
        }
        #endregion

        private void Printf(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Debug.Write(matrix[i, j] + "  ");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
        }
    }
}
