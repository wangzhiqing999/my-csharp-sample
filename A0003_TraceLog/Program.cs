using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0003_TraceLog.Sample;



namespace A0003_TraceLog
{
    class Program
    {

        static void Main(string[] args)
        {

            TestTraceLog test = new TestTraceLog();

            test.BuyItem(1, 100);


            test.BuyItem(-1, 100);


            test.BuyItem(1, -100);


            



            Console.ReadLine();


        }
    }
}
