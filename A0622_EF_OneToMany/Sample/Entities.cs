using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace A0622_EF_OneToMany.Sample
{


    /// <summary>
    /// 学校
    /// </summary>
    public class School
    {

        /// <summary>
        /// 学校代码.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolID { set; get; }


        /// <summary>
        /// 学校名.
        /// </summary>
        public string SchoolName { set; get; }


        /// <summary>
        /// 学校中的教师.
        /// 这里是 一对多 关系中
        /// 一个学校，对应多个教师.
        /// </summary>
        public virtual ICollection<Teacher> SchoolTeachers { get; set; }

    }


    /// <summary>
    /// 教师.
    /// </summary>
    public class Teacher
    {

        /// <summary>
        /// 教师ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { set; get; }


        /// <summary>
        /// 教师名.
        /// </summary>
        public string TeacherName { set; get; }




        /// <summary>
        /// 学校代码
        /// </summary>
        public int SchoolID { set; get; } 




        /// <summary>  
        /// 执教的 学校.
        /// 这里是 一对多 关系中
        /// 一个学校，对应多个教师.
        /// </summary>  
        public virtual School InSchool { get; set; }
    }



}
