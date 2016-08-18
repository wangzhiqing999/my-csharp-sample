using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.CrossDomain
{
    /// <summary>
    /// TestAjax 的摘要说明
    /// </summary>
    public class TestAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // 外部输入的域名.
            string hostName = HttpContext.Current.Request.Headers["host"];

            context.Response.ContentType = "text/plain";
            string callbackFunName = context.Request["callbackparam"];


            string testName = context.Request["name"];


            context.Response.Write(callbackFunName + "([ { name:\"John " + testName + "\",  hostname:\"" + hostName + "\"} ] )");
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