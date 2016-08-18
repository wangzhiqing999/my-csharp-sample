using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;


namespace W0300_WCF_Ajax.html5.pages
{
    public partial class RunLongTimePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Thread.Sleep(3000);

        }
    }
}