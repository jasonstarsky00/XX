using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.XXCommon
{
    public class XXResult
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }
    }
}