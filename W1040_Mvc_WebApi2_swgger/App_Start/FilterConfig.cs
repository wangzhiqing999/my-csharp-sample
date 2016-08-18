using System.Web;
using System.Web.Mvc;

namespace W1040_Mvc_WebApi2_swgger
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
