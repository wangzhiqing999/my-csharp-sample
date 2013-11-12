using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0551_PLINQ_Base2.Sample;


namespace A0551_PLINQ_Base2
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.TestNormal();
            t.TestParallel();

            Console.ReadLine();
        }
    }
}
