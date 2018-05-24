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


    }
}
