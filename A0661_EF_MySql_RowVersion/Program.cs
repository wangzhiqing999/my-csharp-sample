using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using System.Data.Entity;
using System.Data.Entity.Migrations;


using A0661_EF_MySql_RowVersion.Model;
using A0661_EF_MySql_RowVersion.DataAccess;
using A0661_EF_MySql_RowVersion.Service;


namespace A0661_EF_MySql_RowVersion
{
    class Program
    {


        private static TestTableService service = new TestTableService();



        static void Main(string[] args)
        {
            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestContext, A0661_EF_MySql_RowVersion.Migrations.Configuration>());


            TestTable data = service.GetLastData();
            Console.WriteLine("Last data = {0}", data);

            ThreadStart tsA = new ThreadStart(Aplus);
            ThreadStart tsB = new ThreadStart(Bplus);
            ThreadStart tsC = new ThreadStart(Cplus);

            Thread tA = new Thread(tsA);
            Thread tB = new Thread(tsB);
            Thread tC = new Thread(tsC);

            
            // 启动.
            tA.Start();
            tB.Start();
            tC.Start();


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }



        static void Aplus()
        {
            int successCount = 0;
            int failCount = 0;

            for (int i =0; i < 10; i ++)
            {
                TestTable data = service.GetLastData();
                Console.WriteLine("AAA: 更新A之前数据 = {0}", data);

                Thread.Sleep(50);

                data.A++;
                bool result = service.Update(data);

                if(result)
                {
                    successCount++;
                    data = service.GetLastData();
                    Console.WriteLine("AAA: 更新A之后数据 = {0}", data);
                } else
                {
                    failCount++;
                    Console.WriteLine("AAA: 更新失败！");
                }                               
            }

            Console.WriteLine("AAA: 处理完毕， 成功 {0} 次， 失败 {1} 次 ---------- ", successCount, failCount);
        }


        static void Bplus()
        {
            int successCount = 0;
            int failCount = 0;


            for (int i = 0; i < 10; i++)
            {
                TestTable data = service.GetLastData();
                Console.WriteLine("BBB: 更新B之前数据 = {0}", data);

                Thread.Sleep(100);

                data.B++;

                bool result = service.Update(data);

                if (result)
                {
                    successCount++;
                    data = service.GetLastData();
                    Console.WriteLine("BBB: 更新B之后数据 = {0}", data);
                }
                else
                {
                    failCount++;
                    Console.WriteLine("BBB: 更新失败！");
                }
            }

            Console.WriteLine("BBB: 处理完毕， 成功 {0} 次， 失败 {1} 次 ---------- ", successCount, failCount);
        }


        static void Cplus()
        {
            int successCount = 0;
            int failCount = 0;


            for (int i = 0; i < 10; i++)
            {
                TestTable data = service.GetLastData();
                Console.WriteLine("CCC: 更新C之前数据 = {0}", data);

                Thread.Sleep(150);

                data.C++;

                bool result = service.Update(data);

                if (result)
                {
                    successCount++;
                    data = service.GetLastData();
                    Console.WriteLine("CCC: 更新C之后数据 = {0}", data);
                }
                else
                {
                    failCount++;
                    Console.WriteLine("CCC: 更新失败！");
                }
            }

            Console.WriteLine("CCC: 处理完毕， 成功 {0} 次， 失败 {1} 次 ---------- ", successCount, failCount);
        }



    }
}
