using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace Admin.XXCommon
{
    /// <summary>
    /// 小说帮助类
    /// </summary>
    public class FictionHelper
    {

        public static string ZH(int pageIndex)
        {
            //FictionHelper.ZH("");
            string urlinit = "http://book.zongheng.com/store/c0/c0/b0/u0/p"; //
            string requestUrl = "";
            //创建xml
            XmlDocument xml = new XmlDocument();
            //添加节点
            XmlElement root = xml.CreateElement("root");

            for (int i = 1; i <= pageIndex; i++)
            {
                requestUrl = urlinit + i.ToString() + "/v9/s9/t0/u0/i1/ALL.html";
                string requestHtml = ZHRequestWeb(requestUrl);
                HtmlNodeCollection dealWith = ZHGetBooks(requestHtml);
                List<XmlElement> bookList = ZHCreatebookXml(dealWith);
                foreach (XmlElement item in bookList)
                {
                    XmlNode nodeNew = xml.ImportNode(item, true);//先导入老文档中的元素
                    root.AppendChild(nodeNew);
                }
               
             
            }
            xml.AppendChild(root);
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Book\";
            string savePath = path + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            xml.Save(savePath);
            return savePath;
        }


        /// <summary>
        /// 纵横--获取书本html
        /// </summary>
        /// <param name="html"></param>
        public static HtmlNodeCollection ZHGetBooks(string html)
        {
            var webDoc = new HtmlDocument();
            webDoc.LoadHtml(html);
            var getXpath = "//div[@class='bookbox fr']|//div[@class='bookbox fl']";
            return webDoc.DocumentNode.SelectNodes(getXpath);
            
        }
        /// <summary>
        /// 纵横--获取访问地址的html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ZHRequestWeb(string url)
        {
            string webUrl = url;
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(webUrl);
            StreamReader reader = new StreamReader(stream);           
            return reader.ReadToEnd();
        }
        /// <summary>
        /// 纵横--处理html，生成xml
        /// </summary>
        /// <param name="nodes"></param>
        public static List<XmlElement> ZHCreatebookXml(HtmlNodeCollection nodes)
        {
            XmlDocument xml = new XmlDocument();
            //XmlElement node = xml.CreateElement("node");//插入一个book节点 
            List<XmlElement> bookList = new List<XmlElement>();
            for (int i = 0; i < nodes.Count; i++)
            {
                XmlElement book = xml.CreateElement("book");//插入一个book节点 

                //创建模板
                var doc = new HtmlDocument();
                //载入html
                doc.LoadHtml(nodes[i].InnerHtml);
                //获取图片路径
                string bookimgSrc = doc.DocumentNode.SelectSingleNode("/div[1]/a[1]/img[1]").GetAttributeValue("src","");
                //获取书名
                string booName = doc.DocumentNode.SelectSingleNode("/div[2]/div[1]/a[1]").InnerText;
                //作者
                string bookAuther = doc.DocumentNode.SelectSingleNode("/div[2]/div[2]/a[1]").InnerText;
                //类型
                string bookType = doc.DocumentNode.SelectSingleNode("/div[2]/div[2]/a[2]").InnerText;
                //连载完本
                string bookWriteStatus = doc.DocumentNode.SelectSingleNode("/div[2]/div[2]/span[1]").InnerText;
                bookWriteStatus = bookWriteStatus.Trim();
                //简介
                string bookSynopsis = doc.DocumentNode.SelectSingleNode("/div[2]/div[3]").InnerText;
                //最新章节
                string newChapterName = doc.DocumentNode.SelectSingleNode("/div[2]/div[4]/a").InnerText;

                XmlElement xml_img = xml.CreateElement("img");
                xml_img.InnerText = bookimgSrc;
                XmlElement xml_bookName = xml.CreateElement("bookName");
                xml_bookName.InnerText = booName;
                XmlElement xml_bookAuther = xml.CreateElement("bookAuther");
                xml_bookAuther.InnerText = bookAuther;
                XmlElement xml_bookType = xml.CreateElement("bookType");
                xml_bookType.InnerText = bookType;
                XmlElement xml_bookWriteStatus = xml.CreateElement("bookWriteStatus");
                xml_bookWriteStatus.InnerText = bookWriteStatus;
                XmlElement xml_bookSynopsis = xml.CreateElement("bookSynopsis");
                xml_bookSynopsis.InnerText = bookSynopsis;
                XmlElement xml_newChapterName = xml.CreateElement("newChapterName");
                xml_newChapterName.InnerText = newChapterName;
                book.AppendChild(xml_img);
                book.AppendChild(xml_bookName);
                book.AppendChild(xml_bookAuther);
                book.AppendChild(xml_bookType);
                book.AppendChild(xml_bookWriteStatus);
                book.AppendChild(xml_bookSynopsis);
                book.AppendChild(xml_newChapterName);
                
                bookList.Add(book);
            }
            return bookList;
        }
        

    }
}