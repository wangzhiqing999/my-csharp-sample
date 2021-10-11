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
    public class TestWorkData2
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
        /// 
        /// 这里的数据类型是 DateTime.
        /// 
        /// 
        /// 这里的 Column， 增加了 TypeName= "TIMESTAMP" 的定义。
        /// 
        /// 这就避免了手动去执行 sql 语句， 修改 数据类型的操作.
        /// ALTER TABLE `test_work_data2` CHANGE COLUMN `row_version` `row_version` TIMESTAMP NOT NULL ;
        /// 
        /// </summary>
        [Column("row_version", TypeName= "TIMESTAMP")]
        [Display(Name = "版本")]        
        public DateTime RowVersion { get; set; }


    }
}
