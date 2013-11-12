using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0050_TryCatchFinally.Sample;


namespace A0050_TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            test.TestBase();


            test.TestReturn();


            Console.ReadLine();
        }

    }
}
