using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Routing;


namespace W1050_Mvc5.Module
{

    /// <summary>
    /// 国际化的处理模块.
    /// 定义在  web.config 的 system.webServer 标签下.
    /// 
    /// </summary>
    public class CultureAwareHttpModule : IHttpModule
    {

        private CultureInfo currentCulture;
        private CultureInfo currentUICulture;

        public void Dispose() { }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += SetCurrentCulture;
            context.EndRequest += RecoverCulture;
        }
        private void SetCurrentCulture(object sender, EventArgs args)
        {
            currentCulture = Thread.CurrentThread.CurrentCulture;
            currentUICulture = Thread.CurrentThread.CurrentUICulture;
            HttpContextBase contextWrapper = new HttpContextWrapper(HttpContext.Current);
            RouteData routeData = RouteTable.Routes.GetRouteData(contextWrapper);
            if (routeData == null)
            {
                return;
            }
            object culture;
            if (routeData.Values.TryGetValue("lang", out culture))
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture.ToString());
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.ToString());
                }
                catch
                { }
            }
        }
        private void RecoverCulture(object sender, EventArgs args)
        {
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentUICulture;
        }



    }

}