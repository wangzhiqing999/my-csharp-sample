using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using B1101_AutoMapper_BeforeAfter.Sample;


namespace B1101_AutoMapper_BeforeAfter
{
    class Program
    {
        static void Main(string[] args)
        {

            Ui2Db test2 = new Ui2Db();
            test2.DoTest1();
            test2.DoTest2();

            Console.WriteLine("Finish!");
            Console.ReadLine();

        }
    }
}
