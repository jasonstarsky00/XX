using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;
using XXModels;

namespace XXData
{
    public class DAL_User
    {
        public User GetUsers()
        {
            string sql = "select * from XX_User";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<User>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 账号是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserNameExist(string userName)
        {
            string sql = $"select count(*) as count from XX_User where userName='{userName}'";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            int result = (int)dt.Rows[0]["count"];
            return result == 0 ? true : false;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserReg(User model)
        {
            string sql = $"  insert into XX_User(userName,randCode,guid,passWord,userRole,avatarPath,name,isVip,vipGrade,intergral,isFreeze,isActivation)values('{model.userName}','{model.randCode}','{model.guid}','{model.passWord}',{model.userRole},'{model.avatarPath}','{model.name}',{model.isVip},{model.vipGrade},{model.intergral},{model.isFreeze},{model.isActivation})";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUser(string userName)
        {
            string sql = $"select * from XX_User where userName='{userName}'";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<User>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            string sql = $"select * from XX_User where id={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<User>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 多条件分页查询用户数据
        /// </summary>
        /// <param name="conditionStr">条件字符串</param>
        /// <param name="pageSize">分页显示数量</param>
        /// <param name="pageIndex">当前分页</param>
        /// <returns></returns>
        public DataTable GetUsers(string conditionStr,int pageSize,int pageIndex)
        {
            string sql = @"select top {0}
	                    (select count(*)  from XX_User where 1=1 {1}) as total,
	                    * from
                        (select ROW_NUMBER() over(order by id) as row,* from XX_User u where 1=1 {2}) XX_User
                        where row between {3} and {4}";
            sql = string.Format(sql, pageSize, conditionStr, conditionStr, (pageIndex - 1) * pageSize, pageIndex * pageSize);           
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取全部角色数据
        /// </summary>
        /// <param name="conditionStr">查询条件</param>
        /// <returns></returns>
        public List<Role> GetRoles(string conditionStr)
        {
            string sql = "select * from XX_Role where 1=1 {0}";
            sql = string.Format(sql, conditionStr);
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Role>.ConverModel(dt);
        }
        /// <summary>
        /// 修改角色状态
        /// </summary>
        /// <param name="id">角色id</param>
        /// <param name="isEnble">是否启用 0否1是</param>
        /// <returns></returns>
        public int EditIsEnable(int id,int isEnable)
        {
            string sql = $"update XX_Role set isEnable={isEnable} where id={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <returns></returns>
        public int AddRole(string roleName,int isEnable)
        {
            string sql = $"insert into XX_Role(roleName,isEnable)values('{roleName}',{isEnable})";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取单条角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRole(int id)
        {
            string sql = $"select * from XX_Role where id={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Role>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        public int EditRole(string roleName, int isEnable,int id)
        {
            string sql = $"update XX_Role set roleName = '{roleName}',isEnable={isEnable} where id={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRole(int id)
        {
            string sql = $"delete XX_Role where id={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取全部权限数据
        /// </summary>
        /// <returns></returns>
        public List<Permission> PermissionsFindAll()
        {
            string sql = "select * from XX_Permission";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Permission>.ConverModel(dt);
        }
        /// <summary>
        /// 获取角色拥有权限id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RolePermissId> RolePermissionByRoleId(int id)
        {
            string sql = $" select permissionId as permissId from XX_RolePermission where roleId={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<RolePermissId>.ConverModel(dt);
        }
        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EditUser UserById(int id)
        {
            string sql = $"select * from XX_User where id={id}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<EditUser>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditUser(EditUser model)
        {
            string sql = $" update XX_User set userRole={model.userRole},name='{model.name}',email='{model.email}',phone='{model.phone}',isVip={model.isVip},vipGrade={model.vipGrade},intergral={model.intergral},isFreeze={model.isFreeze},isActivation={model.isActivation} where id ={model.id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUser(int id)
        {
            string sql = $"delete XX_User where id={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
    }
}
