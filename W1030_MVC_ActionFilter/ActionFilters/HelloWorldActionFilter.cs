using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1030_MVC_ActionFilter.ActionFilters
{
    public class HelloWorldActionFilter : FilterAttribute, IActionFilter
    {

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Write(string.Format("Action({0}) 执行完毕!<br />"
                , filterContext.ActionDescriptor.ActionName));
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Write(string.Format("Action({0}) 执行之前!<br />"
                , filterContext.ActionDescriptor.ActionName));
        }
    }
}