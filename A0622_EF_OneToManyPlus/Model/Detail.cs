using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A0622_EF_OneToManyPlus.Model
{



    /// <summary>
    /// 子数据
    /// </summary>
    [Table("test_detail")]
    [ToString]
    public class Detail
    {

        /// <summary>
        /// 子数据ID.
        /// </summary>
        [Column("detail_id")]
        [Key]
        public long DetailID { set; get; }





        #region 一对多.

        /// <summary>
        /// 主数据ID.
        /// </summary>
        [Column("master_id")]
        public long MasterID { set; get; }


        /// <summary>
        /// 主数据.
        /// </summary>
        [IgnoreDuringToString]
        public virtual Master MasterData { set; get; }


        #endregion






        /// <summary>
        /// 主数据名.
        /// </summary>
        [Column("detail_name")]
        [Required]
        [StringLength(32)]
        public string DetailName { set; get; }




    }


}
