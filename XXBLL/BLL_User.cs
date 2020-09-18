using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;
using XXModels;

namespace XXBLL
{
    public class BLL_User
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_User Instance { get; private set; }
        //私有构造函数
        private BLL_User()
        {

        }
        //静态构造函数
        static BLL_User()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_User();
                }
            }
        }
        private XXData.DAL_User bll = new XXData.DAL_User();
        public User GetUsers()
        {

            return bll.GetUsers();
        }
        /// <summary>
        /// 账号是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserNameExist(string userName)
        {
            return bll.UserNameExist(userName);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserReg(User model)
        {
            return bll.UserReg(model);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUser(string userName)
        {
            return bll.GetUser(userName);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            return bll.GetUserById(id);
        }
        /// <summary>
        /// 多条件分页查询用户数据
        /// </summary>
        /// <param name="conditionStr">条件字符串</param>
        /// <param name="pageSize">分页显示数量</param>
        /// <param name="pageIndex">当前分页</param>
        /// <returns></returns>
        public DataTable GetUsers(string conditionStr, int pageSize, int pageIndex)
        {
            return bll.GetUsers(conditionStr, pageSize, pageIndex);
        }
        /// <summary>
        /// 获取全部角色数据
        /// </summary>
        /// <param name="conditionStr">查询条件</param>
        /// <returns></returns>
        public List<Role> GetRoles(string conditionStr)
        {
            return bll.GetRoles(conditionStr);
        }
        /// <summary>
        /// 修改角色状态
        /// </summary>
        /// <param name="id">角色id</param>
        /// <param name="isEnble">是否启用 0否1是</param>
        /// <returns></returns>
        public int EditIsEnable(int id, int isEnble)
        {
            return bll.EditIsEnable(id, isEnble);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <returns></returns>
        public int AddRole(string roleName, int isEnable)
        {
            return bll.AddRole(roleName, isEnable);
        }
        /// <summary>
        /// 获取单条角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRole(int id)
        {
            return bll.GetRole(id);
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        public int EditRole(string roleName, int isEnable, int id)
        {
            return bll.EditRole(roleName, isEnable, id);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRole(int id)
        {
            return bll.DeleteRole(id);
        }
        /// <summary>
        /// 获取全部权限数据
        /// </summary>
        /// <returns></returns>
        public List<Permission> PermissionsFindAll()
        {
            return bll.PermissionsFindAll();
        }
        /// <summary>
        /// 获取角色拥有权限id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RolePermissId> RolePermissionByRoleId(int id)
        {
            return bll.RolePermissionByRoleId(id);
        }
        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EditUser UserById(int id)
        {
            return bll.UserById(id);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditUser(EditUser model)
        {
            return bll.EditUser(model);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUser(int id)
        {
            return bll.DeleteUser(id);
        }
    }
}
