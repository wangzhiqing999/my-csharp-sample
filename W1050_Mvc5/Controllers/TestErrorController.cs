using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1050_Mvc5.Controllers
{
    public class TestErrorController : Controller
    {
        // GET: TestError
        public ActionResult Index()
        {
            return View();
        }




        #region 404页面.

        /// <summary>
        /// 页面不存在.
        /// </summary>
        /// <returns></returns>
        public ActionResult PageNotFound()
        {
            Response.Status = "404 Not Found";
            Response.StatusCode = 404;
            return View();
        }

        #endregion


    }
}