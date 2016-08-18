using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.Login
{
    /// <summary>
    /// CustomerLogoutHandler 的摘要说明
    /// </summary>
    public class CustomerLogoutHandler : AbstractHandler<CommonHandleResult> 
    {

        protected override CommonHandleResult GetDefaultHandleResult()
        {
            return new CommonHandleResult()
            {
                Result = false,
            };
        }


        /// <summary>
        /// 登出处理.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        protected override void DoProcess(HttpContext context, CommonHandleResult result)
        {
            context.Session.Abandon();

            result.Result = true;
            result.ResultMessage = "登出成功！";
        }
    }
}