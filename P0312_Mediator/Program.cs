using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {

            P0312_Mediator.Sample.Demo.ShowDemo();
            Console.WriteLine();

            P0312_Mediator.SampleChatroom.Demo.ShowDemo();

            Console.ReadLine();
        }
    }
}
