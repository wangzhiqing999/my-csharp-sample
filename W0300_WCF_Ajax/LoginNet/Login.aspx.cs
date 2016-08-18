using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.LoginNet
{
    public partial class Login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                // 保存上一个页面的地址.
                ViewState["PrevPage"] = HttpContext.Current.Request.UrlReferrer;
            }


        }



        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!LoginService.DoLogin(  this.txtUserName.Text ,  this.txtPassword.Text))
            {
                // js 代码.
                string jsScript = String.Format(
                    "<script language=JavaScript> alert('用户名或密码错误！'); </script>");

                // 调用.
                this.ClientScript.RegisterStartupScript(this.GetType(), "MsgBox", jsScript);

                return;
            }


            if (this.chkAutoLogin.Checked)
            {
                // 自动登录.


                //1。创建Cookie对象
                HttpCookie newCookie = new HttpCookie("User");

                //2。Cookie中添加信息项：为键值对，key/value
                newCookie.Values.Add("Name", txtUserName.Text.Trim());
                newCookie.Values.Add("psd", txtPassword.Text.Trim());

                //3。如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失
                newCookie.Expires = DateTime.Now.AddDays(30);  //设置过期天数为30天

                //4。写入Cookies集合
                Response.AppendCookie(newCookie);
            }




            // 会话登录.
            Session["LoginNet"] = "test";

            // js 代码.
            string jsScript2 = String.Format(
                "<script language=JavaScript> window.location.href = '{0}' </script>", ViewState["PrevPage"]);

            // 调用.
            this.ClientScript.RegisterStartupScript(this.GetType(), "MsgBox", jsScript2);


        }
    }
}