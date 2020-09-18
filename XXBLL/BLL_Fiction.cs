using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXModels;

namespace XXBLL
{
    public class BLL_Fiction
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_Fiction Instance { get; private set; }
        //私有构造函数
        private BLL_Fiction()
        {

        }
        //静态构造函数
        static BLL_Fiction()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_Fiction();
                }
            }
        }
        private XXData.DAL_Fiction bll = new XXData.DAL_Fiction();
        /// <summary>
        /// 获取全部小说分类
        /// </summary>
        /// <returns></returns>
        public List<FictionType> GetFictionTypes()
        {
            return bll.GetFictionTypes();
        }
        /// <summary>
        /// 添加小说分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddFictionType(string name, int type)
        {
            return bll.AddFictionType(name, type);
        }
        /// <summary>
        /// 删除小说分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteFictionType(int id)
        {
            return bll.DeleteFictionType(id);
        }
        /// <summary>
        /// 根据Id获取小说分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FictionType GetFictionTypeById(int id)
        {
            return bll.GetFictionTypeById(id);
        }
        /// <summary>
        /// 更改小说分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int EditFictionType(int id, string name, int type)
        {
            return bll.EditFictionType(id, name, type);
        }
        /// <summary>
        /// 查询小说列表
        /// </summary>
        /// <param name="conditionStr"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetAllFictions(string conditionStr, int pageSize, int pageIndex)
        {
            return bll.GetAllFictions(conditionStr, pageSize, pageIndex);
        }
        /// <summary>
        /// 删除小说
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteFiction(int id)
        {
            return bll.DeleteFiction(id);
        }
        /// <summary>
        /// 获取单本小说信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Fiction FictionById(int id)
        {
            return bll.FictionById(id);
        }
        /// <summary>
        /// 获取小说的章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Catalog> GetCatalogs(int id)
        {
            return bll.GetCatalogs(id);
        }
        /// <summary>
        /// 保存小说
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveFiction(Fiction model)
        {
            return bll.SaveFiction(model);
        }
        /// <summary>
        /// 判断小说是否已存在
        /// </summary>
        /// <param name="bookName">书名</param>
        /// <param name="bookAuthor">作者</param>
        /// <returns></returns>
        public bool IsSaveFiction(string bookName, string bookAuthor)
        {
            return bll.IsSaveFiction(bookName, bookAuthor);
        }
        /// <summary>
        /// 获取推荐的小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetRecommend(int num,string str)
        {
            return bll.GetRecommend(num,str);
        }
        /// <summary>
        /// 获取书库小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetMoreBook(string str)
        {
            return bll.GetMoreBook(str);
        }
        public List<FictionId> GetFictionIds()
        {
            return bll.GetFictionIds();
        }
        /// <summary>
        /// 最新章节的id
        /// </summary>
        /// <returns></returns>
        public Catalog GetCatalogNewest(int id)
        {
            return bll.GetCatalogNewest(id);
        }
        /// <summary>
        /// 根据id获取章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ChapterContent GetChapterContentById(int id)
        {
            return bll.GetChapterContentById(id);
        }
        /// <summary>
        /// 内容页需要的类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ReportChapterModel> GetRPModel(int id)
        {
            return bll.GetRPModel(id);
        }
        /// <summary>
        /// 分页查询目录
        /// </summary>
        /// <param name="str">条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public DataTable GetCatalogsPage(string str, int start, int end,string srotTwo)
        {
            return bll.GetCatalogsPage(str, start, end,  srotTwo);
        }
        /// <summary>
        /// 获取男生小说
        /// </summary>
        /// <returns></returns>
        public List<FictionId> BoyFictions(string str)
        {
            return bll.BoyFictions(str);
        }
        /// <summary>
        /// 增加小说点击次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddFictionClickNum(int id)
        {
            return bll.AddFictionClickNum(id);
        }
        /// <summary>
        /// 获取热门小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetHotFictions()
        {
            return bll.GetHotFictions();
        }
        /// <summary>
        /// 查找小说
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Fiction> SearchFition(string str)
        {
            return bll.SearchFition(str);
        }

        /// <summary>
        /// 图书库小数分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetFictionsPage(string where, int pageSize, int pageIndex)
        {
            return bll.GetFictionsPage(where, pageSize, pageIndex);
        }
        /// <summary>
        /// 获取点击排行10的小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetClickNumTent()
        {
            return bll.GetClickNumTent();
        }
    }
}
