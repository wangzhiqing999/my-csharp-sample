using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace W1050_Mvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "PageNotFound",
                url: "PageNotFound",
                defaults: new { controller = "TestError", action = "PageNotFound"}
            );


            //启用Attribute路由
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                "Globalization", // 路由名称
                "{lang}/{controller}/{action}/{id}", // 带有参数的 URL
                new { lang = "zh", controller = "Home", action = "Index", id = UrlParameter.Optional }, // 参数默认值
                new { lang = "^[a-zA-Z]{2}(-[a-zA-Z]{2})?$" }    //参数约束
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
