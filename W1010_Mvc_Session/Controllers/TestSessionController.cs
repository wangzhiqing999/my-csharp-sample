using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1010_Mvc_Session.Controllers
{
    public class TestSessionController : Controller
    {
        //
        // GET: /TestSession/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string sessionValue) {

            Session["TEST"] = sessionValue;

            return View();
        }

    }
}
