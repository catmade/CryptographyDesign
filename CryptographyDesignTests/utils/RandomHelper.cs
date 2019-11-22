using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesignTests.utils
{
    static class RandomHelper
    {
        private static int[] aas = new int[] { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };

        /// <summary>
        /// 获得随机明文
        /// </summary>
        /// <returns></returns>
        public static List<char> GetPlain()
        {
            int maxGroupNum = 100;    // 明文最大长度
            int minGroupNum = 1;      // 明文最小长度

            Random random = new Random();
            
            // 随机生成测试明文
            List<char> result = new List<char>();       // 明文
            int length = random.Next(minGroupNum, maxGroupNum) * 2;
            for (int j = 0; j < length; j++)
            {
                result.Add((char)random.Next(0, 25));
            }

            return result;
        }

        public static string GetString()
        {
            int maxGroupNum = 100;    // 明文最大长度
            int minGroupNum = 1;      // 明文最小长度

            Random random = new Random();

            // 随机生成测试明文
            StringBuilder builder = new StringBuilder();       // 明文
            int length = random.Next(minGroupNum, maxGroupNum) * 2;
            for (int j = 0; j < length; j++)
            {
                builder.Append((char)random.Next(0, 25));
            }

            return builder.ToString();
        }

        public static int GetAffineKeyA()
        {
            Random random = new Random();
            return aas[random.Next(0, aas.Length - 1)];
        }

        public static int GetAffineKeyB()
        {
            Random random = new Random();
            return random.Next(0, 25);
        }

        public static int[,] GetHillMatrix()
        {
            Random random = new Random();
            int rank = random.Next(5, 10); // 矩阵的阶数
            double[,] vs = new double[rank, rank];
            while (true)
            {
                for (int i = 0; i < rank; i++)
                {
                    for (int j = 0; j < rank; j++)
                    {
                        vs[i, j] = random.Next(1, 25);
                    }
                }
                // 如果矩阵行列式不为 0, 说明有逆矩阵，则跳出循环
                if (CreateMatrix.DenseOfArray(vs).Determinant() != 0)
                {
                    break;
                }
            }

            int[,] result = new int[vs.GetLength(0),vs.GetLength(1)];
            for (int i = 0; i < vs.GetLength(0); i++)
            {
                for (int j = 0; j < vs.GetLength(1); j++)
                {
                    result[i, j] = (int)vs[i, j];
                }
            }

            return result;
        }

        
    }
}
