using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 采集网站池
    /// </summary>
    public class CollectionWeb
    {
        public int id { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string webName { get; set; }
        /// <summary>
        /// 网站搜索的url地址
        /// </summary>
        public string webUrl { get; set; }
        /// <summary>
        /// 网站的采集时的描述
        /// </summary>
        public string webDescription { get; set; }
        /// <summary>
        /// 采集优先级
        /// </summary>
        public int webLevel { get; set; }
    }
}
