using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1030_MVC_ActionFilter.ActionFilters
{
    public class HelloWorldResultFilter : FilterAttribute, IResultFilter
    {


        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Write("Result执行完毕!<br/>");
        }



        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Write("Result执行之前!<br/>");
        }
    }
}