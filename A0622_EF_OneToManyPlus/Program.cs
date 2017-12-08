using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using A0622_EF_OneToManyPlus.Model;
using A0622_EF_OneToManyPlus.DataAccess;
using A0622_EF_OneToManyPlus.Service;
using A0622_EF_OneToManyPlus.ServiceImpl;

namespace A0622_EF_OneToManyPlus
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestContext, A0622_EF_OneToManyPlus.Migrations.Configuration>());


            ITestService testService = new DefaultTestServiceImpl();

            // 初始化数据.
            long userID = testService.InitTestData();
            Console.WriteLine("User ID = {0}", userID);
            Console.WriteLine();
            
            // 单独查询.
            var user = testService.GetUserOnly(userID);
            Console.WriteLine("GetUserOnly Result = {0}", user);
            Console.WriteLine();

            // 关联查询.
            user = testService.GetUserWithMaster(userID);
            Console.WriteLine("GetUserWithMaster Result = {0}", user);
            Console.WriteLine();

            // 多层关联查询.
            user = testService.GetUserWithMasterAndDetail(userID);
            Console.WriteLine("GetUserWithMasterAndDetail Result = {0}", user);
            Console.WriteLine();

            Console.WriteLine("Finish.");
            Console.ReadKey();
        }
    }
}
