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



        /// <summary>
        /// 测试页面返回的就是 HttpNotFound
        /// </summary>
        /// <returns></returns>
        public ActionResult ResultHttpNotFound()
        {
            // 注意：
            // 普通的 404 ， 通过 Global.asax.cs 中的 Application_Error 进行设置.
            // HttpNotFound() 的 404，通过 Web.config 的 <system.webServer> 下面的 <httpErrors errorMode="Custom"> 进行设置.
            return HttpNotFound();
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