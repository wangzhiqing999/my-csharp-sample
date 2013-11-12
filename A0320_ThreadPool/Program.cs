using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0320_ThreadPool.Sample;



namespace A0320_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {

            // 测试方法.
            TestPool.TestThreadPool();

            // 读取用户输入 （避免主线程结束）.
            Console.ReadLine();
        }
    }
}
