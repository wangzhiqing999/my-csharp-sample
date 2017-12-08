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
    /// 主数据
    /// </summary>
    [Table("test_master")]
    [ToString]
    public class Master
    {


        /// <summary>
        /// 主数据ID.
        /// </summary>
        [Column("master_id")]
        [Key]
        public long MasterID { set; get; }





        #region 一对多.

        /// <summary>
        /// 用户ID.
        /// </summary>
        [Column("user_id")]
        public long UserID { set; get; }


        /// <summary>
        /// 用户数据.
        /// </summary>
        [IgnoreDuringToString]
        public virtual User UserData { set; get; }

        #endregion






        /// <summary>
        /// 主数据名.
        /// </summary>
        [Column("master_name")]
        [Required]
        [StringLength(32)]
        public string MasterName { set; get; }




        #region 一对多.


        /// <summary>
        /// 子数据列表.
        /// </summary>
        public List<Detail> Details { set; get; }

        #endregion
    }
}
