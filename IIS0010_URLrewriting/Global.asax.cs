using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;

using log4net;




namespace IIS0010_URLrewriting
{
    public class Global : System.Web.HttpApplication
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);





        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            // 测试目的: 检测 URLrewriting 处理后。
            // IIS 最终把什么样的路径，传递给 asp.net


            // 因为 MVC 的页面中， 如果路径中包含 非法字符，那么将报错。
            // 如果 URLrewriting 处理后， 还是把包含非法字符的地址传递给 asp.net 了。
            // 那么最后还是不满足预期需求的. 
            // 预期是： 非法的拦截掉， 错误的修正掉.


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("Application_BeginRequest! ip={0}, path = {1}",
                    Request.UserHostAddress,
                    this.Context.Request.RawUrl
                    );
            }

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

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

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}