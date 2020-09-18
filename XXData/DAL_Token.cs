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
    /// Token表
    /// </summary>
    public class DAL_Token
    {
        /// <summary>
        /// 保存token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateToken(int id,string token,string expiredTime)
        {
            string sql = $"insert into XX_Token(uid,token,expiredTime)values({id},'{token}','{expiredTime}')";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取用户最新的token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Token GetTokenByUid(int id)
        {
            string sql = $"select top 1 * from XX_Token where uid={id} order by id desc";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Token>.DtReturnFirst(dt);
        }
    }
}
