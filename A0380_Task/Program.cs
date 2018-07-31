using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using A0380_Task.Sample;



namespace A0380_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("### Before TaskSample1.DoTest()! ");

            TaskSample1.DoTest1();
            TaskSample1.DoTest2();

            Console.WriteLine("### After TaskSample1.DoTest()! ");


            Console.WriteLine("Wait...");
            Console.ReadLine();


            Console.WriteLine("### Before TaskSample2.DoTest()! ");

            TaskSample2.DoTest();

            Console.WriteLine("### After TaskSample2.DoTest()! ");

            
            Console.WriteLine("Wait...");
            Console.ReadLine();



            Console.WriteLine("### Before TaskSample3.DoTest()! ");

            TaskSample3.DoTest();

            Console.WriteLine("### After TaskSample3.DoTest()! ");
            Console.WriteLine("Wait...");
            Console.ReadLine();



            Console.WriteLine("### Before TaskSample3.DoTestWaitAll()! ");

            TaskSample3.DoTestWaitAll();

            Console.WriteLine("### After TaskSample3.DoTestWaitAll()! ");
            Console.ReadLine();




            Console.WriteLine("### Before TaskSample3.DoTestWaitAny()! ");

            TaskSample3.DoTestWaitAny();

            Console.WriteLine("### After TaskSample3.DoTestWaitAny()! ");
            Console.ReadLine();




            Console.WriteLine("Finish!");
            Console.ReadLine();
        }


    }
}
