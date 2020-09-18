using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using XXBLL;
using XXCommon;
using XXModels;

namespace Admin.Controllers
{
    /// <summary>
    /// 权限控制器
    /// </summary>
    [ApiBase]
    public class PermissionController : ApiController
    {
        /// <summary>
        /// 根据角色获取相关的菜单
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Permission/GetMenus")]
        public IHttpActionResult GetMenus(int id)
        {
            int code = 100;
            string msg = "获取失败";
            List<Menus> listMenus = new List<Menus>();
            if (id < 0)
            {
                code = 101;
                msg = "获取失败";
            }else
            {
                User user = BLL_User.Instance.GetUserById(id);
                if (user.id > 0)
                {
                    List<Menu> listMenu = BLL_Menu.Instance.GetMenusByRoleId(user.userRole);
                    #region 三级
                    //List<ReportMenus> listReportMenus = new List<ReportMenus>();
                    ////一级
                    //foreach (Menu item in listMenu)
                    //{
                    //    if (item.parentId == 0)
                    //    {
                    //        ReportMenus reportMenus = new ReportMenus();
                    //        reportMenus.permissId = item.permissId;
                    //        reportMenus.parentId = item.parentId;
                    //        reportMenus.permissName = item.permissName;
                    //        reportMenus.controller = item.controller;
                    //        reportMenus.action = item.action;
                    //        reportMenus.sort = item.sort;
                    //        reportMenus.isEnable = item.isEnable;
                    //        reportMenus.isLog = item.isLog;
                    //        List<Menus> listMenus = new List<Menus>();                    
                    //        #region 二级
                    //        foreach (Menu item1 in listMenu)
                    //        {
                    //            if (item1.parentId == item.permissId)
                    //            {
                    //                Menus menus = new Menus();
                    //                menus.permissId = item1.permissId;
                    //                menus.parentId = item1.parentId;
                    //                menus.permissName = item1.permissName;
                    //                menus.controller = item1.controller;
                    //                menus.action = item1.action;
                    //                menus.sort = item1.sort;
                    //                menus.isEnable = item1.isEnable;
                    //                menus.isLog = item1.isLog;
                    //                List<Menu> listMenu2 = new List<Menu>();                            
                    //                #region 三级
                    //                foreach (Menu item2 in listMenu)
                    //                {
                    //                    if (item2.parentId == item1.permissId)
                    //                    {
                    //                        Menu menu = new Menu();
                    //                        menu.permissId = item2.permissId;
                    //                        menu.parentId = item2.parentId;
                    //                        menu.permissName = item2.permissName;
                    //                        menu.controller = item2.controller;
                    //                        menu.action = item2.action;
                    //                        menu.sort = item2.sort;
                    //                        menu.isEnable = item2.isEnable;
                    //                        menu.isLog = item2.isLog;
                    //                        listMenu2.Add(menu);
                    //                    }
                    //                }
                    //                #endregion
                    //                menus.childMenus = listMenu2;
                    //                listMenus.Add(menus);
                    //            }
                    //        }
                    //        #endregion
                    //        reportMenus.childMenus = listMenus;
                    //        listReportMenus.Add(reportMenus);
                    //    }
                    //}
                    #endregion
                    #region 获取菜单信息
                   
                    foreach (Menu item in listMenu)
                    {
                        if (item.parentId == 0)
                        {
                            Menus menus = new Menus();
                            menus.permissId = item.permissId;
                            menus.parentId = item.parentId;
                            menus.permissName = item.permissName;
                            menus.controller = item.controller;
                            menus.action = item.action;
                            menus.sort = item.sort;
                            menus.isEnable = item.isEnable;
                            menus.isLog = item.isLog;

                            List<Menu> listMenu2 = new List<Menu>();
                            foreach (Menu item2 in listMenu)
                            {
                                if (item.permissId == item2.parentId)
                                {
                                    Menu menu = new Menu();
                                    menu.permissId = item2.permissId;
                                    menu.parentId = item2.parentId;
                                    menu.permissName = item2.permissName;
                                    menu.controller = item2.controller;
                                    menu.action = item2.action;
                                    menu.sort = item2.sort;
                                    menu.isEnable = item2.isEnable;
                                    menu.isLog = item2.isLog;
                                    listMenu2.Add(menu);
                                }
                            }
                            menus.childMenus = listMenu2;
                            listMenus.Add(menus);
                        }
                    }
                    if (listMenus.Count > 0)
                    {
                        code = 200;
                        msg = "获取菜单成功";
                    }
                    #endregion
                }
            }

           
            
            return Json(new { code = code, msg = msg, data = listMenus });
        }

