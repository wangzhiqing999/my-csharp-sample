using System.Web;
using System.Web.Mvc;

namespace W1051_Mvc5_MobileFirst
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
