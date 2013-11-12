using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;



namespace A0631_EF_Inherit_TPT.Sample
{

    /// <summary>
    /// 成员定义.
    /// </summary>
    [Table("t_WorkMember", Schema = "Test")]
    public abstract class WorkMember
    {
        /// <summary>
        /// 成员ID.
        /// 数据库自增主键.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { set; get; }

        /// <summary>
        /// 成员类型.
        /// </summary>
        [NotMapped]
        public abstract string MemberType
        {
            get;
        }

        /// <summary>
        /// 姓名.
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string MemberName { set; get; }



    }


    /// <summary>
    /// 操作员
    /// </summary>
    [Table("t_Operator", Schema = "Test")]
    public class Operator : WorkMember
    {
        public override string MemberType
        {
            get { return "操作员"; }
        }

        /// <summary>
        /// 城市.
        /// </summary>
        public string City { set; get; }


        public override string ToString()
        {
            return String.Format("位于{0} 的 {1} : {2}",
                City, MemberType, MemberName);
        }
    }

    /// <summary>
    /// 系统管理人员
    /// </summary>
    [Table("t_Manager", Schema = "Test")]
    public class Manager : WorkMember
    {
        public override string MemberType
        {
            get { return "系统管理员"; }
        }


        /// <summary>
        /// 安全等级.
        /// </summary>
        public int SecurityLevel { set; get; }


        public override string ToString()
        {
            return String.Format("{0} : {1} [安全等级 {2} ]",
                MemberType, MemberName, SecurityLevel);
        }
    }
}
