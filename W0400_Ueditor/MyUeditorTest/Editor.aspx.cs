using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyUeditorTest
{
    public partial class Editor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["Text"] != null)
                {
                    this.hfResultData.Value = Session["Text"] as string;
                }
            }
        }


        /// <summary>
        /// 修改并更新.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["Text"] = this.hfResultData.Value;

            this.Response.Redirect("/Default.aspx");
        }


    }
}