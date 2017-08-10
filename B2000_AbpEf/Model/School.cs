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
        /// 学校状态.
        /// </summary>
        [Column("school_state")]
        public SchoolState State { get; set; }




        /// <summary>
        /// 学校中的教师.
        /// 这里是 一对多 关系中
        /// 一个学校，对应多个教师.
        /// </summary>
        public virtual ICollection<Teacher> SchoolTeachers { get; set; }



        public override string ToString()
        {
            return String.Format(@"School [ id = {0};  name = {1};  address = {2};  state = {3} ]",   this.Id, this.SchoolName, this.SchoolAddress, this.State);
        }


    }




    /// <summary>
    /// 学校状态.
    /// </summary>
    public enum SchoolState : Int32
    {

        /// <summary>
        /// 未知状态.
        /// </summary>
        Unknow = 0,


        /// <summary>
        /// 计划.
        /// </summary>
        Plan = 1,


        /// <summary>
        /// 建设.
        /// </summary>
        Build = 2,


        /// <summary>
        /// 使用. 
        /// </summary>
        Use = 4,


        /// <summary>
        /// 关闭.
        /// </summary>
        Close = 8
    }

}
