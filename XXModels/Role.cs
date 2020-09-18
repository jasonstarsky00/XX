using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        public int id { get; set; }
        public string roleName { get; set; }
        /// <summary>
        /// 是否启用，1是0否
        /// </summary>
        public int isEnable { get; set; }
        public DateTime createTime { get; set; }
    }
    
}
