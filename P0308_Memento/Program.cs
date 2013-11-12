using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento
{
    class Program
    {
        static void Main(string[] args)
        {

            P0308_Memento.Sample.Demo.ShowDemo();
            Console.WriteLine();

            P0308_Memento.SampleChess.Demo.ShowDemo();
            Console.WriteLine();

            P0308_Memento.SampleChessPlus.Demo.ShowDemo();

            Console.ReadLine();

        }
    }
}
