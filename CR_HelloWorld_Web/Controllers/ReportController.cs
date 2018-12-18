using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CR_HelloWorld_Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 明细页面.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult Detail(string id)
        {
            // 正常的业务逻辑，是这里根据参数， 判断报表/权限 等相关信息.
            // 这里只是单纯的测试 MVC 模式下，显示报表的处理.

            ViewBag.Name = id;
            return View();
        }


    }
}