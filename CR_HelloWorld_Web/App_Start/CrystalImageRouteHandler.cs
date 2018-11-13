using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;  


namespace CR_HelloWorld_Web
{

    /// <summary>
    /// 水晶报表图片的处理.
    /// </summary>
    public class CrystalImageRouteHandler : IRouteHandler
    {
        public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CrystalDecisions.Web.CrystalImageHandler();
        }
    }


}