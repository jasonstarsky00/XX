using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXModels;

namespace XXBLL
{
    public class BLL_Catalog
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_Catalog Instance { get; private set; }
        //私有构造函数
        private BLL_Catalog()
        {

        }
        //静态构造函数
        static BLL_Catalog()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_Catalog();
                }
            }
        }
        private XXData.DAL_Catalog bll = new XXData.DAL_Catalog();
        /// <summary>
        /// 添加目录,返回id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCatalogreId(Catalog model)
        {
            DataTable dt = bll.AddCatalogreId(model);
            return dt.Rows[0]["id"] == null ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
        }

        /// <summary>
        /// 添加章节内容
        /// </summary>
        /// <returns></returns>
        public int AddChapterContent(int catalogId, string content)
        {
            return bll.AddChapterContent(catalogId, content);
        }
        /// <summary>
        /// 获取小说目录总数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CatalogCountByFictionid(int id)
        {
            DataTable dt = bll.CatalogCountByFictionid(id);
            return dt.Rows[0]["count"] == null ? 0 : Convert.ToInt32(dt.Rows[0]["count"]);
            
        }
        /// <summary>
        /// 获取小说目录
        /// </summary>
        /// <returns></returns>
        public List<Catalog> GetCatalogByFctionId(int id)
        {
            return bll.GetCatalogByFctionId(id);
        }
    }
}
