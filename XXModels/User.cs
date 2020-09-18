using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXModels
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string passWord { get; set; }
        /// <summary>
        /// 随机码
        /// </summary>
        public string randCode { get; set; }
        /// <summary>
        /// guid
        /// </summary>
        public string guid { get; set; }
        /// <summary>
        /// 用户角色  角色类型:1:普通用户2:....8:管理员.9:超级管理员
        /// </summary>
        public int userRole { get; set; }
        /// <summary>
        /// 用户头像路径
        /// </summary>
        public string avatarPath { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 是否Vip
        /// </summary>
        public int isVip { get; set; }
        /// <summary>
        /// vip等级
        /// </summary>
        public int vipGrade { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int intergral { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime lastLoginTime { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int isFreeze { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public int isActivation { get; set; }
    }
    /// <summary>
    /// 修改用户表
    /// </summary>
    public class EditUser
    {
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }       
        /// <summary>
        /// 用户角色  角色类型:1:普通用户2:....8:管理员.9:超级管理员
        /// </summary>
        public int userRole { get; set; }       
        /// <summary>
        /// 昵称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 是否Vip
        /// </summary>
        public int isVip { get; set; }
        /// <summary>
        /// vip等级
        /// </summary>
        public int vipGrade { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int intergral { get; set; }
        
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int isFreeze { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public int isActivation { get; set; }
    }
}
