using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;


using Abp;
using Abp.Dependency;

using B2000_AbpEf.Test;
using B2000_AbpEf.DataAccess;
using B2000_AbpEf.Module;


namespace B2000_AbpEf
{
    class Program
    {
        static void Main(string[] args)
        {
            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<B2000_AbpEfDbContext, B2000_AbpEf.Migrations.Configuration>());


            Console.WriteLine("========== Basic ==========");

            // 单表基本操作.
            BasicTest.TestOneTableFunc();

            // 多表基本操作.
            BasicTest.TestMulTableFunc();

            // 翻页的操作.
            BasicTest.TestPage();

            // 直接执行 SQL 语句的操作.
            BasicTest.ExecSql();



            // 使用 ABP 框架的测试操作.
            Console.WriteLine("========== ABP ==========");

            //Bootstrapping ABP system
            using (var bootstrapper = AbpBootstrapper.Create<B2000_AbpEfAbpModule>())
            {
                bootstrapper.Initialize();
                using (var tester = bootstrapper.IocManager.ResolveAsDisposable<AbpTest>())
                {
                    tester.Object.TestOneTableFunc();
                    tester.Object.TestMulTableFunc();
                    tester.Object.TestPage();
                    tester.Object.ExecSql();


                    tester.Object.OtherTest();
                }
            }



            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
