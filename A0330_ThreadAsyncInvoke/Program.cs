using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0330_ThreadAsyncInvoke.Sample;

namespace A0330_ThreadAsyncInvoke
{
    class Program
    {
        static void Main(string[] args)
        {

            // 简单测试.
            TestAsync.SimpleInvokeTest();

            // 等待任意一个执行完毕的测试.
            TestAsync.WaitAnyTest();

            // 异步处理后， 周期检查异步处理执行结果.
            TestAsync.IsCompletedTest();

            // 异步处理时，通过指定 回调函数进行处理.
            TestAsync.CallbackTest();


            Console.ReadLine();
        }
    }
}
