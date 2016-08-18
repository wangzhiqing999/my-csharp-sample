using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.Login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // 这里简单把 用户数据， 暂存在 Application 里面.
            if (Application["TEST_USER"] == null)
            {
                Application.Add("TEST_USER", new Dictionary<string, string>());
            }

            Dictionary<string, string> userDictionary = Application["TEST_USER"] as Dictionary<string, string>;


            // 用户不存在的情况下， 新增.
            if (!userDictionary.ContainsKey(this.txtUserName.Text))
            {
                userDictionary.Add(this.txtUserName.Text, this.txtPassword.Text);
            }


            // 注册完毕， 页面迁移.
            Response.Redirect("LoginInfo.aspx", false); 

        }
    }
}