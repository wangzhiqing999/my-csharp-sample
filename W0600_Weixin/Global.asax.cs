using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

using log4net;



namespace W0600_Weixin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);






        protected void Application_Start()
        {

            // 隐藏ASP.NET MVC的版本信息，使其不在HTTP Header中显示。
            MvcHandler.DisableMvcResponseHeader = true;



            // ##########  Log4Net 配置.  ##########

            string webConfigFile = Server.MapPath("web.config");
            if (System.IO.File.Exists(webConfigFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(webConfigFile));
            }




            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }





        /// <summary>
        /// 开始处理请求.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("Application_BeginRequest! ip={0}, path = {1}",
                    Request.UserHostAddress,
                    this.Context.Request.RawUrl
                    );
            }
        }







        /// <summary>
        /// 异常处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // 取得发生的异常.
            Exception ex = Server.GetLastError();


            StringBuilder buff = new StringBuilder();
            foreach (string key in Request.Headers.Keys)
            {
                buff.AppendFormat("{0}={1};", key, Request.Headers.Get(key));
                buff.AppendLine();
            }
            string httpHeader = buff.ToString();


            String message = String.Format(@"IP:{0}; URL:{1}; Message:{2};
Headers:{3}
Browser:{4}
MobileDeviceModel:{5}",
                Request.UserHostAddress, Request.RawUrl, ex.Message,
                httpHeader,
                Request.Browser == null ? "" : Request.Browser.Type,
                Request.Browser.MobileDeviceModel);

            logger.Error(message, ex);


        }


    }
}