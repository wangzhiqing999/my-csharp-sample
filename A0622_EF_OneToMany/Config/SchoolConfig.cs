using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity.ModelConfiguration;

using A0622_EF_OneToMany.Sample;




namespace A0622_EF_OneToMany.Config
{
    class SchoolConfig : EntityTypeConfiguration<School>
    {
        public SchoolConfig()
        {
            // 一个 学校  允许有多个 老师.
            this.HasMany(s => s.SchoolTeachers)
                // 一个 老师 必须要有一个 学校.
                .WithRequired(m => m.InSchool)
                // 外键的列是  SchoolID
                .HasForeignKey(m => m.SchoolID)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);
        }
    }
}
