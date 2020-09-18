using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Admin.Controllers
{
    /// <summary>
    /// webapi请求无效拦截
    /// </summary>
    public class ApiFoundSlector: ApiControllerActionSelector
    {
        
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            HttpActionDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectAction(controllerContext);
            }
            catch (HttpResponseException ex)
            {
                var code = ex.Response.StatusCode;
                //如果404找不到路径或方法
                if (code == HttpStatusCode.NotFound)
                {
                    ex.Response.Content = new HttpResponseMessage { Content = new StringContent("{\"code\":\"404\"，\"msg\":\"无效请求\"}") }.Content;
                    ex.Response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                }
               
                throw ex;
            }
            return decriptor;
        }        
    }
    /// <summary>
    /// webapi默认请求无效拦截
    /// </summary>
    public class HttpNotFoundDefaultHttpControllerSelector : DefaultHttpControllerSelector
    {
        public HttpNotFoundDefaultHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectController(request);
            }
            catch (HttpResponseException ex)
            {
                var code = ex.Response.StatusCode;
               // var result = new EWorkResultInfo<object> { Code = 10006, Entity = ex.Response.Content.ReadAsAsync<object>().Result };
                if (code == HttpStatusCode.NotFound || code == HttpStatusCode.MethodNotAllowed)
                {
                       ex.Response.Content = new HttpResponseMessage { Content = new StringContent("{\"code\":\"404\"，\"msg\":\"无效请求\"}") }.Content;
                    ex.Response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                }
                throw ex;
            }
            return decriptor;
        }


    }


}