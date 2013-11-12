using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace A0624_EF_OneToOne.Sample
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
        /// 数据库中的 Car, Engine 表的定义.
        /// 当有多个表的时候
        /// 定义多个 DbSet. 
        /// </summary>
        public DbSet<Car> CarDbSet { get; set; }
        public DbSet<Engine> EngineDbSet { get; set; }

    }

}
