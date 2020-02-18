using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A0621_EF_CodeFirst.Sample
{
    /// <summary>
    /// 消息发送日志.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("sms_log")]
    public class SmsLog
    {

        /// <summary>
        /// 消息流水.
        /// </summary>
        [DataMember]
        [Column("sms_log_id")]
        [Display(Name = "消息流水ID")]
        [Key]
        public int SmsLogID { set; get; }



        /// <summary>
        /// 手机号码.
        /// </summary>
        [DataMember]
        [Column("phone_num")]
        [Display(Name = "手机号码")]
        [StringLength(16)]
        [Required]
        public string PhoneNumber { set; get; }


        /// <summary>
        /// 消息内容.
        /// </summary>
        [DataMember]
        [Column("message_content")]
        [Display(Name = "消息内容")]
        [StringLength(128)]
        [Required]
        public string MessageContent { set; get; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        [Display(Name = "创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Editable(false)]
        public DateTime CreateTime { get; set; }


        public override string ToString()
        {
            return $"No.{SmsLogID}  To {PhoneNumber} : {MessageContent} at {CreateTime}";
        }
    }
}
