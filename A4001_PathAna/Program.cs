using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A4001_PathAna.Model;
using A4001_PathAna.Service;


namespace A4001_PathAna
{
    class Program
    {
        static void Main(string[] args)
        {

            // 构造一个 图.
            Graph graph = new Graph();
            graph.Init();



            // 最短路径计算.
            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = planner.Paln(graph.NodeList, "A", "D");

            // 输出结果.
            Console.WriteLine(result.ToString());


            Console.ReadLine();


        }
    }
}
