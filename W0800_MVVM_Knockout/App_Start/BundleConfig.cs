using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;



namespace W0800_MVVM_Knockout
{

    public class BundleConfig
    {

        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css"
                        ));

        }

    }


}