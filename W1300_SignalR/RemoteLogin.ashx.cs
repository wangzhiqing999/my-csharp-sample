using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;

namespace W1300_SignalR
{
    /// <summary>
    /// RemoteLogin 的摘要说明
    /// </summary>
    public class RemoteLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // 模拟登录成功.
            FormsAuthentication.SetAuthCookie(context.Request["UserName"], false);

            context.Response.Write("OK");
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}