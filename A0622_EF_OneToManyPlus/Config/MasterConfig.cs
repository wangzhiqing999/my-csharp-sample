using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using A0622_EF_OneToManyPlus.Model;


namespace A0622_EF_OneToManyPlus.Config
{
    class MasterConfig : EntityTypeConfiguration<Master>
    {
        public MasterConfig()
        {

            // 一个 【主数据】 允许有 多个 【子数据】.
            this.HasMany(s => s.Details)
                // 一个 【子数据】 必须要有一个所属的 【主数据】.
                .WithRequired(m => m.MasterData)
                // 外键的列是 MasterID
                .HasForeignKey(m => m.MasterID)
                // 打开 外键的 ON DELETE CASCADE 
                // 删除 【主数据】 时， 连带删除 【子数据】.
                .WillCascadeOnDelete(true);

        }
    }
}
