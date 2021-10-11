using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A0662_EF_MySql_Work.DataAccess;
using A0662_EF_MySql_Work.Sample;

namespace A0662_EF_MySql_Work
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyWorkContext, A0662_EF_MySql_Work.Migrations.Configuration>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyWork2Context, A0662_EF_MySql_Work.Migrations.Configuration2>());


            // 下面的查询， 单纯是为了测试上面的 “如果不一致，自动升级数据库到最新的版本”
            using (MyWorkContext context = new MyWorkContext())
            {
                var query =
                    from data in context.TestAccessLogs
                    select data.ID;

                foreach(long id in query.Take(3))
                {
                    Console.WriteLine(id);
                }
            }
            using (MyWork2Context context = new MyWork2Context())
            {
                var query =
                    from data in context.TestWorkData2s
                    select data.Code;

                foreach (string id in query.Take(3))
                {
                    Console.WriteLine(id);
                }
            }





            /*

            // 测试 LINQ 里面，GROUP BY 的处理.
            TestGroup testGroup = new TestGroup();
            testGroup.TestLastData();

            */






            /*
             
            // 测试 2个用户， 同时更新 一行数据的 不同的字段。
            // 这里的 版本，主要通过 覆盖 SaveChanges() 方法.
            // 在物理保存以前，向 版本列， 写入 System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())
            // 也就是写代码的时候，是 MySQL， 万一后面要变更数据库了，不需要做修改的处理。

            TestRowVersion testRowVersion = new TestRowVersion();
            testRowVersion.InitTestWorkData();

            Task task1 = Task.Run(() => {
                testRowVersion.UpdateWorkValue();
            });
            Task task2 = Task.Factory.StartNew(() => {
                testRowVersion.UpdateWorkValue2();
            });

            Task.WaitAll(task1, task2);

            */





            /*

            // 测试 2个用户， 同时更新 一行数据的 不同的字段。
            // 这里的 版本，主要通过 MySQL 的 TIMESTAMP 数据类型来实现。
            // 也就是写代码的时候，是 MySQL， 万一后面要变更数据库了，需要做额外的修改。

            TestRowVersion2 testRowVersion2 = new TestRowVersion2();
            testRowVersion2.InitTestWorkData();

            Task task21 = Task.Run(() => {
                testRowVersion2.UpdateWorkValue();
            });
            Task task22 = Task.Factory.StartNew(() => {
                testRowVersion2.UpdateWorkValue2();
            });

            Task.WaitAll(task21, task22);

            */









            /*


            // 测试两个 DbContext， 使用同一个事务处理.
            TestTwoContextInSameDB testTwoContextInSameDB = new TestTwoContextInSameDB();
            testTwoContextInSameDB.InitTestWorkData();
            testTwoContextInSameDB.UpdateWorkValue();
            testTwoContextInSameDB.UpdateWorkValue2();

            */






            Console.WriteLine("Finish!");
            Console.ReadLine();
        }







    }
}
