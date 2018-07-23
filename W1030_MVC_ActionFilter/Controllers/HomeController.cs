using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


using W1030_MVC_ActionFilter.ActionFilters;


namespace W1030_MVC_ActionFilter.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 测试压缩.
        /// </summary>
        /// <returns></returns>
        [CompressFilter]
        public ActionResult TestCompress()
        {
            return View();
        }



        /// <summary>
        /// 测试去掉空格.
        /// </summary>
        /// <returns></returns>
        [WhitespaceFilterAttribute]
        public ActionResult TestWhitespace()
        {
            return View();
        }



        /// <summary>
        /// 测试 ETag
        /// </summary>
        /// <returns></returns>
        [ETagAttribute]
        public ActionResult TestETag()
        {
            return View();
        }



        /// <summary>
        /// 测试 TidyHtml
        /// </summary>
        /// <returns></returns>
        [TidyHtml]
        public ActionResult TestTidyHtml()
        {
            return View();
        }





        /// <summary>
        /// 测试 IActionFilter / IResultFilter 执行顺序.
        /// </summary>
        /// <returns></returns>
        [HelloWorldResultFilter]
        [HelloWorldActionFilter]
        public ActionResult HelloWorld()
        {
            return Content("<h3>Hello World</h3><br/>");
        }






        /// <summary>
        /// 测试超时.
        /// </summary>
        /// <returns></returns>
        [TimeoutFilter]
        public ActionResult TestTimeout(int sec = 1)
        {
            Thread.Sleep(sec * 1000);
            return View();
        }


    }
}
