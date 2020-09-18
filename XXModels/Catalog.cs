using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 小说章节
    /// </summary>
    public class Catalog
    {
        public int id { get; set; }
        /// <summary>
        /// 小说id
        /// </summary>
        public int fictionId { get; set; }
        /// <summary>
        /// 小说章节名称
        /// </summary>
        public string name { get; set; }
        public int ccid { get; set; }
    }
}
