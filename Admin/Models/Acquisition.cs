using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace Admin.Models
{
    public class Acquisition
    {
        private AcquisitionConfig AcquisitionConfig = null;
        private static string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"DownLoad\";
        /// <summary>
        /// 初始采集器
        /// </summary>
        /// <param name="config">采集配置信息</param>
        public Acquisition(AcquisitionConfig config)
        {
            AcquisitionConfig = config;
        }

        public void Test()
        {
           
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            WriteLogs(time + "写入", "test");
        }
        /// <summary>
        /// 自动启动执行
        /// </summary>
        public void Start()
        {
            Thread thread = new Thread(Test);
            thread.Start();
            Thread.Sleep(TimeSpan.FromSeconds(10));

            //任务完成指向其他
            string url = "http://localhost:64187/home/index";
            System.Net.HttpWebRequest myHttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse myHttpWebResponse = (System.Net.HttpWebResponse)myHttpWebRequest.GetResponse();
            System.IO.Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流

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