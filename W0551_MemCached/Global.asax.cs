using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace W0551_MemCached
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // ##########  Log4Net 配置.  ##########

            string webConfigFile = Server.MapPath("web.config");
            if (System.IO.File.Exists(webConfigFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(webConfigFile));
            }

        }



        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}