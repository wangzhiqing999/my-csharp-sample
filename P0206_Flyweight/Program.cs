using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0206_Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {

            Simple.Client c1 = new Simple.Client();
            c1.Test();


            Compound.Client c2 = new Compound.Client();
            c2.Test();

            Console.ReadLine();
        }
    }
}
