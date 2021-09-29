using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

using A0662_EF_MySql_Work.Model;
using System.Data.Common;

namespace A0662_EF_MySql_Work.DataAccess
{

    // Enable-Migrations -ProjectName A0662_EF_MySql_Work  -EnableAutomaticMigrations
    public class MyWorkContext : DbContext
    {

        public MyWorkContext()
            : base("name=MyWorkContext")
        {

        }


        public MyWorkContext(DbConnection conn)
            : base(conn, false)
        {

        }



        /// <summary>
        /// 测试访问日志.
        /// </summary>
        public DbSet<TestAccessLog> TestAccessLogs { get; set; }


        /// <summary>
        /// 测试工作数据.
        /// </summary>
        public DbSet<TestWorkData> TestWorkDatas { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 并发控制字段.            
            modelBuilder.Properties().Where(o => typeof(IRowVersion).IsAssignableFrom(o.DeclaringType) && o.PropertyType == typeof(byte[]) && o.Name == "RowVersion")
                .Configure(o => o.IsConcurrencyToken().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));
            

        }


        public override int SaveChanges()
        {

            this.ChangeTracker.DetectChanges();
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            foreach (ObjectStateEntry entry in objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            {
                var v = entry.Entity as IRowVersion;
                if (v != null)
                {
                    // 并发控制字段.
                    v.RowVersion = System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
                }
            }
            return base.SaveChanges();
        }
        


    }
}
