using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.Login
{
    /// <summary>
    /// CustomerUserNameCheckHandler 的摘要说明
    /// </summary>
    public class CustomerUserNameCheckHandler : AbstractHandler<CommonHandleResult> 
    {

        protected override CommonHandleResult GetDefaultHandleResult()
        {
            return new CommonHandleResult()
            {
                Result = false,
            };
        }


        protected override void DoProcess(HttpContext context, CommonHandleResult result)
        {
            string userName = context.Request["u"];


            // 这里简单把 用户数据， 暂存在 Application 里面.
            if (context.Application["TEST_USER"] == null)
            {
                Dictionary<string, string> tmpData = new Dictionary<string, string>();
                tmpData.Add("admin", "admin");
                context.Application.Add("TEST_USER", tmpData);
            }

            Dictionary<string, string> userDictionary =
                context.Application["TEST_USER"] as Dictionary<string, string>;


            if (userDictionary.ContainsKey(userName))
            {
                result.ResultMessage = "该用户名已存在！";
                return;
            }


            result.Result = true;
        }


        protected override bool IsNeedLogin()
        {
            return false;
        }

    }
}