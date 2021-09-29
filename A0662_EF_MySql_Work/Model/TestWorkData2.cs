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
    /// 测试工作数据2.
    /// </summary>
    [Table("test_work_data2")]
    public class TestWorkData2 : IRowVersion
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("code")]
        [StringLength(16)]
        [Key]
        public string Code { set; get; }


        /// <summary>
        /// 工作数据.
        /// </summary>
        [Column("work_value")]
        public long WorkValue { set; get; }



        /// <summary>
        /// 工作数据2.
        /// </summary>
        [Column("work_value2")]
        public long WorkValue2 { set; get; }


        /// <summary>
        /// 版本 （并发控制使用列）
        /// </summary>
        [Column("row_version")]
        [Display(Name = "版本")]
        public byte[] RowVersion { set; get; }
    }
}
