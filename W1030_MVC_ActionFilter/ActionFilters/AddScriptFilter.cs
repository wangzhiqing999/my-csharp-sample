using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace W1030_MVC_ActionFilter.ActionFilters
{

    public class AddScriptFilter : FilterAttribute, IResultFilter
    {


        private const string AddScript = @"
<script>
    console.log(' Test Script!');
</script>
";


        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result.GetType().ToString() == "System.Web.Mvc.PartialViewResult")
            {
                // 忽略分布视图.
                return;
            }

            if (filterContext.Result.GetType().ToString() == "System.Web.Mvc.JsonResult")
            {
                // 忽略 Json .
                return;
            }

            if (filterContext.Result.GetType().ToString() == "System.Web.Mvc.ContentResult")
            {
                // 忽略 Content .
                return;
            }

            filterContext.RequestContext.HttpContext.Response.Write(AddScript);
            
        }






        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            // Do Nothing.
        }

    }

}