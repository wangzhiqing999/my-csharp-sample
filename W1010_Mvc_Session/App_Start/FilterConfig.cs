using System.Web;
using System.Web.Mvc;

namespace W1010_Mvc_Session
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}