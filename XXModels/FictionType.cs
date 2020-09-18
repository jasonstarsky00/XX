using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 小说分类
    /// </summary>
    public class FictionType
    {
        public int id { get; set; }
        public string name { get; set; }
        //分类类型：1男生标签分类，2女生分类，3标签
        public int type { get; set; }
        public DateTime createTime { get; set; }
    }
}
