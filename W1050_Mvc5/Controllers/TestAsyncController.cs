using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Threading;
using System.Threading.Tasks;




namespace W1050_Mvc5.Controllers
{
    public class TestAsyncController : Controller
    {


        // GET: TestAsync
        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 不使用 async  的处理.
        /// </summary>
        /// <returns></returns>
        public ActionResult WithoutAsync()
        {
            ViewBag.StartTime = DateTime.Now;

            ViewBag.Val1 = GetVal(1);
            ViewBag.Val2 = GetVal(2);
            ViewBag.Val3 = GetVal(3);

            return View(viewName: "~/Views/TestAsync/TestAsync.cshtml");
        }


        /// <summary>
        /// 使用 async  的处理.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> WithAsync()
        {
            ViewBag.StartTime = DateTime.Now;

            Task<int> t1 = GetAsyncVal(1);
            Task<int> t2 = GetAsyncVal(2);
            Task<int> t3 = GetAsyncVal(3);

            await t1;
            await t2;
            await t3;

            ViewBag.Val1 = t1.Result;
            ViewBag.Val2 = t2.Result;
            ViewBag.Val3 = t3.Result;

            return View(viewName: "~/Views/TestAsync/TestAsync.cshtml");
        }



        /// <summary>
        /// 使用 Task.WaitAll  的处理.
        /// </summary>
        /// <returns></returns>
        public ActionResult UseTaskWaitAll()
        {
            ViewBag.StartTime = DateTime.Now;

            Task[] tasks = new Task[]
                {
                    Task.Factory.StartNew(() =>ViewBag.Val1 = GetVal(1)),
                    Task.Factory.StartNew(() =>ViewBag.Val2 = GetVal(2)),
                    Task.Factory.StartNew(() =>ViewBag.Val3 = GetVal(3)),
                };

            Task.WaitAll(tasks);

            return View(viewName: "~/Views/TestAsync/TestAsync.cshtml");
        }



        /// <summary>
        /// 使用 await Task.WhenAll  的处理.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UseTaskWhenAll()
        {
            ViewBag.StartTime = DateTime.Now;

            Task[] tasks = new Task[]
                {
                    Task.Factory.StartNew(() =>ViewBag.Val1 = GetVal(1)),
                    Task.Factory.StartNew(() =>ViewBag.Val2 = GetVal(2)),
                    Task.Factory.StartNew(() =>ViewBag.Val3 = GetVal(3)),
                };

            await Task.WhenAll(tasks);

            return View(viewName: "~/Views/TestAsync/TestAsync.cshtml");
        }






        #region 用于模拟耗时的操作处理.


        private static Random random = new Random();


        private static int GetVal(int i)
        {
            Thread.Sleep(i * 1000);            
            return random.Next(100);
        }



        // 注意:
        // 通常全套异步需要做一些额外的工作，下面是一些必须做的额外工作。
        // 当                            	不要使用							使用
        // 需要获得值的时候                 Task.Wait or Task.Result            await
        // 需要等待任何一个任务				Task.WaitAny                    	await Task.WhenAny
        // 需要等待所有任务完成				Task.WaitAll						await Task.WhenAll
        // 需要等待							Thread.Sleep						await Task.Delay

        // 当然如果你不打算全套使用async, 那么请必须注意处理好异常信息以及防止死锁的一些方法。


        static async Task<int> GetAsyncVal(int i)
        {
            await Task.Delay(i * 1000);
            return random.Next(100); 
        }

        #endregion 用于模拟耗时的操作处理.


		
		// 注意：  MVC 5不支持分部视图的异步，MVC 6支持。


        /// <summary>
        /// 使用分布视图.
        /// </summary>
        /// <returns></returns>
        public ActionResult UsePartialView()
        {
            return View();
        }


        /// <summary>
        /// 分布视图.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WithoutAsyncSub(int id)
        {
            ViewBag.StartTime = DateTime.Now;
            ViewBag.Val = GetVal(id);
            return PartialView();
        }


    }
}