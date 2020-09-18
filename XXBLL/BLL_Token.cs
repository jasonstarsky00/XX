using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXModels;

namespace XXBLL
{
    public class BLL_Token
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_Token Instance { get; private set; }
        //私有构造函数
        private BLL_Token()
        {

        }
        //静态构造函数
        static BLL_Token()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_Token();
                }
            }
        }
        private XXData.DAL_Token bll = new XXData.DAL_Token();
        /// <summary>
        /// 保存token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateToken(int id,string token, string expiredTime)
        {
            return bll.CreateToken(id,token, expiredTime);
        }
        /// <summary>
        /// 获取用户最新的token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Token GetTokenByUid(int id)
        {
            return bll.GetTokenByUid(id);
        }
    }
}
