using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

using System.Diagnostics;

namespace W1030_Mvc_WebApi2.ActionFilters
{

    /// <summary>
    /// Web Api 日志的 Filter.
    /// </summary>
    public class WebApiLogFilter : ActionFilterAttribute
    {

        DateTime startDateTime = DateTime.Now;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            // 这里的日志， 简单使用 System.Diagnostics.Debug.WriteLine
            // 在 Visual Studio 中，运行的时候，可以在 [output] 那里看到。
            // 实际使用时，需要 往 日志文件 里面去写的。

            Debug.WriteLine("#### OnActionExecuting ####");

            Debug.WriteLine("Path = " + actionContext.Request.RequestUri.AbsolutePath);

            Debug.WriteLine("Method = " + actionContext.Request.Method.Method);


            var args = actionContext.ActionArguments;
            if(args != null && args.Count > 0)
            {
                foreach(var arg in args.Keys)
                {
                    Debug.WriteLine("Argument: " + arg + " = " + args[arg]);
                }
            }

            startDateTime = DateTime.Now;

            base.OnActionExecuting(actionContext);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine("#### OnActionExecuted ####");

            Debug.WriteLine("Path = " + actionExecutedContext.Request.RequestUri.AbsolutePath);

            Debug.WriteLine("Method = " + actionExecutedContext.Request.Method.Method);

            Debug.WriteLine("Result = " + actionExecutedContext.Response.Content);




            var timeSpan = DateTime.Now - startDateTime;

            Debug.WriteLine("操作总耗时：" + timeSpan.TotalMilliseconds);

            base.OnActionExecuted(actionExecutedContext);

        }


    }
}