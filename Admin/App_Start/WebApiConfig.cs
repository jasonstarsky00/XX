using Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Admin
{
    public static class WebApiConfig
    {
       
        public static void Register(HttpConfiguration config)
        {
            
            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API routes
           // config.MapHttpAttributeRoutes();
           // config.Routes.MapHttpRoute(
           //    name: "DynamicApi",
           //    routeTemplate: "{controller}/{action}/{id}",
           //    defaults: new { id = RouteParameter.Optional }
           //);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
            config.Filters.Add(new ApiBaseAttribute());
            //异常统一返回错误
            config.Filters.Add(new ApiExceptionFilterAttribute());            
            //拦截无效请求          
            config.Services.Replace(typeof(System.Web.Http.Controllers.IHttpActionSelector), new ApiFoundSlector());


            config.Services.Replace(typeof(System.Web.Http.Dispatcher.IHttpControllerSelector), new HttpNotFoundDefaultHttpControllerSelector(config));
            
        }
    }
}
