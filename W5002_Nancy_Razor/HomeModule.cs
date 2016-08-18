using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Nancy;


namespace W5002_Nancy_Razor
{

    public class HomeModule : NancyModule
    {

        public HomeModule()
        {


            // 测试 根节点.
            Get["/"] = _ =>
            {
                var model = "我是 Razor 引擎";
                return View["index", model];
            };


            // 测试 Razor 的 Each
            Get["/each"] = r =>
            {
                var arr = new int[] { 3, 6, 9, 12, 15, 12, 9, 6, 3 };
                return View["each", arr];
            };



        }

    }
}
