using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;

using A0622_EF_OneToManyPlus.Model;
using A0622_EF_OneToManyPlus.Config;


namespace A0622_EF_OneToManyPlus.DataAccess
{

    // PM> Enable-Migrations  -ProjectName A0622_EF_OneToManyPlus
    public class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {
        }


        /// <summary>
        /// 用户.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 主数据.
        /// </summary>
        public DbSet<Master> Masters { get; set; }

        /// <summary>
        /// 子数据.
        /// </summary>
        public DbSet<Detail> Details { get; set; }




        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 【用户】  配置信息.
            modelBuilder.Configurations.Add(new UserConfig());

            // 【主数据】  配置信息.
            modelBuilder.Configurations.Add(new MasterConfig());

        }
    }
}
