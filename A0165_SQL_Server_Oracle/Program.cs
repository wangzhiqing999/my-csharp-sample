using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0165_SQL_Server_Oracle.Sample;



namespace A0165_SQL_Server_Oracle
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCallTwoProcedure tester = new TestCallTwoProcedure();

            // 先测试 Oracle 失败的.
            tester.TestCall(0, 0);
            Console.WriteLine();


            // 再测试 Oracle 成功， SQL Server 失败的.
            tester.TestCall(1, 0);
            Console.WriteLine();


            // 再测试 Oracle 成功， SQL Server 成功的.
            tester.TestCall(1, 1);
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
