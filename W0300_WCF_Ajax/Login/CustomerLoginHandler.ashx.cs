using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading;

namespace W0300_WCF_Ajax.Login
{
    /// <summary>
    /// CustomerLoginHandler 的摘要说明
    /// </summary>
    public class CustomerLoginHandler : AbstractHandler<LoginHandleResult> 
    {

        protected override LoginHandleResult GetDefaultHandleResult()
        {
            return new LoginHandleResult()
            {
                Result = false,
            };
        }



        /// <summary>
        /// 登录失败次数.
        /// </summary>
        private const string Session_Keyword_Is_Pbulic_User_LoginFailCount = "LoginFailCount";



        protected override void DoProcess(HttpContext context, LoginHandleResult result)
        {
            string userName = context.Request["u"];
            string password = context.Request["p"];
            string checkCode = context.Request["c"];

            int loginFailCount = 0;
            if (context.Session[Session_Keyword_Is_Pbulic_User_LoginFailCount] != null)
            {
                loginFailCount = Convert.ToInt32(context.Session[Session_Keyword_Is_Pbulic_User_LoginFailCount]);
            }


            if (String.IsNullOrEmpty(userName))
            {
                result.ResultMessage = "用户名没有填写！";
                return;
            }

            if (String.IsNullOrEmpty(password))
            {
                result.ResultMessage = "密码没有填写！";
                return;
            }


            if (loginFailCount > 0)
            {
                if (String.IsNullOrEmpty(checkCode))
                {
                    result.ResultMessage = "验证码没有填写！";
                    return;
                }
                string cc = context.Session["CheckCode"] as string;
                if (cc != checkCode.ToUpper())
                {
                    result.ResultMessage = "验证码不正确！";
                    return;
                }
            }


            // 这里简单把 用户数据， 暂存在 Application 里面.
            if (context.Application["TEST_USER"] == null)
            {
                Dictionary<string, string> tmpData = new Dictionary<string, string>();
                tmpData.Add("admin", "admin");
                context.Application.Add("TEST_USER", tmpData);
            }

            Dictionary<string, string> userDictionary = 
                context.Application["TEST_USER"] as Dictionary<string, string>;

           
            if (!userDictionary.ContainsKey(userName))
            {
                // 用户不存在.
                result.ResultMessage = "用户名不存在，或者密码错误！";
                loginFailCount++;
                context.Session[Session_Keyword_Is_Pbulic_User_LoginFailCount] = loginFailCount;
                return;
            }

            if (userDictionary[userName] != password)
            {
                // 密码不匹配.
                result.ResultMessage = "用户名不存在，或者密码错误！！";
                loginFailCount++;
                context.Session[Session_Keyword_Is_Pbulic_User_LoginFailCount] = loginFailCount;
                return;
            }




            // 成功.
            context.Session[Session_Keyword_Is_Pbulic_User] = userName;

            // 写入公用的数据.
            result.Result = true;
            result.ResultMessage = "登录成功！";

            // 写入独特的数据.
            result.NackName = "管理员";
        }


        protected override bool IsNeedLogin()
        {
            return false;
        }

    }
}