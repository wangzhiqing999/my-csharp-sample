using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.LoginNet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                // 尝试自动登录.
                TryAutoLogin();


                // 显示当前的登录信息.
                ShowBasicLoginInfo();
            }
        }




        /// <summary>
        /// 注销.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {

            // 设置 Cookie 立即超时.

            // 通过Request对象读取得到Cookies的值
            HttpCookie newCookie = Request.Cookies["User"];


            if (newCookie != null)
            {
                // 通过Response对象写入客户端的Cookie
                newCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(newCookie);
            }



            // 设置会话结束.
            Session["LoginNet"] = null;


            // 显示当前的登录信息.
            ShowBasicLoginInfo();
        }






        /// <summary>
        /// 尝试自动登录.
        /// </summary>
        private void TryAutoLogin()
        {


            if (Session["LoginNet"] != null)
            {
                // 已登录了，不需要重复处理.
                return;
            }



            // 通过Request对象读取得到Cookies的值
            HttpCookie newCookie = Request.Cookies["User"];

            if (newCookie != null)
            {
                string username = newCookie.Values["Name"];
                string password = newCookie.Values["psd"];


                if (LoginService.DoLogin(username, password))
                {
                    // 自动登录成功.

                    // 登录.
                    Session["LoginNet"] = "test";
                }
            }


        }





        /// <summary>
        /// 显示是否登录的信息.
        /// </summary>
        private void ShowBasicLoginInfo()
        {
            // 判断是否登录.
            if (Session["LoginNet"] == null)
            {
                // 未登录.
                this.pnlWithLogin.Visible = false;
                this.pnlWithOutLogin.Visible = true;
            }
            else
            {
                // 已登录.
                this.pnlWithLogin.Visible = true;
                this.pnlWithOutLogin.Visible = false;
            }
        }


    }
}