using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDesignTests.utils
{
    static class RandomHelper
    {
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
    }
}
