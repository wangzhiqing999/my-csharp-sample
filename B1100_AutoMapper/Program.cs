using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using B1100_AutoMapper.Sample;


namespace B1100_AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Db2Ui test1 = new Db2Ui();
            test1.DoTest();

            Console.WriteLine();

            Ui2Db test2 = new Ui2Db();
            test2.DoTest1();
            test2.DoTest2();

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
