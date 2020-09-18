using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// Token表
    /// </summary>
    public class Token
    {
        public int id { get; set; }
        public int uid { get; set; }
        public string token { get; set; }
        public string expiredTime { get; set; }
    }
}
