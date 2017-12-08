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
    /// 用户.
    /// </summary>
    [Table("test_user")]
    [ToString]
    public class User
    {

        /// <summary>
        /// 用户ID.
        /// </summary>
        [Column("user_id")]
        [Key]
        public long UserID { set; get; }



        /// <summary>
        /// 用户名.
        /// </summary>
        [Column("user_name")]
        [Required]
        [StringLength(32)]
        public string UserName { set; get; }



        #region 一对多.


        /// <summary>
        /// 主数据列表.
        /// </summary>
        public List<Master> Masters { set; get; }

        #endregion


    }
}
