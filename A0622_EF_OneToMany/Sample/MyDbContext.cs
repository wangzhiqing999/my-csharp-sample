using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


using A0622_EF_OneToMany.Config;


namespace A0622_EF_OneToMany.Sample
{

    public class MyDbContext : DbContext
    {


        public MyDbContext()
            : base("name=MyDbContext")
        {
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

}
