using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using log4net;

using com.xxl.job.core.biz.model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XxlJob.Core;
using XxlJob.Core.DependencyInjection;
using XxlJob.WebApiHost;


namespace B3100_XxljobClient
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // ##########  Log4Net ÅäÖÃ.  ##########
            string webConfigFile = Server.MapPath("web.config");
            if (System.IO.File.Exists(webConfigFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(webConfigFile));
            }


            GlobalConfiguration.Configure(XxlJobConfig.Register);


            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);



            
        }
    }






    public static class XxlJobConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var services = new ServiceCollection()
                .AddXxlJob(xxlJob =>
                {
                    xxlJob
                        .Configure(option =>
                        {
                            option.AdminAddresses.Add("http://localhost:8080/xxl-job-admin");
                        });
                });

            config.EnableXxlJob(services.BuildServiceProvider());
        }
    }

}
