using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace W1050_Mvc5.Controllers
{
    public class TestRedirectController : Controller
    {
        // GET: TestRedirect
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 客户端重定向.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TestRedirect(string id)
        {

            // 3种不同的方式， 进行跳转.
            if(id == "1")
            {
                return Redirect("/TestRedirect/Page1");
            }
            else if (id == "2")
            {
                return RedirectToAction(controllerName: "TestRedirect", actionName: "Page2");
            }
            else if (id == "3")
            {
                return RedirectToRoute(new { controller = "TestRedirect", action = "Page3" });
            }
            else if (id == "4")
            {
                return Redirect("/TestHtml/TestPage.html");
            }

            return new EmptyResult();
        }




        /// <summary>
        /// 服务端重定向.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TestForword(string id)
        {

            // 3种不同的方式， 进行跳转.
            if (id == "1")
            {
                return new MVCTransferResult("/TestRedirect/Page1");
            }
            else if (id == "2")
            {
                return new MVCTransferResult(new { controller = "TestRedirect", action = "Page2" });
            }
            else if (id == "3")
            {
                return new MVCTransferResult(new { controller = "TestRedirect", action = "Page3" });
            }
            else if (id == "4")
            {
                return new MVCTransferResult("/TestHtml/TestPage.html");
            }

            return new EmptyResult();
        }






        public ActionResult Page1()
        {
            return View();
        }


        public ActionResult Page2()
        {
            return View();
        }


        public ActionResult Page3()
        {
            return View();
        }



    }







    // 注意：  本项目是一个 测试的项目。
    // 因此， 下面的类写在一个控制器的类文件里面。
    // 实际项目中， 应该放在合适的位置上。



    public class MVCTransferResult : RedirectResult
    {
        public MVCTransferResult(string url)
            : base(url)
        {
        }

        public MVCTransferResult(object routeValues) : base(GetRouteURL(routeValues))
        {
        }

        private static string GetRouteURL(object routeValues)
        {
            UrlHelper url = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()), RouteTable.Routes);
            return url.RouteUrl(routeValues);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = HttpContext.Current;

            // ASP.NET MVC 3.0
            if (context.Controller.TempData != null &&
                context.Controller.TempData.Count() > 0)
            {
                throw new ApplicationException("TempData won't work with Server.TransferRequest!");
            }

            httpContext.Server.TransferRequest(Url, true); // change to false to pass query string parameters if you have already processed them

            // ASP.NET MVC 2.0
            //httpContext.RewritePath(Url, false);
            //IHttpHandler httpHandler = new MvcHttpHandler();
            //httpHandler.ProcessRequest(HttpContext.Current);
        }
    }




}