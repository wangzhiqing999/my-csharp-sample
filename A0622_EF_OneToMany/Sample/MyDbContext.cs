using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace A0622_EF_OneToMany.Sample
{

    public class MyDbContext : DbContext
    {

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


    }

}
