using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Admin.XXCommon
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class RsaHelper
    {
        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>32位md5值</returns>
        public static string MD5(string str)
        {
            string encryptStr = "";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            //加密后是字节类型数组，注意编码格式
            byte[] bts = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < bts.Length; i++)
            {
                encryptStr = encryptStr + bts[i].ToString("x2");
            }
            return encryptStr;
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="type">type=32为32位加密，type=64为64位加密</param>
        /// <returns>加密后的md5值</returns>
        public static string MD5(string str, int type)
        {
            string encryptStr = "";
            if (type == 32)
            {
                encryptStr = MD5(str);
            }
            if (type == 64)
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] bts = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                encryptStr = Convert.ToBase64String(bts);
            }
            return encryptStr;
        }



    }
}