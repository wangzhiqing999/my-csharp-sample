using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {

            P0311_Interpreter.Sample.Demo.ShowDemo();

            Console.WriteLine();

            P0311_Interpreter.SampleChineseNumber.Demo.ShowDemo();


            Console.WriteLine();

            P0311_Interpreter.SampleLogic.Demo.ShowDemo();

            Console.ReadLine();
        }
    }
}
