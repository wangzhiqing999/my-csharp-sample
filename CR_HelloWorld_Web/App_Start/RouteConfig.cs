using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CR_HelloWorld_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // 水晶报表图片的处理路由.
            Route r = new Route("ReportViewer/CrystalImageHandler.aspx", new CrystalImageRouteHandler());
            // 设置检查文件是否存在  
            r.RouteExistingFiles = false;
            // 加入路由规则 
            routes.Add(r);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
