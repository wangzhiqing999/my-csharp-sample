using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

using System.IO;  


namespace W0300_WCF_Ajax
{


    /// <summary>
    ///  接收照片上传的处理.
    /// </summary>
    public class PhotoUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string base64String = context.Request["data"];
            Image img = this.Base64ToImage(base64String);

            // 获取文件名.
            string uploadFileName = HttpContext.Current.Request.MapPath("~\\UploadPhoto.jpg");

            // 儲存圖片.
            img.Save(uploadFileName);  
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



        // 把base64字串轉成Image物件  
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]  
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image  
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            return image;
        }  

    }
}