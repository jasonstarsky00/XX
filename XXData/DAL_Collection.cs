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
    /// <summary>
    /// 采集数据库类
    /// </summary>
    public class DAL_Collection
    {
        /// <summary>
        /// 获取采集池全部内容
        /// </summary>
        /// <returns></returns>
        public List<CollectionWeb> GetCollectionWebs()
        {
            string sql = "  select * from XX_ColletionWeb order by webLevel desc";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<CollectionWeb>.ConverModel(dt);
        }
        /// <summary>
        /// 获取要采集的小说（未完结|完结未采集的）暂时使用id做排序
        /// </summary>
        /// <returns></returns>
        public List<CollectionFiction> GetCollectionFictions()
        {
            string sql = "select id,BookName,Book_Author from XX_Fiction where isCollection != 0 and Book_Status != '完结'  order by id";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<CollectionFiction>.ConverModel(dt);
        }
    }
}
