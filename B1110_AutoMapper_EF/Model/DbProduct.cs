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
    /// 产品
    /// </summary>
    [Serializable]
    [Table("db_product")]
    public class DbProduct : AbstractCommonData
    {

        /// <summary>
        /// 产品代码.
        /// </summary>
        [Column("product_code")]
        [Display(Name = "产品代码")]
        [StringLength(16)]
        [Key]
        public string ProductCode { set; get; }




        /// <summary>
        /// 产品名称.
        /// </summary>
        [Column("product_name")]
        [Display(Name = "产品名称")]
        [StringLength(32)]
        public string ProductName { set; get; }





        /// <summary>
        /// 版本列表.
        /// </summary>
        public virtual List<DbVersion> VersionList { set; get; }




        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.AppendFormat("DbProduct [ ProductCode = {0}; ProductName = {1}; ", this.ProductCode, this.ProductName);
            buff.AppendLine();

            foreach (var item in this.VersionList)
            {
                buff.AppendLine(item.ToString());
            }

            buff.Append("]");
            return buff.ToString();
        }

    }

}
