using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.Login
{
    public partial class LoginInfo : System.Web.UI.Page
    {

        /// <summary>
        /// 当前用户名.
        /// </summary>
        protected string userName;



        protected const string Session_Keyword_Is_Pbulic_User = "LoginUser";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session_Keyword_Is_Pbulic_User] == null)
            {
                // 当前用户未登录.
                this.pnlWithLogin.Visible = false;
                this.pnlWithoutLogin.Visible = true;
            }
            else
            {
                // 当前用户已登录.
                this.pnlWithLogin.Visible = true;
                this.pnlWithoutLogin.Visible = false;

                // 取得当前登录用户信息.
                userName = Session[Session_Keyword_Is_Pbulic_User] as string;

            }
        }



    }
}