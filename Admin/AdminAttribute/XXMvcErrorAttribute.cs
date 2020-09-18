using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    /// <summary>
    /// mvc项目（非webapi）异常处理
    /// </summary>
    public class XXMvcErrorAttribute: HandleErrorAttribute
    {
        public override  void OnException(ExceptionContext filterContext)
        {
            //获取或设置一个值，该值指示是否已处理异常。
            if (!filterContext.ExceptionHandled)
            {
               
                //检查是否ajax请求
                var accept = filterContext.RequestContext.HttpContext.Request.AcceptTypes;
                if (filterContext.HttpContext.Request.IsAjaxRequest() || accept.Contains("application/json"))
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { code = 100, Msg = "系统异常，请联系管理员" }
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult() { ViewName = "/Views/Shared/error.cshtml", ViewData = new ViewDataDictionary() { { "msg", "系统异常请联系管理员" } } };// JavaScriptResult() { Script = @"alert( '系统异常请联系管理员');" };
                }
            }
            else
            {
                //普通异常
                filterContext.Result = new ViewResult() { ViewName = "/Views/Shared/error.cshtml", ViewData = new ViewDataDictionary() { { "msg", "系统异常请联系管理员" } } };
            }
            filterContext.ExceptionHandled = true;
        }
    }
}