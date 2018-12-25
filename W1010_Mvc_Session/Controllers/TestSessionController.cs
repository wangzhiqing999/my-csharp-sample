using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using log4net;


namespace W1010_Mvc_Session.Controllers
{
    public class TestSessionController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



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
