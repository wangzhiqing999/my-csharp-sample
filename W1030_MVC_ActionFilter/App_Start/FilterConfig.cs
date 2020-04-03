using System.Web;
using System.Web.Mvc;

using W1030_MVC_ActionFilter.ActionFilters;

namespace W1030_MVC_ActionFilter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());


            filters.Add(new AddScriptFilter());
        }
    }
}