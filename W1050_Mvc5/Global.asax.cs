using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;

using log4net;

using W1050_Mvc5.Controllers;



namespace W1050_Mvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DisplayConfig.RegisterDisplayModes(DisplayModeProvider.Instance.Modes);



            // 在 IIS 8 当中，进行如下的设置:
            // 1.Application Pool层级:只要有需要的Application Pool的Start Mode设定AlwaysRunning就可以。
            // 2.Web Site层级:选择要做Preload的Web Site。 开启preload和DoAppInitAfterRestart。



            // ##### EF Pre-Generated Mapping Views #####

            // 由于 EF 在首次加载的时候， 非常耗时
            // 因此，初始化的操作， 放置在 Application_Start 里面进行处理。
            // 这样一来， 首次查询操作， 将不会发生速度非常慢的现象。
      
            // 对程序中定义的所有DbContext逐一进行这个操作
            /*
             * 
            using (var dbcontext = new MyTestContext())
            {
                var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }  

            */
            
        }






        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 在使用 OutputCache， varyByCustom 的时候， 需要在  Global.asax 文件中重写 GetVaryByCustomString 方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="custom"></param>
        /// <returns></returns>
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            // 自定义的， 根据显示模式进行缓存的处理.
            if (string.Equals(custom, "DisplayMode", StringComparison.OrdinalIgnoreCase))
            {
                string displayMode = context.Request.DisplayMode();
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("UserAgent = {0}", context.Request.UserAgent);
                    logger.DebugFormat("DisplayMode = {0}", displayMode);
                }
                return displayMode;
            }
            return base.GetVaryByCustomString(context, custom);
        }




        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
            {
                // 在Global.asax中调用Server.ClearError方法相当于是告诉Asp.Net系统抛出的异常已经被处理过了，不需要系统跳转到Asp.Net的错误页了。
                // 如果不加下面这一句代码，将导致后面的跳转无效，最终还是跳转到Asp.Net的错误页。
                Server.ClearError();

                // 页面跳转
                Response.Redirect("/TestError/PageNotFound", true);
                
            }
        }

    }



    public static class HttpRequestExtensions
    {

        public static string DisplayMode(this HttpRequest request)
        {
            string display = null;
            if (HasCookieDisplay(request, ref display))
            {
                // 如果 Cookie 中明确指定了，使用哪种页面
                // 那么判断使用哪种页面，就不通过设备类型去检测了.
                return display;
            }

            // Session 中没有指定的情况下.
            // 按顺序进行判断.
            if (IsTabletInternal(request.UserAgent))
            {
                // 是平板.
                return "tablet";
            }
            if (request.Browser.IsMobileDevice)
            {
                // 是手机.
                return "mobile";
            }
            // 其他情况下， PC
            return "pc";
        }


        /// <summary>
        /// 设备是否是平板电脑.
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        private static Boolean IsTabletInternal(String userAgent)
        {
            var ua = userAgent.ToLower();
            return ua.Contains("ipad") || ua.Contains("gt-");
        }


        /// <summary>
        /// Cookie 中，是否指定了显示类型.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        private static bool HasCookieDisplay(HttpRequest request, ref string display)
        {
            if (request.Cookies == null)
            {
                return false;
            }
            if (request.Cookies["DISPLAY"] == null)
            {
                return false;
            }

            display = request.Cookies["DISPLAY"].Value;
            return !String.IsNullOrEmpty(display);
        }
    }

}
