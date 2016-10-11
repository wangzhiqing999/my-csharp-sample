using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;


using B1110_AutoMapper_EF.Model;
using B1110_AutoMapper_EF.Config;


namespace B1110_AutoMapper_EF.DataAccess
{

    

    /// <summary>
    /// 版本管理 Context.
    /// </summary>
    public class MyVersionManagerContext : DbContext
    {


        public MyVersionManagerContext()
            : base("name=MyVersionManagerContext")
        {
        }




        /// <summary>
        /// 产品.
        /// </summary>
        public DbSet<DbProduct> DbProducts { get; set; }
        
        
        /// <summary>
        /// 版本.
        /// </summary>
        public DbSet<DbVersion> DbVersions { get; set; }





        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            // 产品 配置信息.
            modelBuilder.Configurations.Add(new DbProductConfig());
        }


    }
}
