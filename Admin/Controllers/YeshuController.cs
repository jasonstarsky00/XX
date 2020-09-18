using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using XXBLL;
using XXCommon;
using XXModels;

namespace Admin.Controllers
{
    public class YeshuController : Controller
    {
        
        /// <summary>
        /// 推荐
        /// </summary>
        /// <returns></returns>
        public ActionResult recommend()
        {
            List<Fiction> fictions = new List<Fiction>();

            List<FictionId> FictionIds = BLL_Fiction.Instance.GetFictionIds();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    sb.Append($"where id = {FictionIds[i].id}");
                }else
                {
                    sb.Append($" or id = {FictionIds[i].id}");
                }               
            }


            var model = BLL_Fiction.Instance.GetRecommend(3,sb.ToString());
            if (model != null)
            {
                fictions = model;
            }
            return Json(new { code = 200, data= fictions }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MoreBook(int num = 0,int pageSize = 10,int pageIndex=1)
        {
            int code = 100;
            string msg = "获取失败";
            int total = 0;
            StringBuilder sb = new StringBuilder();
            if (num > 0)
            {
                sb.Append($"and f.clickNum >{num}"); 
            }

            DataTable dt = BLL_Fiction.Instance.GetFictionsPage(sb.ToString(), pageSize, pageIndex);
            List<Fiction> fictions = new List<Fiction>();
            if (dt.Rows.Count > 0)
            {
                total = Convert.ToInt32(dt.Rows[0]["total"]);
                fictions= ModelConvertHelper<Fiction>.ConverModel(dt);
                code = 200;
                msg = "获取成功";
            }
            
               
            
            return Json(new { code = code,msg= msg, data = new { total=total,fictions = fictions,pageIndex=pageIndex,pageSize = pageSize } }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取小说目录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCatalogs(int id)
        {
            int code = 100;
            string msg = "获取失败";
            //小说简介信息
            Fiction fiction = BLL_Fiction.Instance.FictionById(id);
            //增加小说点击次数
            int addClickNum = BLL_Fiction.Instance.AddFictionClickNum(id);
            //前十章小说
            List<Catalog> catalogs = BLL_Catalog.Instance.GetCatalogByFctionId(id);
            //最新一章
            Catalog newEstCatalog = BLL_Fiction.Instance.GetCatalogNewest(id);
            ReportModel rp = new ReportModel
            {
                fiction = fiction,
                catalogs = catalogs,
                newestCatalog = newEstCatalog
            };
            if(newEstCatalog.id>0&& fiction.id>0 && catalogs.Count > 0&&addClickNum>0)
            {
                code = 200;
                msg = "获取成功";
            }
               
           
            return Json(new { code = code, msg = msg, data = rp }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetChapter(int id)
        {
            int code = 100;
            string msg = "获取失败";
            ChapterContent cp = new ChapterContent();
            if (id > 0)
            {
                cp = BLL_Fiction.Instance.GetChapterContentById(id);
                if (cp.id > 0)
                {
                    code = 200;
                    msg = "获取成功";
                }
            }
            return Json(new { code = code, msg = msg, data = cp }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 内容页需要的类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetRPModel(int id)
        {
            int code = 100;
            string msg = "获取失败";
            List<ReportChapterModel> model = new List<ReportChapterModel>();
            if (id > 0)
            {
                model = BLL_Fiction.Instance.GetRPModel(id);
                if (model.Count > 0)
                {
                    code = 200;
                    msg = "获取成功";
                }
            }
            return Json(new { code = code, msg = msg, data = model }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 目录页
        /// </summary>
        /// <param name="fictionid">小说id</param>
        /// <param name="pageIndex">要查询的分页</param>
        /// <param name="sort">排序：升序或降序</param>
        /// <returns></returns>GetCatalogs
        public ActionResult Catalogs(int fictionid,int start ,int end,int sort)
        {
            int code = 100;
            string msg = "获取失败";
            StringBuilder sb = new StringBuilder();
            if (fictionid > 0)
            {
                sb.Append($" and fictionId = {fictionid}");
            }
            
            string srotTwo = "";
            if (sort > 0)
            {
               
                srotTwo = "order by c.id desc";
            }

            DataTable dt = BLL_Fiction.Instance.GetCatalogsPage(sb.ToString(), start, end,srotTwo);
            int total = 0;           
            List<Catalogs> cmodel = new List<Catalogs>();
            if (dt.Rows.Count > 0)
            {
                code = 200;
                msg = "获取成功";
                total = Convert.ToInt32(dt.Rows[0]["total"]);
                cmodel = ModelConvertHelper<Catalogs>.ConverModel(dt);
            }
            else
            {

            }
            CatalogModel model = new CatalogModel
            {
                total = total,
                pageStart = start,
                pageEnd = end,
                sort = sort,
                catalogs = cmodel
            };
            return Json(new { code = code, msg = msg, data = model }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取男生小说
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBoyFictions()
        {
            int code = 100;
            string msg = "获取失败";
            List<Fiction> fictions = new List<Fiction>();
            List<FictionId> fictionIds = BLL_Fiction.Instance.BoyFictions("奇幻玄幻");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    sb.Append($"where id = {fictionIds[i].id}");
                }
                else
                {
                    sb.Append($" or id = {fictionIds[i].id}");
                }
            }
            var model = BLL_Fiction.Instance.GetRecommend(6,sb.ToString());
            if (model != null)
            {
                code = 200;
                msg = "获取成功";
                fictions = model;
            }
            return Json(new { code = code,msg=msg, data = fictions }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 热门小说
        /// </summary>
        /// <returns></returns>
        public ActionResult HotFiction()
        {
            int code = 100;
            string msg = "获取失败";
            List<Fiction> fictions = new List<Fiction>();
            var model = BLL_Fiction.Instance.GetHotFictions();
            if (model != null)
            {
                code = 200;
                msg = "获取成功";
                fictions = model;
            }
            return Json(new { code = code, msg = msg, data = fictions }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查找小说
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public ActionResult SearchFiction(string q)
        {
            int code = 100;
            string msg = "获取失败";
            List<Fiction> fictions = new List<Fiction>();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var model = BLL_Fiction.Instance.SearchFition(q);
                if (model.Count > 0)
                {
                    code = 200;
                    msg = "获取成功";
                    fictions = model;
                }
            }
           
            return Json(new { code = code, msg = msg, data = fictions }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 排行
        /// </summary>
        public ActionResult Ranking()
        {
            int code = 101;
            string msg = "获取失败";
            List<Fiction> fictions = new List<Fiction>();
            var model = BLL_Fiction.Instance.GetClickNumTent();
            if (model.Count > 0)
            {
                code = 200;
                msg = "获取成功";
                fictions = model;
            }
            return Json(new { code = code, msg = msg, data = fictions }, JsonRequestBehavior.AllowGet);
        }
    }
}