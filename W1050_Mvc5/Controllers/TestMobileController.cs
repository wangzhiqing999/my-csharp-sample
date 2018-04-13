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
        public ActionResult Index(string display)
        {
            if (!String.IsNullOrEmpty(display))
            {
                // Session 中，设置具体的显示方式.
                Session["DISPLAY"] = display;
            }

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



        /// <summary>
        /// 测试分布视图.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPartialView()
        {
            return PartialView();
        }

    }
}