using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using XXCommon;

namespace Admin.Controllers{
    /// <summary>
    /// webapi异常拦截处理
    /// </summary>
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1.异常日志记录
            StringBuilder sb = new StringBuilder();          
            sb.Append( "请求路径："+ actionExecutedContext.Request.RequestUri.AbsoluteUri +" \r\n  错误原因： "+ 
            actionExecutedContext.Exception.GetType().ToString() + "：" + actionExecutedContext.Exception.Message + "  \r\n 错误详细内容：" +
            actionExecutedContext.Exception.StackTrace);
            LogHelper.WriteLogs(sb.ToString(), "WebApiException");
            //返回json格式：错误内容
            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent("{\"code\":\"501\"，\"msg\":\"发生异常请联系管理员\"}")
            };
            responseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置http code =501
            responseMessage.StatusCode = HttpStatusCode.NotImplemented;
            actionExecutedContext.Response = responseMessage;

            








        }
       
        
        

    }
}