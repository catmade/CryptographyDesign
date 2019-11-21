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
    /// 整型矩阵
    /// </summary>
    public class MatrixInt
    {
        private int[,] elements;
        private int row;
        private int column;

        /// <summary>
        /// 限定计算为模运算，默认为模1
        /// </summary>
        private readonly int Mod = 1;

        public MatrixInt(int[,] elements)
        {
            this.row = elements.GetLength(0);
            this.column = elements.GetLength(1);
            if (row != column)
            {
                throw new Exception("矩阵必须为方阵");
            }
            this.elements = elements;
        }

        public MatrixInt(int[,] elements, int mod) : this(elements)
        {
            this.Mod = mod;
        }

        /// <summary>
        /// 求矩阵的逆
        /// </summary>
        /// <returns></returns>
        public MatrixInt Inverse()
        {
            var matrix = new int[row, column * 2];

            // 将矩阵复制过来
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = elements[i, j];
                }
            }

            // 在矩阵后面补充单位矩阵
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = column; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ((i == j - column) ? 1 : 0);
                }
            }

            var re = simplify(matrix);

            var result = new int[row, column];
            for (int i = 0; i < re.GetLength(0); i++)
            {
                for (int j = 0; j < re.GetLength(1); j++)
                {
                    result[i, j] = re[i, j + row];
                }
            }

            return new MatrixInt(result);
        }

        public int[,] ToIntMatrix()
        {
            return null;
        }

        /// <summary>
        /// 将矩阵化为行最简式
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[,] simplify(int[,] matrix)
        {
            int[,] result = matrix;

            int row = result.GetLength(0);
            int col = result.GetLength(1);

            // j为第i行的第j个不为0个位置
            int j = 0;

            int i1 = 0;

            // 倍率
            int rate;

            // 初步化简矩阵
            for (int i = 0; i < row; i++)
            {
                j = 0;
                while (j < col)
                {
                    if (result[i, j] != 0)
                    {
                        break;
                    }
                    j += 1;
                }
                if (j < col)
                {
                    i1 = 0;
                    while (i1 < row)
                    {
                        if (result[i1, j] != 0 && i1 != i)
                        {
                            rate = result[i, j] / result[i1, j];
                            for (int j1 = 0; j1 < col; j1++)
                            {
                                //result[i1, j1] = (result[i, j1] - result[i1, j1] * rate + 2) % Mod;
                                Debug.Write($"{result[i1, j1]} = {result[i, j1]} - {result[i1, j1]} * {rate}");
                                result[i1, j1] = result[i, j1] - result[i1, j1] * rate;
                                Debug.WriteLine($" = {result[i1, j1]}");
                            }
                        }
                        i1++;
                    }
                }
                //Printf(result);
            }

            // 判断是否可化为行最简式
            bool canBeSymlified = true;
            int[] a = new int[row];
            for (int i = 0; i < a.Length; i++)
            {
                for (int k = 0; k < row; k++)
                {
                    a[i] += result[k, i];
                }
                if (a[i] != 1)
                {
                    canBeSymlified = false;
                    break;
                }
            }
            if (!canBeSymlified)
            {
                throw new Exception("不可化为行最简式");
            }

            // 将矩阵的转换成合适的行最简式
            for (int i = 0; i < row - 1; i++)
            {
                int k;
                for (k = 0; k < row; k++)
                {
                    if (result[k, i] == 1)
                    {
                        break;
                    }
                }
                result = exchangeRow(result, i, k);
            }
            return result;
        }

        public int[,] Simplify(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            // TODO 没写完

            return null;
        }

        /// <summary>
        /// 判断矩阵是否有逆
        /// </summary>
        /// <returns></returns>
        public bool HasInverse()
        {
            for (int i = 0; i < column; i++)
            {

            }

            // 矩阵的行列式
            int D = CreateMatrix.DenseOfArray(this.elements).Determinant();

            // 如果行列式不为 0 ，则可逆
            return D != 0;
        }

        /**
         * 交换矩阵的第i行和第j行数据
         *
         * @param matrix 矩阵
         * @param i 第i行
         * @param j 第j行
         * @return 交换后的矩阵
         */
        private int[,] exchangeRow(int[,] matrix, int i, int j)
        {
            Printf(matrix);

            int temp;
            for (int k = 0; k < column; k++)
            {
                temp = matrix[i, k];
                matrix[i, k] = matrix[j, k];
                matrix[j, k] = temp;
            }

            Printf(matrix);
            return matrix;
        }

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
