using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.Upload
{
    public partial class UploadPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 确定.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            this.lblUploadFileName.Text = this.hfPicFileList.Value;
        }
    }
}