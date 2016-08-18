using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0300_WCF_Ajax.Common.ImgClassLib;


namespace W0300_WCF_Ajax.Upload
{
    /// <summary>
    /// 图片缩略处理.
    /// </summary>
    public class ImgThumbHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string picpath = context.Request["picpath"]; 
            string warning = "";
            string suoluepic = ImageDealLib.Resizepic(picpath, ImageDealLib.ResizeType.XY, "/UploadImages/", ImageDealLib.ImageType.JPEG, 48, 48, ImageDealLib.FileCache.Save, out warning);
            context.Response.Write(suoluepic);
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