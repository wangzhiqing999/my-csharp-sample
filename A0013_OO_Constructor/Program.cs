using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0013_OO_Constructor.Sample;


namespace A0013_OO_Constructor
{


    /// <summary>
    /// 此例子 需要通过 多次执行， 来观察执行结果！
    /// </summary>
    class Program
    {

        
        static void Main(string[] args)
        {

            Test test = new Test();
            Console.WriteLine("TestValue 当前数值为：{0}", test.TestValue);
            Console.WriteLine("这里对 TestValue 作了 ++ 的处理！ ");
            test.TestValue++;
            Console.ReadLine();
        }

    }
}
