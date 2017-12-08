using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using A0622_EF_OneToManyPlus.Model;


namespace A0622_EF_OneToManyPlus.Config
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {

            // 一个 【用户】 允许有 多个 【主数据】.
            this.HasMany(s => s.Masters)
                // 一个 【主数据】 必须要有一个所属的 【用户】.
                .WithRequired(m => m.UserData)
                // 外键的列是 UserID
                .HasForeignKey(m => m.UserID)
                // 打开 外键的 ON DELETE CASCADE 
                // 删除 【用户】 时， 连带删除 【主数据】.
                .WillCascadeOnDelete(true);

        }

    }
}
