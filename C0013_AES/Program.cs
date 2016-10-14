using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using C0013_AES.Sample;


namespace C0013_AES
{
    class Program
    {
        static void Main(string[] args)
        {

            Test tester = new Test();


            tester.TestDes();

            tester.TestAes();


            tester.TestAes2();


            Console.WriteLine("Finish!");
            Console.ReadLine();

        }
    }
}
