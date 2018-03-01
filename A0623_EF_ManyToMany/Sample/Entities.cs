using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace A0623_EF_ManyToMany.Sample
{


    /// <summary>
    /// 课程.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { set; get; }


        /// <summary>
        /// 课程名.
        /// </summary>
        public string CourseName { set; get; }


        /// <summary>   
        /// 选修了 当前这门课程 的 学生.
        /// 多对多关系：
        /// 1门课程，可以被多个学生选修
        /// 1个学生，可以选修多门课程.
        /// </summary>   
        public virtual ICollection<Student> Students { get; set; }  

    }



    /// <summary>
    /// 学生.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学生ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { set; get; }


        /// <summary>
        /// 学生名.
        /// </summary>
        public string StudentName { set; get; }


        /// <summary>   
        /// 当前学生 选修了的课程 .
        /// 多对多关系：
        /// 1门课程，可以被多个学生选修
        /// 1个学生，可以选修多门课程.
        /// </summary>   
        public virtual ICollection<Course> Courses { get; set; }  
    }
    


    
}
