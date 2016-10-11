using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity.ModelConfiguration;
using B1110_AutoMapper_EF.Model;


namespace B1110_AutoMapper_EF.Config
{



    /// <summary>
    /// 产品配置.
    /// </summary>
    class DbProductConfig : EntityTypeConfiguration<DbProduct>
    {

        public DbProductConfig()
        {
            // 一个 产品  允许有多个 版本.
            this.HasMany(s => s.VersionList)
                // 一个 版本 必须归属一个 产品.
                .WithRequired(m => m.ProductData)
                // 外键的列是  ProductCode
                .HasForeignKey(m => m.ProductCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);
        }


    }


}
