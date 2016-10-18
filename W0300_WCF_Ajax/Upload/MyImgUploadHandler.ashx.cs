using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;


using W0300_WCF_Ajax.Common.ImgClassLib;


namespace W0300_WCF_Ajax.Upload
{



    /// <summary>
    /// 图片文件上传处理.
    /// </summary>
    public class MyImgUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files == null || context.Request.Files.Count == 0)
            {
                var errResult = new
                {
                    Result = false,
                };

                context.Response.Write(JsonConvert.SerializeObject(errResult));
                return;
            }

            HttpPostedFile hp = context.Request.Files[0];
            string waring = ""; //上传警告信息
            string savepath = ImageDealLib.uploadbystream(hp.InputStream, "/UploadImages/", out waring);




            List<UploadImageResult> uploadResult = new List<UploadImageResult>();

            uploadResult.Add(new UploadImageResult() { path = savepath, name = hp.FileName, size = hp.ContentLength});

            context.Response.Write(JsonConvert.SerializeObject(uploadResult));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



        public class UploadImageResult
        {
            public string path { set; get; }


            public string name { set; get; }


            public int size { set; get; }
        }
    }



}