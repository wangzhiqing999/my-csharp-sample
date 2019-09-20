using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using W1050_Mvc5.Models;

namespace W1050_Mvc5.Controllers
{
    public class Testi18nController : Controller
    {
        // GET: Testi18n
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(TestModelData data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Message = "OK.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }


    }
}