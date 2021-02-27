using System;
using System.Collections.Generic;
using System.Diagnostics;
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





        #region 测试取消 Ajax 请求.


        public ActionResult TestAbort()
        {
            return View();
        }

        /// <summary>
        /// 测试长时间处理.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult TestLongTime(int id)
        {
            Thread.Sleep(1000 * id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }


        #endregion








        #region 测试 X --> (Y & Z) 的逻辑.


        public ActionResult TestStepXYZ()
        {
            return View();
        }




        public JsonResult TestStepXY()
        {
            int result = myRandom.Next(3);
            char resultChar = (char)('A' + result);

            var x = new
            {
                id = "1",
                name = resultChar,
                text = "for a background process..."
            };


            // 如果直接这么写，将导致 TestStepXY 整体耗时过长.
            // DoFuncY(x);


            ParameterizedThreadStart ts = new ParameterizedThreadStart(this.DoFuncY);
            Thread t = new Thread(ts);
            // 启动.
            t.Start(x);


            return Json(result);
        }



        /// <summary>
        /// 这个模拟一个后台耗时的操作.
        /// 此操作结果， 不影响页面的返回.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        private void DoFuncY(dynamic x)
        {

            string defbugInfo = string.Format("{0}:{1}:{2}", x.id, x.name, x.text);

            Debug.WriteLine(defbugInfo);

            Thread.Sleep(3000);


            Debug.WriteLine("Finish!");

        }




        public JsonResult TestStepZ(int z)
        {
            Thread.Sleep(2000);
            char resultChar = (char)('X' + z);
            return Json(resultChar);
        }





        #endregion


    }
}