using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nancy;


namespace W5001_Nancy
{

    /// <summary>
    /// 这里测试  SSVE  (Super Simple View Engine )
    /// 
    /// 参考网页: http://www.tuicool.com/articles/MBRZVvv
    /// </summary>
    public class SSVEModule : NancyModule
    {

        public SSVEModule()
            : base("/SSVE")
        {


            // 简单测试  Model 页面， 与 HTML Encoding
            Get["/"] = _ =>
            {
                var os = System.Environment.OSVersion;
                var model = "Hello SSVE<br/> System:" + os.VersionString;

                return View["index", model];
            };


            // 简单测试  Model 
            Get["/model"] = _ =>
            {
                var model = "我是字符串";
                return View["model", model];
            };


            // 测试 略微复杂的 Model 
            Get["/modelplus"] = _ =>
            {
                var model = new { Name = "张三", Desc = "测试用户", Age = 30 };
                return View["modelplus", model];
            };



            // 测试 Each
            Get["/each"] = _ =>
            {
                var arr = new int[] { 3, 6, 9, 12, 15, 12, 9, 6, 3 };
                return View["each", arr];
            };


            // 测试 If
            Get["/if"] = _ =>
            {
                return View["if", new { HasModel = true }];
            };


            Get["/MasterDetail"] = _ =>
            {
                return View["Detail.html"];
            };
        }
    }
}