        /// <summary>
        /// 权限数据集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Permission/GetPermissions")]
        public IHttpActionResult GetPermissions()
        {
            int code = 100;
            string msg = "获取权限失败";
            List<Permission> listPermissions = BLL_User.Instance.PermissionsFindAll();
            List<ReprotPermissionFirst> listReprotPermission = new List<ReprotPermissionFirst>();
            if (listPermissions.Count > 0 && listPermissions != null)
            {                
                #region 一级
                foreach (Permission item1 in listPermissions)
                {
                    if (item1.parentId == 0)
                    {
                        ReprotPermissionFirst rP1 = new ReprotPermissionFirst();
                        rP1.action = item1.action;
                        rP1.controller = item1.controller;
                        rP1.isEnable = item1.isEnable;
                        rP1.isLog = item1.isLog;
                        rP1.parentId = item1.parentId;
                        rP1.permissId = item1.permissId;
                        rP1.permissName = item1.permissName;
                        rP1.sort = item1.sort;                        
                        #region 二级
                        List<ReprotPermissionSecond> listRP2 = new List<ReprotPermissionSecond>();
                        foreach (Permission item2 in listPermissions)
                        {
                            if (item1.permissId == item2.parentId)
                            {
                                ReprotPermissionSecond rP2 = new ReprotPermissionSecond();
                                rP2.action = item2.action;
                                rP2.controller = item2.controller;
                                rP2.isEnable = item2.isEnable;
                                rP2.isLog = item2.isLog;
                                rP2.parentId = item2.parentId;
                                rP2.permissId = item2.permissId;
                                rP2.permissName = item2.permissName;
                                rP2.sort = item2.sort;

                                #region 三级
                                List<ReprotPermissionThree> listRP3 = new List<ReprotPermissionThree>();
                                foreach (Permission item3 in listPermissions)
                                {
                                    if (item2.permissId == item3.parentId)
                                    {
                                        ReprotPermissionThree rP3 = new ReprotPermissionThree();
                                        rP3.action = item3.action;
                                        rP3.controller = item3.controller;
                                        rP3.isEnable = item3.isEnable;
                                        rP3.isLog = item3.isLog;
                                        rP3.parentId = item3.parentId;
                                        rP3.permissId = item3.permissId;
                                        rP3.permissName = item3.permissName;
                                        rP3.sort = item3.sort;
                                        listRP3.Add(rP3);
                                    }
                                #endregion
                                }
                                rP2.Children = listRP3;
                                listRP2.Add(rP2);
                            }
                        }
                        #endregion
                        rP1.Children = listRP2;
                        listReprotPermission.Add(rP1);
                    }                    
                }
                #endregion                
            }
            if (listReprotPermission.Count > 0)
            {
                 code = 200;
                 msg = "获取权限成功";
            }
            return Json(new { code = code, msg = msg, data = listReprotPermission });
        }
        /// <summary>
        /// 为角色添加授权
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionStr"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Permission/RoleAddPermissions")]
        public IHttpActionResult RoleAddPermissions(int id=-1,string permissionStr="")
        {
            int code = 100;
            string msg = "授权失败";
            if (permissionStr == "no"&& permissionStr.Length==2)
            {
                //取消授权
                //先删除角色保存权限
                SqlParameter[] delesqlParArr = { new SqlParameter("@sql", $"delete from XX_RolePermission where roleId={id}") };
                object delval = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", delesqlParArr);
                code = 200;
                msg = "授权成功";

            }
            else if(id > -1 && !string.IsNullOrWhiteSpace(permissionStr))
            {
                List<string> pidList = permissionStr.Split(',').ToList();
                StringBuilder sb = new StringBuilder();
                //先删除角色保存权限
                SqlParameter[] delesqlParArr = { new SqlParameter("@sql", $"delete from XX_RolePermission where roleId={id}") };
                object delval = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", delesqlParArr);
                //再保存
                int count = 0;
                object val = new object();
                for (int i = 0; i < pidList.Count; i++)
                {
                    sb.Append($" insert into XX_RolePermission(roleId, permissionId)values({id},{Convert.ToInt32(pidList[i])})");
                    count += 1;
                    if (count == 20)
                    {
                        SqlParameter[] sqlParArr = { new SqlParameter("@sql", sb.ToString()) };
                        val = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", sqlParArr);
                        //重置
                        count = 0;
                        sb = new StringBuilder();
                    }
                }
                SqlParameter[] sqlParArr2 = { new SqlParameter("@sql", sb.ToString()) };
                val = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", sqlParArr2);
                if (Convert.ToInt32(val) >= 1)
                {
                    code = 200;
                    msg = "授权成功";
                }
            }
           
            return Json(new { code = code, msg = msg });
        }

        [HttpGet]
        [Route("/api/Permission/GetRolePermissions")]
        public IHttpActionResult GetRolePermissions(int id=-1)
        {
            int code = 100;
            string msg = "获取失败";
            List<RolePermissId> listRolePermission = new List<RolePermissId>();
            List<int> idList = new List<int>();
            if (id > -1)
            {
                listRolePermission = BLL_User.Instance.RolePermissionByRoleId(id);
                if (listRolePermission.Count > 0)
                {
                    code = 200;
                    msg = "获取成功";
                    for (int i = 0; i < listRolePermission.Count; i++)
                    {
                        idList.Add(listRolePermission[i].permissId);
                    }

                    
                }
            }
            return Json(new { code = code, msg = msg ,data= new { list= idList}});
        }
    }
}
