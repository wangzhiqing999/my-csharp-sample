using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;



namespace B2000_AbpEf.Model
{


    /// <summary>
    /// 测试学校表.
    /// </summary>
    [Table("test_abp_school")]
    public class School : Entity<Int32>
    {

        /// <summary>
        /// 学校名.
        /// </summary>
        [Column("school_name")]
        [StringLength(64)]
        public string SchoolName { set; get; }


        /// <summary>
        /// 学校地址.
        /// </summary>
        [Column("school_address")]
        [StringLength(128)]
        public string SchoolAddress { set; get; }



        /// <summary>
        /// 学校中的教师.
        /// 这里是 一对多 关系中
        /// 一个学校，对应多个教师.
        /// </summary>
        public virtual ICollection<Teacher> SchoolTeachers { get; set; }

    }
}
