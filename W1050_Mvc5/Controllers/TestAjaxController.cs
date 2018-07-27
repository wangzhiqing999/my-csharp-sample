using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace W1050_Mvc5.Controllers
{
    public class TestAjaxController : Controller
    {
        // GET: TestAjax
        public ActionResult Index()
        {
            return View();
        }





        #region 测试一组连续调用的 Ajax 处理.


        public ActionResult TestStep123()
        {
            return View();
        }



        // 页面请求时，是先调用第一个请求。
        // 获取第一个请求的结果，来作为第二个请求的参数.
        // 获取第二个请求的结果，来作为第三个请求的参数.
        // 调用顺序为 TestStep1 --> TestStep2 --> TestStep3


        private Random myRandom = new Random();


        public JsonResult TestStep1()
        {
            // 为增加延迟效果，休眠1秒.
            Thread.Sleep(1000);

            int result = myRandom.Next(1, 10);
            return Json(result);
        }

        public JsonResult TestStep2(int id)
        {
            // 为增加延迟效果，休眠1秒.
            Thread.Sleep(1000);

            int result = myRandom.Next(10);
            while (result == id)
            {
                // 避免重复.
                result = myRandom.Next(10);
            }
            return Json(id * 10 + result);
        }

        public JsonResult TestStep3(int id)
        {
            // 为增加延迟效果，休眠1秒.
            Thread.Sleep(1000);

            int result = myRandom.Next(10);
            while (result == id / 10 || result == id % 10)
            {
                // 避免重复.
                result = myRandom.Next(10);
            }
            return Json(id * 10 + result);
        }

        #endregion




        #region 测试同时调用多个 Ajax 的处理.


        public ActionResult TestStepABC()
        {
            return View();
        }



        public JsonResult TestStepA()
        {
            // 为增加延迟效果，休眠2秒.
            // 这里休眠 2 秒的目的， 是为了确认画面结果的显示顺序。
            // 同时发起 TestStepA / TestStepB / TestStepC  请求。
            // TestStepA 最后才返回.
            // 而画面上是否能正确按顺序显示 TestStepA / TestStepB / TestStepC 的结果.
            Thread.Sleep(2000);

            int result = myRandom.Next(8);
            char resultChar = (char)('A' + result);
            return Json(resultChar);
        }

        public JsonResult TestStepB()
        {
            // 为增加延迟效果，休眠1秒.
            Thread.Sleep(1000);

            int result = myRandom.Next(8);
            char resultChar = (char)('H' + result);
            return Json(resultChar);
        }

        public JsonResult TestStepC()
        {
            // 为增加延迟效果，休眠1秒.
            Thread.Sleep(1000);

            int result = myRandom.Next(8);
            char resultChar = (char)('O' + result);
            return Json(resultChar);
        }

        #endregion



    }
}