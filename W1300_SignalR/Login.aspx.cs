using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;



namespace W1300_SignalR
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // 模拟登录成功.
            FormsAuthentication.SetAuthCookie(this.txtUserName.Text, false);

            this.Response.Clear();//这里是关键，清除在返回前已经设置好的标头信息，这样后面的跳转才不会报错
            this.Response.BufferOutput = true;//设置输出缓冲

            Response.Redirect("index.html");
        }
    }
}