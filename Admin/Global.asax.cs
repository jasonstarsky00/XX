using Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Admin
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public System.Threading.Thread testCaiJi = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Filters.Add(new Controllers.ApiExceptionFilterAttribute());

            //注册mvc项目错误特性
            GlobalFilters.Filters.Add(new XXMvcErrorAttribute());


            //自动采集
            /*只有页面程序发生访问，才能启用任务调度器*/
            FluentScheduler.JobManager.Initialize(new Collection.CollectionRegistry());
        }
        /// <summary>
        /// 为了定时采集唤醒编写
        /// </summary>
        protected void Application_End()
        {
            string strURL = System.Configuration.ConfigurationManager.AppSettings["homeURL"].ToString();
        }
    }
}
