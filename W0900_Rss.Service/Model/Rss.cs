using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace W0900_Rss.Model
{


    [XmlRoot("rss")]
    public class Rss 
    {

        public Rss()
        {
            this.Version = "2.0";
        }

        [XmlAttribute("version")]
        public string Version { set; get; }


        [XmlElement("channel")]
        public RssChannel Channel { set; get; }

    }


}
