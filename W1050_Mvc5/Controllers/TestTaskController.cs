using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace W1050_Mvc5.Controllers
{
    public class TestTaskController : Controller
    {
        // GET: TestTask
        public ActionResult Index()
        {
            return View();
        }



        public async Task<ActionResult> Test()
        {
            string userName;
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            } 
            else
            {
                userName = "尚未登录.";
            }




            string taskUserName1 = string.Empty;
            string taskUserName2 = string.Empty;

            
            string environmentUserName1 = string.Empty;
            string environmentUserName2 = string.Empty;




            // 假设下面是一个耗时的操作.
            Task task1 = Task.Run(() => {

                Thread.Sleep(2000);

                if (User.Identity.IsAuthenticated)
                {
                    taskUserName1 = User.Identity.Name;
                }
                else
                {
                    taskUserName1 = "尚未登录.";
                }

                environmentUserName1 = Environment.UserName;
            });


            // 假设下面也是一个耗时的操作.
            Task task2 = Task.Factory.StartNew(() => {

                Thread.Sleep(2000);

                if (User.Identity.IsAuthenticated)
                {
                    taskUserName2 = User.Identity.Name;
                }
                else
                {
                    taskUserName2 = "尚未登录.";
                }


                environmentUserName2 = Environment.UserName;
            });



            // 这里是 等待两个假设的耗时操作，都完成。
            await Task.WhenAll(task1, task2);



            // 说明：
            // Task.WaitAll 是阻塞的。
            // Task.WhenAll 是异步的，非阻塞的。

            // 也就是， 如果 方法是 public ActionResult  方式定义的，那么用 Task.WaitAll  来等待耗时操作完成.
            // 如果方法是 public async Task<ActionResult>  方式定义的，那么用 await Task.WhenAll  来等待耗时操作完成.


            ViewBag.UserName = userName;
            ViewBag.TaskUserName1 = taskUserName1;
            ViewBag.TaskUserName2 = taskUserName2;



            ViewBag.EnvironmentUserName = Environment.UserName;
            ViewBag.EnvironmentUserName1 = environmentUserName1;
            ViewBag.EnvironmentUserName2 = environmentUserName2;

            return View();
        }



    }
}