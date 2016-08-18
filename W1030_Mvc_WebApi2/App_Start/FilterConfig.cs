using System.Web;
using System.Web.Mvc;

namespace W1030_Mvc_WebApi2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
