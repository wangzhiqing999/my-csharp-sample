using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A0661_EF_MySql_RowVersion.Model
{

    /// <summary>
    /// 测试表.
    /// </summary>
    [ToString]
    [Table("test_table")]
    public class TestTable
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { set; get; }



        public int A { set; get; }


        public int B { set; get; }


        public int C { set; get; }




        /// <summary>
        /// 版本 （并发控制使用列）
        /// </summary>
        [Column("RowVersion")]
        [Display(Name = "版本")]
        public DateTime RowVersion { get; set; }

    }
}
