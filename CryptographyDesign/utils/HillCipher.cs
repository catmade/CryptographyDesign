using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
        private readonly MatrixIntGF26 EKEY;

        /// <summary>
        /// 解密密钥
        /// </summary>
        private readonly MatrixIntGF26 DKEY;

        /// <summary>
        /// 分组长度
        /// </summary>
        private readonly int groupLength;

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
            this.EKEY = new MatrixIntGF26(ekey);
            if (!this.EKEY.HasInverse())
            {
                throw new Exception("加密矩阵无法在有限域内求得逆矩阵");
            }
            this.DKEY = EKEY.Inverse();
            this.groupLength = ekey.GetLength(0);   // 如果执行到这里，已经说明矩阵是方阵

            // TODO Delete
            //Debug.WriteLine($"{EKEY.ToString()}{System.Environment.NewLine}" +
            //    $"x{System.Environment.NewLine}{DKEY.ToString()}{System.Environment.NewLine}" +
            //    $"={System.Environment.NewLine}{EKEY.MultifyMod(DKEY)}");
        }

        public List<char> Decrypt(List<char> cipher)
        {
            // TODO Delete
            //PrintList(cipher, "[解密前]");

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
                result.AddRange(MatrixIntGF26.MultiplyMod26(cipher.GetRange(i * groupLength, groupLength).ToArray(), DKEY));
            }

            // TODO Delete
            //PrintList(result, "[解密后]");

            // 去冗余，去除终结符之后的数据
            var index = result.LastIndexOf(Transfer_Char);
            if (index == -1)
            {
                throw new Exception("数据出错，或者数据和希尔密码的密钥不匹配");
            }
            result.RemoveRange(index, result.Count - index);

            // 合并连续的两个终结符
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i] == Transfer_Char)
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
                if (copy[i] == Transfer_Char)
                {
                    copy.Insert(i, Transfer_Char);
                    i++;
                }
            }

            // 在数据的最后加上终结符
            copy.Add(Transfer_Char);

            // 检查数据总长度，如果最后一组数量不够，需要填充数据
            int appendLength = copy.Count % groupLength;// 填充数
            if (appendLength != 0)
            {
                appendLength = groupLength - appendLength;
            }

            for (int i = 0; i < appendLength; i++)
            {
                copy.Add(Append_Char);
            }

            // TODO Delete
            //PrintList(copy, "[加密前]");

            int groupNums = copy.Count / groupLength + ((copy.Count % groupLength) == 0 ? 0 : 1);   // 总分组数

            List<char> result = new List<char>();   // 结果
            for (int i = 0; i < groupNums; i++)
            {
                // 使用加密矩阵将分组加密，然后添加到结果中
                result.AddRange(MatrixIntGF26.MultiplyMod26(copy.GetRange(i * groupLength, groupLength).ToArray(), EKEY));
            }

            // TODO Delete
            //PrintList(result, "[加密后]");

            return result;
        }

        // TODO Delete
        //void PrintList(List<char> a, string title)
        //{
        //    Debug.WriteLine(title);
        //    Debug.Write("字符序号：");
        //    for (int i = 0; i < a.Count; i++)
        //    {
        //        Debug.Write(((int)a[i]).ToString().PadLeft(2, '0'));
        //        Debug.Write(" ");
        //    }
        //    Debug.Write("\n字符序列：");
        //    Debug.WriteLine(NumListToString(a));
        //    Debug.WriteLine("");
        //}

        // TODO Delete
        //string NumListToString(List<char> list)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    // 将List<char> 转成string
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        builder.Append((char)('a' + list[i]));
        //    }

        //    return builder.ToString();
        //}

    }

}
