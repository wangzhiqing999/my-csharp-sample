using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace A0205_XmlToSql.Model
{

    public class Districts
    {
        /// <summary>
        /// 区县数组.
        /// </summary>
        [XmlElement("District")]
        public District[] DistrictArray { set; get; }
    }



    /// <summary>
    /// 区县.
    /// </summary>
    public class District
    {
        /// <summary>
        /// 区县编号.
        /// </summary>
        [XmlAttribute("ID")]
        public int ID { set; get; }


        /// <summary>
        /// 城市编号.
        /// </summary>
        [XmlAttribute("CID")]
        public int CID { set; get; }


        /// <summary>
        /// 区县名
        /// </summary>
        [XmlAttribute("DistrictName")]
        public string DistrictName { set; get; }
    }

}
