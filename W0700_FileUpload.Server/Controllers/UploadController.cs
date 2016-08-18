using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W0700_FileUpload.Server.Controllers
{
    public class UploadController : Controller
    {


        //
        // GET: /Upload/
        public ActionResult Index()
        {
            return View();
        }



        [ActionName("Index")]
        [HttpPost]
        public ActionResult UploadFile()
        {

            try
            {

                foreach (string f in Request.Files.AllKeys)
                {
                    HttpPostedFileBase uploadFile = Request.Files[f];
                                   
                    if (uploadFile != null && !String.IsNullOrEmpty(uploadFile.FileName))
                    {
                        // 取得上传的文件名.
                        string uploadFileName = System.IO.Path.GetFileName(uploadFile.FileName);
                        // 取得 扩展名...
                        string ext = uploadFileName.Substring(uploadFileName.LastIndexOf("."));
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                        string filePhysicalPath = Server.MapPath("~/UploadFiles/" + fileName);

                        uploadFile.SaveAs(filePhysicalPath);
                    }
                }
                return Content("OK");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            
        }


    }
}
