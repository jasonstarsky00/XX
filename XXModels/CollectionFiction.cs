using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 要采集的小说
    /// </summary>
    public class CollectionFiction
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小说名称
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Book_Author { get; set; }
    }
}
