using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;



namespace A0621_EF_CodeFirst.Sample
{

    /// <summary>
    ///  测试数据.
    /// </summary>
    [Table("mr_demo_data")]
    public class MrDemoData
    {

        /// <summary>
        /// Key 表示主键.
        /// </summary>
        [Key]
        [Column("demo_id")]
        public int DemoID { set; get; }

        /// <summary>
        /// 城市编号
        /// </summary>
        [Column("city_id")]
        public int CityID { set; get; }

        /// <summary>
        /// 部门编号
        /// </summary>
        [Column("dept_id")]
        public int DeptID { set; get; }


        /// <summary>
        /// 用于演示的数据信息.
        /// </summary>
        [Column("demo_info")]
        public string DemoInfo { set; get; }


        /// <summary>
        /// 用于 测试 NotMapped .
        /// </summary>
        [NotMapped] 
        public bool IsMainCity
        {
            get
            {
                return CityID == 1;
            }
        }


        public override string ToString()
        {
            return String.Format("mr_demo_data[ id={0}; city={1}; dept={2}; info={3} ]",
                DemoID,
                CityID,
                DeptID,
                DemoInfo
                );
        }

    }
}
