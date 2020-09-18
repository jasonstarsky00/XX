
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace Admin.Collection
{
    /// <summary>
    /// 采集类配置
    /// </summary>
    public class CollectionJob: IJob
    {
        
        private static string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Book\";

        public void Execute()
        {
            //编写需要工作的内容
            //比如输出一句话
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "Collection ----执行了";
            WriteLogs(nowTime, "CollectionLog");
        }
        /// <summary>
        /// 生成日志
        /// </summary>
        /// <param name="pathFileNameStr">路径文件名及格式，如：Sql\</param>
        /// <param name="txt"></param>
        public static void WriteLogs(string txt, string pathStr = "")
        {
            try
            {
                //如果不存在目录
                if (!Directory.Exists(path + pathStr))
                {
                    Directory.CreateDirectory(path + pathStr);
                }
                //如果不存在该文件
                if (!File.Exists(path + pathStr + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
                {
                    using (FileStream fs = File.Create(path + pathStr + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
                    {
                    }
                }
                //写入内容
                using (StreamWriter sw = new StreamWriter(path + pathStr + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true, Encoding.Default))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("\r\n  yyyy-MM-dd HH:mm:ss fff")}   :   {txt}");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}