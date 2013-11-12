using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0650_EF_SqlServer.Sample;


namespace A0650_EF_SqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SQL Server Entity Framework Test...");

            // 测试延迟加载.
            TestLazyLoading.DoTest();

            // 测试  identity.
            TestIdentity.DoTest();

            // 测试 存储过程
            TestCallProcedure.DoTest();



            // 测试 事务处理.
            TestTransaction.DoTest();





            // 测试 多次查询.
            TestMulQuery.DoTest();



            // 测试并发处理.
            TestConcurrency.DoTest();



            // Model First 的测试.
            // TestModelFirst.DoTest();
            


            Console.ReadLine();
        }
    }
}
