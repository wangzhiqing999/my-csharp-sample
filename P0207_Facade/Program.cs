using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0207_Facade.Sample;

namespace P0207_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            WithOutFacadeClient c1 = new WithOutFacadeClient();
            c1.Test();

            Console.WriteLine();

            WithFacadeClient c2 = new WithFacadeClient();
            c2.Test();

            Console.ReadLine();
        }
    }
}
