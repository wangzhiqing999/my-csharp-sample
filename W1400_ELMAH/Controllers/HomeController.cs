using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1400_ELMAH.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 测试异常
        /// </summary>
        /// <returns></returns>
        public JsonResult GetError()
        {
            var a = 0;
            var b = 5;
            var c = b / a;
            return Json(a, JsonRequestBehavior.AllowGet);
        }

    }
}