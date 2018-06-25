using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1050_Mvc5.Controllers
{
    /// <summary>
    /// 测试 Bundle 使用的例子.
    /// 
    /// 参考页面:
    /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/performance/bundling-and-minification
    /// </summary>
    public class TestBundleController : Controller
    {
        // GET: TestBundle
        public ActionResult Index()
        {
            return View();
        }
    }
}