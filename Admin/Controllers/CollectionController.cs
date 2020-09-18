using Admin.XXCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using XXBLL;
using XXModels;

namespace Admin.Controllers
{
    [ApiBase]
    public class CollectionController : ApiController
    {
        /// <summary>
        /// 采集小说生成xml文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Collection/Init")]
        public IHttpActionResult Init(string type)
        {
            int code = 100;
            string msg = "采集失败";
            string fileName = "";
            switch (type)
            {
                case "ZH":
                    fileName = FictionHelper.ZH(999);
                    break;

            }
            if (fileName != "")
            {
                code = 200;
                msg = "采集成功";
            }
            return Json(new { code = code, msg = msg, fileName= fileName });
        }
        /// <summary>
        /// 获取生成的xml文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Collection/GetFictionXml")]
        public IHttpActionResult GetFictionXml()
        {
            int code = 100;
            string msg = "获取失败";
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Book\";
            DirectoryInfo folder = new DirectoryInfo(path);
            List<string> fictionXmlNams = new List<string>();
            foreach (FileInfo item in folder.GetFiles("*.xml"))
            {
                fictionXmlNams.Add(item.Name);
            }
            if (fictionXmlNams.Count > 0)
            {
                code = 200;
                msg = "获取成功";
            }
                
            
            return Json(new { code = code, msg = msg, data=new{ fictionXmlNams = fictionXmlNams }  });
        }

        /// <summary>
        /// 读取xml文件插入小说
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Collection/InsertFiction")]
        public IHttpActionResult InsertFiction(string xmlpath)
        {
            int code = 100;
            string msg = "插入小说失败";
            HttpRequest request = System.Web.HttpContext.Current.Request;
            HttpFileCollection fileCollection = request.Files;
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Book\";
            // 判断是否有文件
            if (!string.IsNullOrWhiteSpace(xmlpath))
            {
                //获取上传 保存文件
                // // 获取文件
                // HttpPostedFile httpPostedFile = fileCollection[0];
                // string fileExtension = Path.GetExtension(httpPostedFile.FileName);// 文件扩展名
                // string fileName = Guid.NewGuid().ToString() + fileExtension;// 名称

                ////保存文件
                //string filePath = path + httpPostedFile.FileName;
                //httpPostedFile.SaveAs(filePath);


                //读取文件
                XmlDocument doc = new XmlDocument();
                doc.Load(path+ xmlpath);
                XmlNode xn = doc.SelectSingleNode("root");
                //XmlNode xn2 = xn.SelectSingleNode("node");
                // 得到根节点的所有子节点
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode item in xnl)
                {
                    XmlElement xe = (XmlElement)item;
                    //获取书名节点
                    Fiction model = new Fiction();
                    model.BookName  = item.SelectSingleNode("bookName").InnerText;
                   
                    model.Book_Author = item.SelectSingleNode("bookAuther").InnerText;
                    model.Book_Classify = item.SelectSingleNode("bookType").InnerText;
                    model.Book_Status = item.SelectSingleNode("bookWriteStatus").InnerText;
                    model.Synopsis = item.SelectSingleNode("bookSynopsis").InnerText;
                    //下载图片
                    string requestImg = item.SelectSingleNode("img").InnerText;
                    model.ImgSrc = XXHelper.DownloadImage(requestImg, path + @"\Images");
                    //根据书名、作者判断该小说是否存在
                    bool isSaveFiction = BLL_Fiction.Instance.IsSaveFiction(model.BookName, model.Book_Author);

                    if (isSaveFiction)
                    {
                        int res = BLL_Fiction.Instance.SaveFiction(model);

                    }

                    //保存到数据库
                }


                 code = 200;
                 msg = "插入小说完成";
           }
            return Json(new { code = code, msg = msg });


        }
        
        public IHttpActionResult DingShiCaiJi()
        {
            int code = 100;
            string msg = "未执行";
            string now = DateTime.Now.ToString("hh:mm:ss");
            string oneOClock = DateTime.Now.ToString("hh:mm:ss"); //凌晨1：00
            //if (now > oneOClock)
            //{
            //    code = 200;
            //    msg = "执行了";
            //}

            return Json(new { code = code, msg = msg });
        }
    }
}
