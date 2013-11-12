using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace A0205_XmlToSql.Model
{

    public class Provinces
    {
        /// <summary>
        /// 省数组.
        /// </summary>
        [XmlElement("Province")]
        public Province[] ProvinceArray { set; get; }
    }

    /// <summary>
    /// 省.
    /// </summary>
    public class Province
    {
        /// <summary>
        /// 编号.
        /// </summary>
        [XmlAttribute("ID")]
        public int ID { set; get; }

        /// <summary>
        /// 名称.
        /// </summary>
        [XmlAttribute("ProvinceName")]
        public string ProvinceName { set; get; }

    }
}
