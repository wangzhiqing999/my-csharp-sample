using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace B1110_AutoMapper_EF.Model
{


    /// <summary>
    /// 产品版本.
    /// </summary>
    [Serializable]
    [Table("db_version")]
    public class DbVersion : AbstractCommonData
    {


        /// <summary>
        /// 版本流水.
        /// </summary>
        [Column("version_id")]
        [Display(Name = "版本流水")]
        [Key]
        public long VersionID { set; get; }


        /// <summary>
        /// 产品代码.
        /// </summary>
        [Column("product_code")]
        [Display(Name = "产品代码")]
        [StringLength(16)]
        public string ProductCode { set; get; }


        /// <summary>
        /// 产品.
        /// </summary>
        public virtual DbProduct ProductData { set; get; }




        /// <summary>
        /// 版本号.
        /// </summary>
        [Column("version_number")]
        [Display(Name = "版本号")]
        [StringLength(32)]
        public string VersionNumber { set; get; }



        /// <summary>
        /// 版本数值.
        /// </summary>
        [Column("version_code")]
        [Display(Name = "版本数值")]
        public int VersionCode { set; get; }



        /// <summary>
        /// 版本描述.
        /// </summary>
        [Column("version_desc")]
        [Display(Name = "版本描述")]
        [StringLength(256)]
        public string VersionDesc { set; get; }



        /// <summary>
        /// 版本文件.
        /// </summary>
        [Column("version_file")]
        [Display(Name = "版本文件")]
        [StringLength(64)]
        public string VersionFile { set; get; }






        public override string ToString()
        {
            return String.Format("DbVersion [ VersionID = {0}; ProductCode = {1}; VersionCode = {2}; VersionNumber = {3}, VersionDesc = {4}, VersionFile = {5} ]",
                this.VersionID,
                this.ProductCode,
                this.VersionCode,
                this.VersionNumber,
                this.VersionDesc,
                this.VersionFile);
        }


    }


}
