using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace A0640_EF_Enum.Sample
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
        /// TestData DbSet. 
        /// </summary>
        public DbSet<TestData> TestDataDbSet { get; set; }
    }
}
