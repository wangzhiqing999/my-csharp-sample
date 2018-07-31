using System.Web;
using System.Web.Mvc;

namespace W1055_Mvc5_gulp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
