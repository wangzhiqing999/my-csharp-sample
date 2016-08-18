using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.Favorite
{
    public partial class Index : System.Web.UI.Page
    {

        public string browserName;
        public string userAgent;


        protected void Page_Load(object sender, EventArgs e)
        {

            // 取得浏览器.
            this.browserName = Request.Browser.Browser;

            // User-Agent
            this.userAgent = Request.UserAgent;



            if ("Unknown" == this.browserName)
            {
                // 未知的浏览器.

                if (!String.IsNullOrEmpty(userAgent))
                {
                    if (userAgent.Contains("Fire"))
                    {
                        this.browserName = "Firefox";
                    }
                }
            }



        }
    }
}