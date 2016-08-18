using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1000_MVC.Controllers
{
    public class TestController : Controller
    {



        
        /// <summary>
        /// 测试 Get.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TestGet(string code,  string name)
        {
            string result = String.Format("Hello {0}, {1}!", code, name);
            return Content(result);
        }



        /// <summary>
        /// 测试 Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TestPost(string code, string name)
        {
            string result = String.Format("Hello {0}, {1}!", code, name);
            return Content(result);
        }


    }
}
