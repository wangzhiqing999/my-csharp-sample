using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;



namespace A0620_EFv4.Sample
{

    /// <summary>
    /// 测试数据类.
    /// 
    /// 该类中每一个属性，与 数据库中的表列名一致.
    /// </summary>
    public class mr_demo_data
    {

        /// <summary>
        /// Key 表示主键.
        /// </summary>
        [Key]
        public int demo_id { set; get; }


        public int city_id { set; get; }

        public int dept_id { set; get; }

        public string demo_info { set; get; }


        public override string ToString()
        {
            return String.Format("mr_demo_data[ id={0}; city={1}; dept={2}; info={3} ]",
                demo_id,
                city_id,
                dept_id,
                demo_info
                );
        }
    }
}
