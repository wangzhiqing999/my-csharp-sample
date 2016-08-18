using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0500_MySqlSession
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnWriteSession_Click(object sender, EventArgs e)
        {
            Session["Test"] = this.txtSessionValue.Text;
        }


        /// <summary>
        /// 读取.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadSession_Click(object sender, EventArgs e)
        {
            this.lblSessionValue.Text = Session["Test"] as string;
        }



    }
}