using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 文章类
    /// </summary>
    public class ChapterContent
    {
        public int id { get; set; }
        public int catalogId { get; set; }
        public string chapterContent { get; set; }
    }
}
