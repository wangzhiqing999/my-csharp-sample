using System;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;

using System.Data.Entity;

using B2000_AbpEf.DataAccess;
using B2000_AbpEf.Migrations;


namespace B2000_AbpEf.Module
{
    [DependsOn(typeof(AbpEntityFrameworkModule))]
    public class B2000_AbpEfAbpModule : AbpModule
    {

        public override void PreInitialize()
        {
            // 数据库的链接字符串名称.
            Configuration.DefaultNameOrConnectionString = "B2000_AbpEfDbContext";

            //Configuration.UnitOfWork
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
        }


        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());


            // 类模型发生变化时， 自动更新数据库.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<B2000_AbpEfDbContext, Configuration>());
        }
    }
}
