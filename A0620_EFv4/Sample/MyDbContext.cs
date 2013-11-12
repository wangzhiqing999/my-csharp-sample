using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace A0620_EFv4.Sample
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
        /// 数据库中的 mr_demo_data 表的定义.
        /// 当有多个表的时候
        /// 定义多个 DbSet. 
        /// </summary>
        public DbSet<mr_demo_data> MrDemoDataDbSet { get; set; }


    }

}
