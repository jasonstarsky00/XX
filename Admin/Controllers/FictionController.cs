using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using XXBLL;
using XXCommon;
using XXModels;

namespace Admin.Controllers
{
    [ApiBase]
    public class FictionController : ApiController
    {
        /// <summary>
        /// 查看小说分类数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Fiction/FictionTypeList")]
        public IHttpActionResult FictionTypeList()
        {
            int code = 100;
            string msg = "获取失败";
            List<FictionType> listFictionType = BLL_Fiction.Instance.GetFictionTypes();
            if (listFictionType.Count > 0&& listFictionType!=null)
            {
                 code = 200;
                 msg = "获取成功";
            }
            return Json(new { code = code, msg = msg, data = new { listFictionType = listFictionType } });
        }
        /// <summary>
        /// 添加小说分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Fiction/AddFictionType")]
        public IHttpActionResult AddFictionType(string name, int type)
        {
            int code = 100;
            string msg = "添加失败";
            if (!string.IsNullOrWhiteSpace(name) && type > 0)
            {
                int res = BLL_Fiction.Instance.AddFictionType(name, type);
                if (res > 0)
                {
                    code = 200;
                    msg = "添加成功";
                }
            }
            return Json(new { code = code, msg = msg});

        }
        /// <summary>
        /// 删除小说分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Fiction/DeleteFictionType")]
        public IHttpActionResult DeleteFictionType(int id = -1)
        {
            int code = 100;
            string msg = "删除失败";
            if (id>-1)
            {
                int res = BLL_Fiction.Instance.DeleteFictionType(id);
                if (res > 0)
                {
                    code = 200;
                    msg = "删除成功";
                }
            }
            return Json(new { code = code, msg = msg });
        }
        
        /// <summary>
        /// 根据id获取小说分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Fiction/GetFictionType")]
        public IHttpActionResult GetFictionType(int id=-1)
        {
            int code = 100;
            string msg = "获取失败";
            FictionType fictionType = new FictionType();
            if (id > -1)
            {
                fictionType = BLL_Fiction.Instance.GetFictionTypeById(id);
                if (fictionType.name != null)
                {
                    code = 200;
                    msg = "获取成功";
                }
            }
            return Json(new { code = code, msg = msg,data=new { fictionType = fictionType } });
        }

        /// <summary>
        /// 编辑小说分类信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Fiction/EditFictionType")]
        public IHttpActionResult EditFictionType(int id=-1,string name="",int type=-1)
        {
            int code = 100;
            string msg = "更新失败";
            if (id > -1 && type > -1)
            {
                int res = BLL_Fiction.Instance.EditFictionType(id, name, type);
                if (res > 0)
                {
                    code = 200;
                    msg = "更新成功";
                }
            }
            return Json(new { code = code, msg = msg });
        }

        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Fiction/FictionList")]
        public IHttpActionResult FictionList(string bookName="",string bookAuthor="", int pageSize=30,int pageIndex=1)
        {
            int code = 100;
            string msg = "获取失败";
            StringBuilder sb = new StringBuilder();
            if (bookName != "" && bookName != null)
            {
                sb.Append($"and BookName='{bookName}' ");
            }
            if (bookAuthor != "" && bookAuthor != null)
            {
                sb.Append($"and Book_Author='{bookAuthor}' ");
            }


            DataTable dt = BLL_Fiction.Instance.GetAllFictions(sb.ToString(), pageSize, pageIndex);
            List<Fiction> fictionList = ModelConvertHelper<Fiction>.ConverModel(dt);
            if (fictionList.Count > 0 && fictionList != null)
            {
                code = 200;
                msg = "获取成功";
            }
            return Json(new { code = code, msg = msg, data = new { total = dt.Rows.Count > 0 ? dt.Rows[0]["total"] : 0, fictionList = fictionList, pageSize= pageSize, pageIndex= pageIndex } });

        }
        /// <summary>
        /// 删除小说
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Fiction/DeleteFiction")]
        public IHttpActionResult DeleteFiction(int id=-1)
        {
            int code = 100;
            string msg = "删除失败";
            if (id > -1)
            {
                int res = BLL_Fiction.Instance.DeleteFiction(id);
                if (res >0)
                {
                    code = 200;
                    msg = "删除成功";
                }
            }
            return Json(new { code = code, msg = msg });
        }

        /// <summary>
        /// 获取单本小说信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Fiction/GetFiction")]
        public IHttpActionResult GetFiction(int id = -1)
        {
            int code = 100;
            string msg = "获取失败";
            Fiction fiction = new Fiction();
            if (id > -1)
            {
                fiction = BLL_Fiction.Instance.FictionById(id);
                if (fiction.id != 0 && fiction.id >= 0)
                {
                    code = 200;
                    msg = "获取成功";
                }
            }
            return Json(new { code = code, msg = msg, data=new { fiction= fiction } });
        }
        /// <summary>
        /// 获取小说的全部章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Fiction/GetFictionCatalog")]
        public IHttpActionResult GetFictionCatalog(int id=-1)
        {
            int code = 100;
            string msg = "获取失败";
            List<Catalog> catalogList = new List<Catalog>();
            if (id > -1)
            {
                catalogList = BLL_Fiction.Instance.GetCatalogs(id);
                if(catalogList.Count>0&& catalogList != null)
                {
                    code = 200;
                    msg = "获取成功";
                }
            }
            return Json(new { code = code, msg = msg, data = new { catalogList = catalogList } });
        }
    }
}
