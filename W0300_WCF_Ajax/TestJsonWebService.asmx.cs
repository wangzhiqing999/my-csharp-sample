using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace W0300_WCF_Ajax
{
    /// <summary>
    /// 主要是测试   使用  Json  的 Web 服务.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class TestJsonWebService : System.Web.Services.WebService
    {


        #region  关于 Session 的处理.


        /// <summary>
        /// 测试 登录处理.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public bool TestLogin(string userName, string password)
        {
            if (userName == "admin" && password == "123456")
            {
                Session["SystemUser"] = userName;
                return true;
            }

            Session["SystemUser"] = null;
            return false;
        }



        /// <summary>
        /// 测试一个  需要登录了， 才能访问的服务.
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string TestDoSomethingNeedLogin()
        {
            string userName = Session["SystemUser"] as string;

            if (String.IsNullOrEmpty(userName))
            {
                return "你尚未登录到系统中，无法执行此操作！";
            }

            return String.Format("您好！ {0} , 欢迎使用本系统！", userName);
        }


        #endregion  关于 Session 的处理.


    }
}
