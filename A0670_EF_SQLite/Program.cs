using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


using A0670_EF_SQLite.DataAccess;
using A0670_EF_SQLite.Model;
using System.Data.SQLite;
using System.IO;

namespace A0670_EF_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestContext, A0670_EF_SQLite.Migrations.Configuration>());



            // 使用 App.config 中的数据库配置.
            using(TestContext context = new TestContext())
            {

                if (!context.Database.Exists())
                {
                    context.Database.CreateIfNotExists();
                    context.Database.Initialize(true);
                }
                
                Test test = new Test()
                {
                    TestName = $"测试名称_{DateTime.Now:yyyy-MM-dd HHmmss}",
                    TestDesc = $"测试描述_{DateTime.Now:yyyy-MM-dd HHmmss}"
                };

                context.Tests.Add(test);
                context.SaveChanges();


                var query =
                    from data in context.Tests
                    orderby data.TestID descending
                    select data;

                foreach (var item in query.Take(3))
                {
                    Console.WriteLine(item);
                }
            }



            // 手动指定连接字符串.
            // 下面的代码，翻车了.
            /*
            using (TestContext context = new TestContext($"Data Source=.\\mytest_{DateTime.Today:yyyyMMdd}.db"))
            {

                Test test = new Test()
                {
                    TestName = $"测试名称_{DateTime.Now:yyyy-MM-dd HHmmss}",
                    TestDesc = $"测试描述_{DateTime.Now:yyyy-MM-dd HHmmss}"
                };

                context.Tests.Add(test);
                context.SaveChanges();


                var query =
                    from data in context.Tests
                    select data;

                foreach (var item in query.Take(3))
                {
                    Console.WriteLine(item);
                }
            }
            */




            Console.WriteLine();



            // TestContext 的构造函数， 是已指定的 SQLiteConnection 时。
            // 如果表不存在，不会创建.
            // 结果只有一个 0 字节的 db 文件.
            // 因此，只好 复制已有的数据库文件.

            string dbFileName = $".\\mytest_{DateTime.Today:yyyyMMdd}.db";
            if (!File.Exists(dbFileName))
            {
                File.Copy(".\\mytest.db", dbFileName);
            }

            string myConnString = $"Data Source={dbFileName}";
            using (SQLiteConnection conn = new SQLiteConnection(myConnString))
            {
                using (TestContext context = new TestContext(conn, true))
                {
                    Test test = new Test()
                    {
                        TestName = $"#测试名称_{DateTime.Now:yyyy-MM-dd HHmmss}",
                        TestDesc = $"#测试描述_{DateTime.Now:yyyy-MM-dd HHmmss}"
                    };

                    context.Tests.Add(test);
                    context.SaveChanges();

                    var query =
                        from data in context.Tests
                        orderby data.TestID descending
                        select data;

                    foreach (var item in query.Take(3))
                    {
                        Console.WriteLine(item);
                    }
                }

            }




            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
