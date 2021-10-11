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

    /// <summary>
    /// 这个是用于测试
    /// 2个DbContext 的事务的问题.
    /// </summary>
    public class MyWork2Context : DbContext
    {

        public MyWork2Context()
            : base("name=MyWork2Context")
        {

        }

        public MyWork2Context(DbConnection conn)
            : base(conn, false)
        {

        }



        /// <summary>
        /// 测试工作数据.
        /// </summary>
        public DbSet<TestWorkData2> TestWorkData2s { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 指定 并发控制的处理.
            modelBuilder.Entity<TestWorkData2>()
                .Property(p => p.RowVersion).IsConcurrencyToken()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

        }



        


    }
}
