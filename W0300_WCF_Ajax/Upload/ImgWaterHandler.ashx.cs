using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0300_WCF_Ajax.Common.ImgClassLib;


namespace W0300_WCF_Ajax.Upload
{
    /// <summary>
    /// 水印的处理
    /// </summary>
    public class ImgWaterHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string picpath = context.Request["picpath"];
            string warning = "";
            string waterpic = ImageDealLib.makewatermark(
                picpath,
                "/UploadImages/dolphin48.png", 
                ImageDealLib.WaterType.RightDown,
                "/UploadImages/", 
                ImageDealLib.ImageType.JPEG, 
                ImageDealLib.FileCache.Save,
                out warning);
            context.Response.Write(waterpic);
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