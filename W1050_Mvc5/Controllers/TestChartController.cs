using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Helpers;


namespace W1050_Mvc5.Controllers
{
    public class TestChartController : Controller
    {
        // GET: TestChart
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 柱状图.
        /// </summary>
        /// <returns></returns>
        public ActionResult Column()
        {
            var chart = new Chart(width: 600, height: 400
             , theme: ChartTheme.Green
             , themePath: null
            );

            // 设置标题.
            chart.AddTitle(text: "chat title", name: "chat1");

            string chartType = "Column";

            chart.AddSeries(
                    name: "Stuednt"
                    , xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "张1" }
                    , yValues: new[] { "2", "6", "4", "5", "3" }
                    , chartType: chartType
                    , axisLabel: "获取或设置系列的轴标签文本"
                    , legend: null
                    , markerStep: 3
                    );

            return PartialView(model : chart);
        }




        public ActionResult Pie()
        {
            var chart = new Chart(width: 600, height: 400
             , theme: ChartTheme.Green
             , themePath: null
            );

            // 设置标题.
            chart.AddTitle(text: "chat title", name: "chat1");

            string chartType = "Pie";

            chart.AddSeries(
                    name: "Stuednt"
                    , xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "张1" }
                    , yValues: new[] { "2", "6", "4", "5", "3" }
                    , chartType: chartType
                    , axisLabel: "获取或设置系列的轴标签文本"
                    , legend: null
                    , markerStep: 3
                    );

            return PartialView(model: chart);
        }


    }
}