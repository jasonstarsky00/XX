using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    
    public class Permission
    {
        /// <summary>
        /// 权限id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 启用禁用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
    }
    /// <summary>
    /// 一级权限
    /// </summary>
    public class ReprotPermissionFirst
    {
        /// <summary>
        /// 权限id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 启用禁用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }
        public List<ReprotPermissionSecond> Children { get; set; }
    }
    /// <summary>
    /// 二级权限
    /// </summary>
    public class ReprotPermissionSecond
    {
        /// <summary>
        /// 权限id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 启用禁用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }
        public List<ReprotPermissionThree> Children { get; set; }
    }

    /// <summary>
    /// 三级权限
    /// </summary>
    public class ReprotPermissionThree
    {
        /// <summary>
        /// 权限id
        /// </summary>
        public int permissId { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string permissName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string controller { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 启用禁用
        /// </summary>
        public int isEnable { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public int isLog { get; set; }
    }
    /// <summary>
    /// 已有权限id
    /// </summary>
    public class RolePermissId
    {
        public int permissId { get; set; }
    }
}
