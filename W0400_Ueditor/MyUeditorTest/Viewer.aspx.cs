using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyUeditorTest
{
    public partial class Viewer : System.Web.UI.Page
    {

        protected string resultData;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Text"] != null)
                {
                    resultData = Session["Text"] as string;
                }
            }
        }
    }
}