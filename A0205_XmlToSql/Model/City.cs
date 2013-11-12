using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace A0205_XmlToSql.Model
{

    public class Cities
    {
        /// <summary>
        /// 城市数组.
        /// </summary>
        [XmlElement("City")]
        public City[] CityArray { set; get; }
    }



    /// <summary>
    /// 城市.
    /// </summary>
    public class City
    {
        /// <summary>
        /// 城市编号.
        /// </summary>
        [XmlAttribute("ID")]
        public int ID { set; get; }


        /// <summary>
        /// 省编号.
        /// </summary>
        [XmlAttribute("PID")]
        public int PID { set; get; }


        /// <summary>
        /// 城市名
        /// </summary>
        [XmlAttribute("CityName")]
        public string CityName { set; get; }


        /// <summary>
        /// 城市 邮政编码.
        /// </summary>
        [XmlAttribute("ZipCode")]
        public string ZipCode { set; get; }

    }


}
