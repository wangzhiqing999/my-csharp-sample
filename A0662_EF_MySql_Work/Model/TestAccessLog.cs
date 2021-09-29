using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace A0662_EF_MySql_Work.Model
{


    /// <summary>
    /// 测试访问日志.
    /// </summary>
    [Table("test_access_log")]
    public class TestAccessLog
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { set; get; }



        /// <summary>
        /// 用户代码.
        /// </summary>
        [Column("user_code")]
        [StringLength(32)]
        public string UserCode { set; get; }



        /// <summary>
        /// 访问时间.
        /// </summary>
        [Column("access_time")]
        public DateTime AccessTime { set; get; }



        /// <summary>
        /// 访问模块.
        /// </summary>
        [Column("access_module")]
        [StringLength(32)]
        public string AccessModule { set; get; }



        public override string ToString()
        {
            return $"用户{UserCode}，于 {AccessTime:yyyy-MM-dd HH:mm:ss} 访问了 {AccessModule} 模块。";
        }


    }
}
