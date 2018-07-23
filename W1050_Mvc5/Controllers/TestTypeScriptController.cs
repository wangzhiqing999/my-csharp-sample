using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace W1050_Mvc5.Controllers
{

    /// <summary>
    /// 测试 在项目中添加一个 typescript 脚本， 并尝试在页面中使用.
    /// </summary>
    public class TestTypeScriptController : Controller
    {

        // GET: TestTypeScript
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 子菜单.
        /// </summary>
        /// <returns></returns>
        public ActionResult SubMenu()
        {
            return PartialView();
        }





        /// <summary>
        /// 测试 TypeScript 调用已有的 JavaScript 库
        /// </summary>
        /// <returns></returns>
        public ActionResult TsCallJs()
        {
            return View();
        }


        /// <summary>
        /// 测试 TypeScript的变量声明 let 与 常量声明 const 
        /// </summary>
        /// <returns></returns>
        public ActionResult TestLetAndConst()
        {
            return View();
        }



        /// <summary>
        /// 测试 Promise 的使用.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestPromise()
        {
            return View();
        }



        /// <summary>
        /// 测试 async await 的使用.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestAsyncAwait()
        {
            return View();
        }



    }
}