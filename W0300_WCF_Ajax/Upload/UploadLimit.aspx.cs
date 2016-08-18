using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.Upload
{
    public partial class UploadLimit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }





        /// <summary>
        /// 上传文件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.FileUpload1.PostedFile.FileName))
            {
                lblResult.Text = "请先选择好文件以后，再按[上传文件]按钮！";
                return;
            }

            // 客户端文件名.
            lblClientFileName.Text = this.FileUpload1.PostedFile.FileName;

            // 上传后的 服务器文件名称.
            lblServerFileNam.Text = Server.MapPath("~/Upload/") + DateTime.Now.ToString("yyyyMMddHHmmss");

            // 保存.
            this.FileUpload1.PostedFile.SaveAs(lblServerFileNam.Text);

            lblResult.Text = "文件上传成功！";

        }


    }
}