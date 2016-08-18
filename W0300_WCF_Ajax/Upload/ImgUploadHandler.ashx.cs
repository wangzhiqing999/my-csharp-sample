using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using W0300_WCF_Ajax.Common.ImgClassLib;


namespace W0300_WCF_Ajax.Upload
{
    /// <summary>
    /// 图片文件上传处理.
    /// </summary>
    public class ImgUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile hp = context.Request.Files["pic"];
            string waring = ""; //上传警告信息
            string savepath = ImageDealLib.uploadbystream(hp.InputStream, "/UploadImages/", out waring);
            context.Response.Write(savepath);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}