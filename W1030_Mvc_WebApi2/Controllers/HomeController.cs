using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1030_Mvc_WebApi2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult TestMyDemo()
        {
            return View();
        }


        public ActionResult TestMyDemoAxios()
        {
            return View();
        }




        public ActionResult TestMyDemoKnockout()
        {
            return View();
        }




        public ActionResult TestValues()
        {
            return View();
        }


        public ActionResult TestI18n()
        {
            return View();
        }



        /// <summary>
        /// 测试在 在ASP.NET WebAPI 中使用缓存.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestCacheOutput()
        {
            return View();
        }






        /// <summary>
        /// 测试 需要登录的 WebApi.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestNeedLogin()
        {
            return View();
        }


    }
}
