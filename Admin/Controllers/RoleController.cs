using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using XXBLL;
using XXModels;

namespace Admin.Controllers
{
    [ApiBase]
    public class RoleController : ApiController
    {
        /// <summary>
        /// 获取全部角色数据
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Role/RoleList")]
        public IHttpActionResult RoleList(string roleName = "", string isEnable = "")
        {
            int code = 100;
            string msg = "获取角色数据失败";
            int isEnableInt = -1;
            if (isEnable == ""|| isEnable==null)
            {
                isEnableInt = -1;
            }
            else
            {
                isEnableInt= Convert.ToInt32(isEnable);
            }
           
            StringBuilder sb = new StringBuilder();
            if (roleName != null && roleName != "")
            {
                sb.Append($"and roleName='{roleName}'");
            }
            if (isEnableInt > -1)
            {
                sb.Append($"and isEnable={isEnableInt}");
            }
            List<Role> roleList = BLL_User.Instance.GetRoles(sb.ToString());
            if (roleList.Count > 0 && roleList != null)
            {
                code = 200;
                msg = "获取角色数据成功";
            }
            return Json(new { code = code, msg = msg, data = new { roleName = roleName, isEnable = isEnable, roleList = roleList } });
        }
        /// <summary>
        /// 修改角色状态
        /// </summary>
        /// <param name="id">角色id</param>
        /// <param name="isEnable">是否启用 0否1是</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Role/EditIsEnable")]
        public IHttpActionResult EditIsEnable(int id=-1,int isEnable = -1)
        {
            int code = 100;
            string msg = "修改失败";
            if (id > -1 && isEnable > -1)
            {
                int res = BLL_User.Instance.EditIsEnable(id, isEnable);
                if (res > 0)
                {
                     code = 200;
                     msg = "修改成功";
                }
            }
            return Json(new { code = code, msg = msg });
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Role/AddRole")]
        public IHttpActionResult AddRole(string roleName, int isEnable = -1)
        {
            int code = 100;
            string msg = "添加失败";
            if (string.IsNullOrWhiteSpace(roleName))
            {
                 code = 101;
                 msg = "角色名称不能为空";
            }
            else if (isEnable <= -1)
            {
                code = 102;
                msg = "状态错误";
            }else
            {
                int res = BLL_User.Instance.AddRole(roleName, isEnable);
                if (res > 0)
                {
                    code = 200;
                    msg = "添加成功";
                }
            }
            return Json(new { code = code, msg = msg });

        }
        /// <summary>
        /// 获取单条角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Role/GetRole")]
        public IHttpActionResult GetRole(int id=-1)
        {
            int code = 100;
            string msg = "获取失败";
            Role role = new Role();
            if (id > 0)
            {
                role = BLL_User.Instance.GetRole(id);
                if (role.id > 0)
                {
                     code = 200;
                     msg = "获取成功";
                }
            }
            return Json(new { code = code, msg = msg, data = role });
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="isEnable">状态</param>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Role/EditRole")]
        public IHttpActionResult EditRole(string roleName, int isEnable = -1,int id=-1)
        {
            int code = 100;
            string msg = "编辑失败";
            if (string.IsNullOrWhiteSpace(roleName))
            {
                code = 101;
                msg = "角色名称不能为空";
            }
            else if (isEnable <= -1)
            {
                code = 102;
                msg = "状态错误";
            }
            else if (id <= -1)
            {
                code = 103;
                msg = "id错误";
            }
            else
            {
                int res = BLL_User.Instance.EditRole(roleName, isEnable, id);
                if (res > 0)
                {
                    code = 200;
                    msg = "编辑成功";
                }
            }
            return Json(new { code = code, msg = msg });

        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Role/DeleteRole")]
        public IHttpActionResult DeleteRole(int id = -1)
        {
            int code = 100;
            string msg = "删除失败";
            if (id > -1)
            {
                int res = BLL_User.Instance.DeleteRole(id);
                if (res > 0)
                {
                    code = 200;
                    msg = "删除成功";
                }
            }
            return Json(new { code = code, msg = msg});

        }
    }
}
