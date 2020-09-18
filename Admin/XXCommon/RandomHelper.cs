using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Admin.XXCommon
{
    /// <summary>
    /// 随机帮助类
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 0-9a-zA-Z 字符串
        /// </summary>
        private static char[] constant =
        {
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        /// <summary>
        /// 0-9a-zA-Z随机生成指定长度的字符串
        /// </summary>
        /// <param name="CreaterLength">生成的长度</param>
        /// <returns></returns>
        public static string CreateRandomStr(int CreaterLength)
        {
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < CreaterLength; i++)
            {
                sb.Append(constant[rd.Next(constant.Length)]);
            }
            return sb.ToString();
        }
    }
}