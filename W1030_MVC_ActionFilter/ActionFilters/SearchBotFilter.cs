using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Mvc;



namespace W1030_MVC_ActionFilter.ActionFilters
{

    /// <summary>
    /// 拒绝爬虫的 Filter
    /// </summary>
    public class SearchBotFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.Request.Browser.Crawler)
            {
                filterContext.Result = new ViewResult() { ViewName = "NotFound" };
            }
        }
    }

}