using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System.Web.SessionState;
using System.Reflection;

using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;

using log4net;

using W1050_Mvc5.Controllers;


namespace W1050_Mvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {



        #region 

        // 多个ASP.NET站点如何通过ASP.NET State服务共享Session会话
        // Sharing session state over multiple ASP.NET applications with ASP.NET state server
        // https://weblogs.asp.net/lichen/sharing-session-state-over-multiple-asp-net-applications-with-asp-net-state-server


        // 需求：
        //     在一台服务器上，两个网站之间，共享 Session 。
        //     这两个网站，可能域名不同。或者端口不同。

        // 测试方式：
        //     通过访问那个 【负载均衡测试】 的页面来进行测试。
        //     【负载均衡测试】的页面，测试负载均衡时，是网站发布到两台计算机上，配置相同的域名，进行测试。
        //     测试共享 Session 时，则只需要简单将网站，发布到一台机器上，创建两个网站即可。


        public override void Init()
        {
            base.Init();

            foreach (string moduleName in this.Modules)
            {
                string appName = "MyApp";
                IHttpModule module = this.Modules[moduleName];
                SessionStateModule ssm = module as SessionStateModule;
                if (ssm != null)
                {
                    FieldInfo storeInfo = typeof(SessionStateModule).GetField("_store", BindingFlags.Instance | BindingFlags.NonPublic);
                    SessionStateStoreProviderBase store = (SessionStateStoreProviderBase)storeInfo.GetValue(ssm);
                    if (store == null) //In IIS7 Integrated mode, module.Init() is called later
                    {
                        FieldInfo runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
                        HttpRuntime theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
                        FieldInfo appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
                        appNameInfo.SetValue(theRuntime, appName);
                    }
                    else
                    {
                        Type storeType = store.GetType();
                        if (storeType.Name.Equals("OutOfProcSessionStateStore"))
                        {
                            FieldInfo uribaseInfo = storeType.GetField("s_uribase", BindingFlags.Static | BindingFlags.NonPublic);
                            uribaseInfo.SetValue(storeType, appName);
                        }
                    }
                }
            }

        }


        #endregion





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
