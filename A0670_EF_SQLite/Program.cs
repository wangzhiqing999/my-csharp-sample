using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


using A0670_EF_SQLite.DataAccess;


namespace A0670_EF_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestContext, A0670_EF_SQLite.Migrations.Configuration>());

            using(TestContext context = new TestContext())
            {
                var query =
                    from data in context.Tests
                    select data;


                foreach (var item in query.Take(3))
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
