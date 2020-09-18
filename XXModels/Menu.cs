using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }

    }
    /// <summary>
    /// 返回前端菜单集合
    /// </summary>
    public class ReportMenus
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }
        public List<Menus> childMenus { get; set; }
    }
    public class Menus
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }
        public List<Menu> childMenus { get; set; }
    }
}
