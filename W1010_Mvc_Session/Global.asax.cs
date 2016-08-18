using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using log4net;




namespace W1010_Mvc_Session
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        // 关于 ASP.NET 应用程序生命周期
        // 参考下面这个页面：
        // https://msdn.microsoft.com/zh-cn/library/ms178473(VS.80).aspx



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        /// <summary>
        /// 请求开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //logger.DebugFormat("Application_BeginRequest! SessionID={0}", Session.SessionID);
        }

        /// <summary>
        /// 请求结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //logger.DebugFormat("Application_BeginRequest! SessionID={0}", Session.SessionID);
        }






        /// <summary>
        /// 会话开始.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_Start(object sender, EventArgs e)
        {
            logger.DebugFormat("Session_Start! SessionID={0}", Session.SessionID);
        }



        /// <summary>
        /// 会话结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_End(object sender, EventArgs e)
        {
            logger.DebugFormat("Session_End! SessionID={0}", Session.SessionID);
        }




    }
}