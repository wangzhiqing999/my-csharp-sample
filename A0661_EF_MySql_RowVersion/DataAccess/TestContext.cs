using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using A0661_EF_MySql_RowVersion.Model;


namespace A0661_EF_MySql_RowVersion.DataAccess
{

    //  Enable-Migrations -ProjectName A0661_EF_MySql_RowVersion  -EnableAutomaticMigrations
    public class TestContext : DbContext
    {

        public TestContext()
            : base("name=TestContext")
        {

        }

        /// <summary>
        /// 测试表
        /// </summary>
        public DbSet<TestTable> TestTables { get; set; }


        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 测试表时间戳.
            modelBuilder.Entity<TestTable>()
                 .Property(p => p.RowVersion).IsConcurrencyToken()
                 .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }

    }
}
