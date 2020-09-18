
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Admin.Controllers
{
    /// <summary>
    /// webapibase token 验证
    /// </summary>
    public class ApiBaseAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证
            //比如登录，不需要带有token
            if(actionContext.ActionDescriptor.GetCustomAttributes<System.Web.Http.AllowAnonymousAttribute>().Any())
            {
                return;
            }else
            {
                //如果需要授权验证的
                if (actionContext.Request.Headers.Contains("Authorization"))
                {
                    //获取token
                    string token = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault().ToString();
                    base.OnAuthorization(actionContext);
                }
                else
                {
                    //未授权
                    HttpResponseMessage responseMessage = new HttpResponseMessage()
                    {
                        Content = new StringContent("{\"code\":\"401\",\"msg\":\"未授权\"}")
                    };
                    responseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    //返回401
                    actionContext.Response = responseMessage;
                    actionContext.Response.StatusCode = HttpStatusCode.Unauthorized;
                }

            }            


        }
    }
   

}