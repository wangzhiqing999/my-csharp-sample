using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1005_MVC_Sub.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }




        public ActionResult TestCss()
        {
            return View();
        }


        public ActionResult TestJs()
        {
            return View();
        }


        public ActionResult TestImage()
        {
            return View();
        }




        public ActionResult TestJson()
        {
            string appPath = Request.ApplicationPath;
            if (!appPath.EndsWith("/"))
            {
                appPath = appPath + "/";
            }
            ViewBag.AppPath = appPath;

            return View();
        }



        public JsonResult TestAjaxFunc(string id)
        {
            var result = new 
            { 
                Result = true,
                Message = "测试" + id
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
