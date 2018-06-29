using System.Web;
using System.Web.Optimization;

namespace W1050_Mvc5
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));




            // 单纯的测试使用 Bundle 来打包压缩 js 的处理.
            bundles.Add(new ScriptBundle("~/bundles/myTestService").Include(
                      "~/Scripts/myTestService.js"));


            // 目标文件是由 TypeScript 编译为 JavaScript 的.
            bundles.Add(new ScriptBundle("~/bundles/myHelloWorld").Include(
                      "~/Scripts/myHelloWorld.js"));

        }
    }
}
