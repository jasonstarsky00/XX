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
     public class DAL_Catalog
    {
        /// <summary>
        /// 添加目录,返回id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable AddCatalogreId(Catalog model)
        {
            string str = @"
	                        Declare @ca_count int
                            select @ca_count = count(*)  from XX_Catalog where fictionId = {0} and name ='{1}'
                        if @ca_count=0
                        begin
	                        insert into XX_Catalog(fictionId,name)values({2},'{3}');select @@IDENTITY AS id
                        End
                        else
                        begin
                            select  count(*) as id   from XX_Catalog where id = 101 and name = '锅碗瓢盆琵琶遇到发发打发'
                        End"
                        ;

            string sql = string.Format(str, model.fictionId,model.name, model.fictionId, model.name);
            return  DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 添加章节内容
        /// </summary>
        /// <returns></returns>
        public int AddChapterContent(int catalogId,string content)
        {
            string sql = $"insert into XX_ChapterContent(catalogId,chapterContent)values({catalogId},'{content}')";
            return  DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取小说目录总数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable CatalogCountByFictionid(int id)
        {
            string sql = $"  select count(*) as count from XX_Catalog where fictionId = {id}";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取小说目录
        /// </summary>
        /// <returns></returns>
        public List<Catalog> GetCatalogByFctionId(int id)
        {
            string sql = $" SELECT Top 10 c.id,c.fictionId,c.name,cc.id as ccid from [XX].[dbo].[XX_Catalog] c left join XX_ChapterContent cc on c.id = cc.catalogId where c.fictionId = {id} order by c.id desc";

            var dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Catalog>.ConverModel(dt);
        }
    }
}
