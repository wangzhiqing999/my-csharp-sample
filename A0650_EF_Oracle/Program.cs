using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0650_EF_Oracle.Sample;


namespace A0650_EF_Oracle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oracle Entity Framework Test...");


            // 测试直接执行 SQL 语句.
            TestExecSql.DoTest();


            // 测试延迟加载.
            TestLazyLoading.DoTest();


            // 测试 序列号.
            TestSequence.DoTest();



            // 测试 存储过程
            TestCallProcedure.DoTest();


            // 测试 事务处理.
            TestTransaction.DoTest();


            // 测试 多次查询.
            TestMulQuery.DoTest();


            // 测试并发处理.
            TestConcurrency.DoTest();


            Console.ReadLine();
        }
    }
}
