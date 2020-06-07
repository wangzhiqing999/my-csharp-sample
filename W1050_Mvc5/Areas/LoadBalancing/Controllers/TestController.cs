using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;


namespace W1050_Mvc5.Areas.LoadBalancing.Controllers
{

    /// <summary>
    /// 负载均衡测试
    /// </summary>
    public class TestController : Controller
    {

        /// <summary>
        /// 负载均衡的 服务器代码.
        /// </summary>
        private static readonly string _ServerCode = ConfigurationManager.AppSettings["LoadBalancing:ServerCode"];


        /// <summary>
        /// 负载均衡 Session 测试关键字.
        /// </summary>
        private const string LOAD_BALANCING_SESSION_TEST = "LOAD_BALANCING_SESSION_TEST";



        // GET: LoadBalancing/Test
        /// <summary>
        /// 测试页首页.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.ServerCode = _ServerCode;
            return View();
        }




        /// <summary>
        /// 设置 Session 数值.
        /// </summary>
        /// <param name="vaule"></param>
        /// <returns></returns>
        public ActionResult SetSessionValue(string vaule)
        {
            Session[LOAD_BALANCING_SESSION_TEST] = vaule;
            return RedirectToAction("Index");
        }


    }
}