using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0552_PLINQ_Base3.Sample;


namespace A0552_PLINQ_Base3
{
    class Program
    {
        static void Main(string[] args)
        {

            Test t = new Test();
            t.TestNormal();
            t.TestParallel();
            t.TestParallel2();
            Console.ReadLine();

        }
    }
}
