using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace A0670_EF_SQLite.Model
{

    /// <summary>
    /// 测试表.
    /// </summary>
    [Serializable]
    [Table("my_test")]
    public class Test
    {

        /// <summary>
        /// 主键：id
        /// </summary>
        [Column("id")]
        [Key]
        public long TestID { set; get; }


        
        [Column("test_name")]
        [StringLength(32)]
        public string TestName { set; get; }




        [Column("test_desc")]
        [StringLength(32)]
        public string TestDesc { set; get; }

    }
}
