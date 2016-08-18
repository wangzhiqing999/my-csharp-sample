using System.Web;
using System.Web.Mvc;

namespace W1005_MVC_Sub
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}