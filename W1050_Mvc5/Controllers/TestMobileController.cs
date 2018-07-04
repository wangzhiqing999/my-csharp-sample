using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W1050_Mvc5.Controllers
{
    public class TestMobileController : Controller
    {
        // GET: TestMobile
        public ActionResult Index(string display)
        {
            if (!String.IsNullOrEmpty(display))
            {
                // Cookie 中，设置具体的显示方式.
                HttpCookie cookie = Request.Cookies["DISPLAY"];
                if(cookie != null){
                    cookie.Value = display;
                } else {
                    cookie = new HttpCookie("DISPLAY", display);
                }

                // 写入Cookies集合.
                Response.AppendCookie(cookie);
            }

            return View();
        }




        /// <summary>
        /// 测试一个 错误页面.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestErrorPage() {
            // 数据异常.
            ViewBag.ErrMsg = "系统运行过程中，发生了一点点问题......";
            return View("../Shared/Error");
        }



        /// <summary>
        /// 测试分布视图.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPartialView()
        {
            return PartialView();
        }




        /// <summary>
        /// 测试 OutputCache 标签.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 30)]
        public ActionResult TestOutputCache()
        {

            // 这里测试的目标， 是观察.
            // 加了 [OutputCache] 的方法.
            // 会不会影响 页面.
            ViewBag.Date = DateTime.Now;


            // 这里是测试是缓存 30秒。
            // 结果，开2个页面， 1个 PC. 1个 手机。
            // PC 先刷新， 30秒内， 手机后刷新。
            // 结果， 手机那里， 显示的是 PC 的页面了.
            return View();
        }




        /// <summary>
        /// 测试 OutputCache 标签 + VaryByCustom 属性.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 30, VaryByCustom = "DisplayMode", VaryByParam="id")]
        public ActionResult TestOutputCacheVaryByCustom(int id = 1)
        {

            // 这里测试的目标， 是观察.
            // 加了 [OutputCache] 的方法.
            // 会不会影响 页面.
            ViewBag.Date = DateTime.Now;


            // 这里是测试 VaryByCustom 与 VaryByParam 是否能同时生效.
            ViewBag.ID = id;


            // 注意：本来预期是只加  VaryByCustom = "DisplayMode"， 能实现区分缓存 pc / 手机 / 平板
            // 但是在 Global.asax 的 GetVaryByCustomString 方法里面， HttpContext 里面， Session 为空.
            // 最后， 将 DisplayConfig 的判断逻辑， 由 先判断 Session 变更为 先判断 Cookie .
            // 本控制器的 Index 切换设备的方法， 由往 Session 里面写设备类型， 变更为往 Cookie 里面写设备类型.

            return View();
        }




        /// <summary>
        /// 测试 OutputCache 标签 + VaryByHeader 属性.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 30, VaryByHeader = "User-Agent")]
        public ActionResult TestOutputCacheVaryByHeader()
        {
            // 这里测试的目标， 是观察.
            // 加了 [OutputCache] 的方法.
            // 会不会影响 页面.
            ViewBag.Date = DateTime.Now;
           

            return View();
        }


    }
}