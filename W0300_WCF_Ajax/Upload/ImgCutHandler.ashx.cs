using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using W0300_WCF_Ajax.Common.ImgClassLib;


namespace W0300_WCF_Ajax.Upload
{

    /// <summary>
    /// 图片文件裁减处理.
    /// </summary>
    public class ImgCutHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int x1 = int.Parse(context.Request["x1"]);
            int y1 = int.Parse(context.Request["y1"]);
            int width = int.Parse(context.Request["width"]);
            int height = int.Parse(context.Request["height"]);
            string picpath = context.Request["picpath"];
            string warning = "";  //剪辑警告信息
            string d = ImageDealLib.imgcrop(picpath, "/UploadImages/", x1, y1, width, height, ImageDealLib.FileCache.Save, out warning);
            context.Response.Write(d);
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