using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;
using XXModels;

namespace XXData
{
    public class DAL_Fiction
    {
        /// <summary>
        /// 获取全部小说分类
        /// </summary>
        /// <returns></returns>
        public List<FictionType> GetFictionTypes()
        {
            string sql = $" select * from XX_FictionType";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<FictionType>.ConverModel(dt);
        }
        /// <summary>
        /// 添加小说分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddFictionType(string name, int type)
        {
            string sql = $" insert into XX_FictionType(name,type)values('{name}',{type})";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 删除小说分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteFictionType(int id)
        {
            string sql = $"   delete XX_FictionType where id= {id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 根据Id获取小说分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FictionType GetFictionTypeById(int id)
        {
            string sql = $"select * from XX_FictionType where id={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<FictionType>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 更改小说分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int EditFictionType(int id,string name,int type)
        {
            string sql = $"update XX_FictionType set name='{name}',type={type} where id ={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 查询小说列表
        /// </summary>
        /// <param name="conditionStr"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetAllFictions(string conditionStr,int pageSize,int pageIndex)
        {
            string sql = @"select top {0}
                        (select count(*)  from XX_Fiction where 1 = 1 {1}) as total,
                        *from
                        (select ROW_NUMBER() over(order by id) as row, *from XX_Fiction u where 1 = 1 {2} ) XX_Fiction
                          where row between {3} and {4}";
            sql = string.Format(sql, pageSize, conditionStr, conditionStr, (pageIndex - 1) * pageSize, pageIndex * pageSize);
            return DBhelper.ExecuteDataTable(sql);
           
        }
        /// <summary>
        /// 删除小说
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteFiction(int id)
        {
            string sql = $"  delete XX_Fiction where id ={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取单本小说信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Fiction FictionById(int id)
        {
            string sql = $"select * from XX_Fiction where id ={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Fiction>.DtReturnFirst(dt);
        }

        /// <summary>
        /// 获取小说的章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Catalog> GetCatalogs(int id)
        {
            string sql = $"select * from XX_Catalog where fictionId={id} order by id ";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Catalog>.ConverModel(dt);
        }
        /// <summary>
        /// 保存小说
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveFiction(Fiction model)
        {
            string sql = $"  insert into XX_Fiction(ImgSrc,BookName,Synopsis,Book_Author,Book_Classify,Book_Status)values('{model.ImgSrc}','{model.BookName}','{model.Synopsis}','{model.Book_Author}','{model.Book_Classify}','{model.Book_Status}')";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 判断小说是否已存在
        /// </summary>
        /// <param name="bookName">书名</param>
        /// <param name="bookAuthor">作者</param>
        /// <returns></returns>
        public bool IsSaveFiction(string bookName,string bookAuthor)
        {
            string sql = $" select count(*) as count from XX_Fiction where BookName='{bookName}' and Book_Author='{bookAuthor}'";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            var count = dt.Rows[0]["count"];
            return Convert.ToInt32(count) == 0 ? true : false; ;
        }
        /// <summary>
        /// 获取推荐的小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetRecommend(int num,string str)
        {
            string sql = $"select top {num} * from XX_fiction {str}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Fiction>.ConverModel(dt);
        }
        /// <summary>
        /// 获取书库小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetMoreBook(string str)
        {
            string sql = $"select  * from XX_fiction {str}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Fiction>.ConverModel(dt);
        }


        public List<FictionId> GetFictionIds()
        {
            string sql = "select   f.id from XX_fiction f intersect select c.fictionId from XX_Catalog c  order by f.id ";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<FictionId>.ConverModel(dt);
        }
        /// <summary>
        /// 获取最新章节的id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Catalog GetCatalogNewest(int id)
        {
            string sql = $"  select top 1  *  from XX_Catalog where fictionId = {id} order by id desc";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Catalog>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 根据id获取章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ChapterContent GetChapterContentById(int id)
        {
            string sql = $"select * from XX_ChapterContent where id = {id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<ChapterContent>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 内容页需要的类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ReportChapterModel> GetRPModel(int id)
        {
            string sql = $"  select c.id as muluId,c.name as title,cc.id as chapterId  from XX_Catalog c left join XX_ChapterContent cc on cc.catalogId=c.id  where c.fictionId={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<ReportChapterModel>.ConverModel(dt);
        }
        /// <summary>
        /// 分页查询目录
        /// </summary>
        /// <param name="str">条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public DataTable GetCatalogsPage(string str,int start,int end, string srotTwo)
        {
            string sql = @"
                select * from
              (select ROW_NUMBER()over(order by c.id  ) as row,count(1)over()as total,
			  c.id,c.fictionId,c.name,cc.id as ccid  from XX_Catalog c 
               left join XX_ChapterContent cc on cc.catalogId = c.id where 1=1  {0}
               ) c where c.row between {1} and {2} {3} ";
            sql = string.Format(sql, str, start, end,  srotTwo);
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取男生小说
        /// </summary>
        /// <returns></returns>
        public List<FictionId> BoyFictions(string str)
        {
            string sql = $"  select   id from XX_fiction f where f.Book_Classify='{str}' intersect select c.fictionId from XX_Catalog  c   order by f.id ";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<FictionId>.ConverModel(dt);
        }
        /// <summary>
        /// 增加小说点击次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddFictionClickNum(int id)
        {
            string sql = $"update XX_Fiction set clickNum = clickNum+1 where id={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取热门小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetHotFictions()
        {
            string sql = "select top 6 * from XX_Fiction order by clickNum desc";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Fiction>.ConverModel(dt);
        }
        /// <summary>
        /// 查找小说
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Fiction> SearchFition(string str)
        {
            string sql = $"select * from XX_Fiction f left join (select DISTINCT	fictionId from	XX_Catalog ) b  on f.id = b.fictionId where f.BookName like '%{str}%' and b.fictionId is not null";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Fiction>.ConverModel(dt);
        }
        /// <summary>
        /// 图书库小数分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetFictionsPage(string where,int pageSize,int pageIndex)
        {
            string sql = @" select top {0} * from
             (select 
             (select count(*)  from XX_Fiction f 
              left join 
              (select DISTINCT	fictionId from	XX_Catalog ) b  
              on f.id = b.fictionId where b.fictionId is not null ) as total,

             *,ROW_NUMBER() over(order by f.id) as row
              from XX_Fiction f 
              left join (select DISTINCT	fictionId from	XX_Catalog ) b   on f.id = b.fictionId 
            where b.fictionId is not null {1}  ) h where row between {2} and {3}";
            sql = string.Format(sql, pageSize, where, (pageIndex - 1) * pageSize, pageIndex * pageSize);
            return DBhelper.ExecuteDataTable(sql);

        }
        /// <summary>
        /// 获取点击排行10的小说
        /// </summary>
        /// <returns></returns>
        public List<Fiction> GetClickNumTent()
        {
            string sql = "select top 10 * from XX_Fiction f left join (select DISTINCT	fictionId from	XX_Catalog ) b  on f.id = b.fictionId where f.clickNum>1 and b.fictionId is not null order by f.clickNum desc";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Fiction>.ConverModel(dt);
        }
    }
}
