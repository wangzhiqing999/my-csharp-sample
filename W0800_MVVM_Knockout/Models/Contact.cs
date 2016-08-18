using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace W0800_MVVM_Knockout.Models
{

    /// <summary>
    /// 联系信息.
    /// </summary>
    [Table("test_contact")]
    public class Contact
    {


        /// <summary>
        /// 联系信息ID
        /// </summary>
        [Column("contact_id")]
        [Display(Name = "联系信息ID")]
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }



        /// <summary>
        /// 名
        /// </summary>
        [Column("first_name")]
        [Display(Name = "名")]
        [StringLength(32)]
        [Required]
        public string FirstName { get; set; }


        /// <summary>
        /// 姓
        /// </summary>
        [Column("last_name")]
        [Display(Name = "姓")]        
        [StringLength(32)]
        [Required]
        public string LastName { get; set; }


        /// <summary>
        /// 电子邮件
        /// </summary>
        [Column("email_address")]
        [Display(Name = "电子邮件")]
        [StringLength(32)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }



        /// <summary>
        /// 电话号码
        /// </summary>
        [Column("phone_number")]
        [Display(Name = "电话号码")]
        [StringLength(32)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

    }


}