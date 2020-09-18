using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Admin.XXCommon
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 匹配a-zA-Z0-9字母或数字或下划线
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Stra_zA_Z0_9(string str)
        {

            Regex r = new Regex(@"[a-zA-Z0-9_]");
            return r.IsMatch(str);
        }
        /// <summary>
        /// 匹配a-zA-Z0-9字母或数字或下划线,6到16位
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Stra_zA_Z0_96_16(string str)
        {

            Regex r = new Regex(@"[a-zA-Z0-9_]{5,15}");
            return r.IsMatch(str);
        }
        /// <summary>
        /// 匹配包含0-9任意数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Str0_9(string str)
        {
            Regex r = new Regex(@".*[0-9]");
            return r.IsMatch(str);
        }
        /// <summary>
        /// 匹配大写或小写或下划线，至少2位
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Stra_zA_Z2More(string str)
        {
            Regex r = new Regex(@".*[a-zA-Z]{2}");
            return r.IsMatch(str);
        }

    }
}