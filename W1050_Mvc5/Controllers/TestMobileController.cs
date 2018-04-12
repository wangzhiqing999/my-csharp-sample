using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1050_Mvc5.Controllers
{
    public class TestMobileController : Controller
    {
        // GET: TestMobile
        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 测试一个 错误页面.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestErrorPage() {

            // 数据异常.
            ViewBag.ErrMsg = "系统运行过程中，发生了一点点问题......";

            return View("../Shared/Error");

        }


    }
}