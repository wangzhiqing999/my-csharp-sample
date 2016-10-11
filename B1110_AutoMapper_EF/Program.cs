using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using B1110_AutoMapper_EF.Sample;


namespace B1110_AutoMapper_EF
{
    class Program
    {
        static void Main(string[] args)
        {

            Ui2Db test1 = new Ui2Db();
            test1.DoTest1();
            test1.DoTest2();


            Db2Ui test2 = new Db2Ui();
            test2.DoTest1();

            Console.WriteLine("Finish!!!");
            Console.ReadKey();

        }
    }
}
