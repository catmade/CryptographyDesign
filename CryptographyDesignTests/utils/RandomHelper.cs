using CryptographyDesign.utils;
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
        public static List<char> GetCharList()
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

        public static int[] GetVigenereKey()
        {
            Random random = new Random();
            int[] vigenereKm = new int[random.Next(3, 15)];
            for (int i = 0; i < vigenereKm.Length; i++)
            {
                vigenereKm[i] = random.Next(0, 25);
            }

            return vigenereKm;
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
                builder.Append((char)random.Next('a', 'z'));
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
            return random.Next(-25, 25);
        }

        public static int[,] GetHillMatrix()
        {
            Random random = new Random();
            int rank = random.Next(5, 10); // 矩阵的阶数
            int[,] vs = new int[rank, rank];
            while (true)
            {
                for (int i = 0; i < rank; i++)
                {
                    for (int j = 0; j < rank; j++)
                    {
                        vs[i, j] = random.Next(1, 25);
                    }
                }
                if (new MatrixIntGF26(vs).HasInverse())
                {
                    break;
                }
            }

            return vs;
        }

        
    }
}
