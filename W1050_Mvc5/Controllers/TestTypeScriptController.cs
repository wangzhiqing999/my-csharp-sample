using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using W1050_Mvc5.Models;

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




        /// <summary>
        /// 测试 interface 的使用.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestInterface()
        {
            return View();
        }

        /// <summary>
        /// 返回的结果的数据类型为 CommonServiceResult<int>，测试在 TypeScript 中，能否进行对结果的数据类型的定义。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult TestCommonService(int id)
        {
            if(id <= 0)
            {
                var errResult = CommonServiceResult<int>.DataNotFoundResult;
                return Json(errResult);
            }

            var result = CommonServiceResult<int>.CreateDefaultSuccessResult(id);
            return Json(result);
        }


    }
}