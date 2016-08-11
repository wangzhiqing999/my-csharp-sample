using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0101_Maze.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            G0101_Maze.Service.MazeTest test = new Service.MazeTest();
            test.BaseGetterTest();
            test.GameTest();


            Console.WriteLine("本项目是一个 Nunit 的单元测试，请通过 Nunit 来运行本程序！");
            Console.ReadLine();
        }
    }
}
