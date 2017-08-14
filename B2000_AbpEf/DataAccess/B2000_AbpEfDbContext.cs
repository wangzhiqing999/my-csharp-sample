using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.EntityFramework;

using B2000_AbpEf.Model;


namespace B2000_AbpEf.DataAccess
{
    public class B2000_AbpEfDbContext : AbpDbContext
    {


        /// <summary>
        /// 学校.
        /// </summary>
        public virtual IDbSet<School> Schools { get; set; }


        /// <summary>
        /// 老师.
        /// </summary>
        public virtual IDbSet<Teacher> Teachers { get; set; }


        /// <summary>
        /// 学生.
        /// </summary>
        public virtual IDbSet<Student> Students { get; set; }


        /// <summary>
        /// 其它.
        /// </summary>
        public virtual IDbSet<Other> Others { get; set; }






        public B2000_AbpEfDbContext()
            : base("B2000_AbpEfDbContext")
        {

        }


        public B2000_AbpEfDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            // ##### 一对多的配置 #####

            // 学校
            modelBuilder.Entity<School>()
                // 一个学校，有多个老师.
                .HasMany(s => s.SchoolTeachers)
                // 一个老师， 可选属于一个学校.
                .WithOptional(m => m.InSchool)
                // 外键列为 SchoolID
                .HasForeignKey(m => m.SchoolID)
                // 关闭  ON DELETE CASCADE
                .WillCascadeOnDelete(false);


            // 学校
            modelBuilder.Entity<School>()
                // 一个学校，有多个学生.
                .HasMany(s => s.SchoolStudents)
                // 一个学生， 可选属于一个学校.
                .WithOptional(m => m.InSchool)
                // 外键列为 SchoolID
                .HasForeignKey(m => m.SchoolID)
                // 关闭  ON DELETE CASCADE
                .WillCascadeOnDelete(false);






            // ##### 多对多的配置 #####

            // 老师 与  学生的  多对多.
            modelBuilder.Entity<Teacher>()
                .HasMany(a => a.Students)
                .WithMany(t => t.Teachers)
                .Map(m =>
            {
                //中间关系表表名
                m.ToTable("test_abp_teacher_student");      

                // 老师表的ID列名.
                m.MapLeftKey("teacher_id");

                // 学生表的ID列名
                m.MapRightKey("student_id");   

            });





        }




        }
}
