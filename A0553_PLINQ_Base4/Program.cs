using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0553_PLINQ_Base4.Sample;

namespace A0553_PLINQ_Base4
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.TestNormal();
            t.TestParallel();
            t.TestParalle2();
            Console.ReadLine();
        }
    }
}
