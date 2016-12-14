using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;




using A0622_EF_OneToMany.Config;


namespace A0622_EF_OneToMany.Sample
{

    public class MyDbContext : DbContext
    {


        public MyDbContext()
            : base("name=MyDbContext")
        {


            // 下面这句为 拦截的处理.
#if DEBUG
            DbInterception.Add(new EFIntercepterLogging());
#endif

        }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }


        /// <summary>
        /// 数据库中的 School, Teacher 表的定义.
        /// 当有多个表的时候
        /// 定义多个 DbSet. 
        /// </summary>
        public DbSet<School> SchoolDbSet { get; set; }
        public DbSet<Teacher> TeacherDbSet { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 注意： 
            // Oracle 必须要加这一句。 否则就会抱  dbo 用户不存在的错误！
            // SQL Server 则不需要加这句话。
            modelBuilder.HasDefaultSchema("TEST2");





            // 学校表配置.
            modelBuilder.Configurations.Add(new SchoolConfig());

        }

    }






    /// <summary>
    /// 这个类用于 EF6 中， 输出 EF 生成的 SQL 语句.
    /// </summary>
    class EFIntercepterLogging : DbCommandInterceptor
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();


        public override void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }
        public override void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                Trace.TraceError("Exception:{1} \r\n --> Error executing command: {0}", command.CommandText, interceptionContext.Exception.ToString());
            }
            else
            {
                Trace.TraceInformation("\r\n执行时间:{0} 毫秒\r\n-->ScalarExecuted.Command:{1}\r\n", _stopwatch.ElapsedMilliseconds, command.CommandText);
            }
            base.ScalarExecuted(command, interceptionContext);
        }




        public override void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }
        public override void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                Trace.TraceError("Exception:{1} \r\n --> Error executing command:\r\n {0}", command.CommandText, interceptionContext.Exception.ToString());
            }
            else
            {
                Trace.TraceInformation("\r\n执行时间:{0} 毫秒\r\n-->NonQueryExecuted.Command:\r\n{1}", _stopwatch.ElapsedMilliseconds, command.CommandText);
            }
            base.NonQueryExecuted(command, interceptionContext);
        }




        public override void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }
        public override void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                Trace.TraceError("Exception:{1} \r\n --> Error executing command:\r\n {0}", command.CommandText, interceptionContext.Exception.ToString());
            }
            else
            {
                Trace.TraceInformation("\r\n执行时间:{0} 毫秒 \r\n -->ReaderExecuted.Command:\r\n{1}", _stopwatch.ElapsedMilliseconds, command.CommandText);
            }
            base.ReaderExecuted(command, interceptionContext);
        }
    }


}
