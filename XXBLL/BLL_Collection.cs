using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXModels;

namespace XXBLL
{
    /// <summary>
    /// 采集逻辑类
    /// </summary>
    public class BLL_Collection
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_Collection Instance { get; private set; }
        //私有构造函数
        private BLL_Collection()
        {

        }
        //静态构造函数
        static BLL_Collection()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_Collection();
                }
            }
        }
        private XXData.DAL_Collection bll = new XXData.DAL_Collection();
        /// <summary>
        /// 获取采集池全部内容
        /// </summary>
        /// <returns></returns>
        public List<CollectionWeb> GetCollectionWebs()
        {
            return bll.GetCollectionWebs();
        }
        /// <summary>
        /// 获取要采集的小说（未完结|完结未采集的）暂时使用id做排序
        /// </summary>
        /// <returns></returns>
        public List<CollectionFiction> GetCollectionFictions()
        {
            return bll.GetCollectionFictions();
        }
    }
}
