using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 小说表
    /// </summary>
    public class Fiction
    {
        public int id { get; set; }
        /// <summary>
        /// 小说封面路径
        /// </summary>
        public string ImgSrc { get; set; }
        /// <summary>
        /// 小说名
        /// </summary>
        public string BookName { get; set; }       
        /// <summary>
        /// 小说简介
        /// </summary>
        public string Synopsis { get; set; }
        /// <summary>
        /// 小说作者
        /// </summary>
        public string Book_Author { get; set; }        
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Book_Classify { get; set; }
        /// <summary>
        /// 小说状态：连载、完本
        /// </summary>
        public string Book_Status { get; set; }
        /// <summary>
        /// 是否采集
        /// </summary>
        public int isCollection { get; set; }
        public int clickNum { get; set; }
    }
    /// <summary>
    /// 前端-小说简介model
    /// </summary>
    public class ReportModel
    {
        /// <summary>
        /// 小说信息
        /// </summary>
        public Fiction fiction { get; set; }
        /// <summary>
        /// 小说最新十章
        /// </summary>
        public List<Catalog> catalogs { get; set; }
        /// <summary>
        /// 最新章节
        /// </summary>
        public Catalog newestCatalog { get; set; }
    }
    /// <summary>
    /// 内容页需要的类
    /// </summary>
    public class ReportChapterModel
    {
        public int muluId { get; set; }
        public int chapterId { get; set; }
        public string title { get; set; }
    }
    /// <summary>
    /// 前端目录需要类
    /// </summary>
    public class CatalogModel
    {
        /// <summary>
        /// 总章节
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageStart { get; set; }
        public int pageEnd { get; set; }
        /// <summary>
        /// 排序---1：升序；0：降序
        /// </summary>
        public int sort { get; set; }
        public List<Catalogs> catalogs { get; set; }

    }
    /// <summary>
    /// 前端目录子类
    /// </summary>
    public class Catalogs
    {
        /// <summary>
        /// 目录id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小说id
        /// </summary>
        public int fictionId { get; set; }
        /// <summary>
        /// 章节名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 章节id
        /// </summary>
        public int ccid { get; set; }
    }
    public class FictionId
    {
        public int id { get; set; }
    }
}
