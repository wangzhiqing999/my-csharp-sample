using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0205_Proxy.SmartReference;
using P0205_Proxy.Virtual;

namespace P0205_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("调用 智能引用代理");
            TestSmartReference();

            Console.WriteLine();
            Console.WriteLine("调用 虚拟代理");
            TestVirtual();
            Console.ReadLine();

        }


        /// <summary>
        /// 测试 智能引用代理.
        /// </summary>
        private static void TestSmartReference()
        {
            // 创建代理.
            IDataService dataService = new DataServiceProxy();

            // 调用代理类的方法.
            dataService.DoSomething();
        }



        /// <summary>
        /// 测试 虚拟代理.
        /// </summary>
        private static void TestVirtual()
        {
            // 创建代理.
            ILongTimeService service = new LongTimeServiceProxy();

            // 调用代理类的方法.
            service.LongTimeProcess();
        }

    }
}
