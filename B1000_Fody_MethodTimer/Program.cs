using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MethodTimer;


namespace B1000_Fody_MethodTimer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试使用 MethodTimer.Fody 来生成 时间调试代码. （输出结果在 VS 的 [输出] 那里， 不在控制台上。）");


            MyClass test = new MyClass();



            test.MyMethod();

            test.MyMethod2();


            Console.ReadKey();
        }
    }





    public class MyClass
    {
        [Time]
        public void MyMethod()
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }


        [Time]
        public void MyMethod2()
        {
            System.Threading.Thread.Sleep(2500);
            Console.WriteLine("Hello 2");
        }

    }

}
