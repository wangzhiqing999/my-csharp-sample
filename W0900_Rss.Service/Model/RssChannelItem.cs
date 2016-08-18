using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace W0900_Rss.Model
{

    public class RssChannelItem
    {

        /// <summary>
        /// 文章标题
        /// </summary>
        [XmlIgnore]
        public string Title { set; get; }

        /// <summary>
        /// Title 使用 CDATA 方式存储.
        /// </summary>
        [XmlElement("title")]
        public XmlNode TitleCData
        {
            get
            {
                return new XmlDocument().CreateCDataSection(this.Title);
            }
            set
            {
                this.Title = value.Value;
            }
        }







        /// <summary>
        /// 到达文章的超链接
        /// </summary>
        [XmlIgnore]
        public string Link { set; get; }

        /// <summary>
        /// Title 使用 CDATA 方式存储.
        /// </summary>
        [XmlElement("link")]
        public XmlNode LinkCData
        {
            get
            {
                return new XmlDocument().CreateCDataSection(this.Link);
            }
            set
            {
                this.Link = value.Value;
            }
        }





        /// <summary>
        /// 描述此文章
        /// </summary>
        [XmlIgnore]
        public string Description { set; get; }


        /// <summary>
        /// Description 使用 CDATA 方式存储.
        /// </summary>
        [XmlElement("description")]
        public XmlNode DescriptionCData
        {
            get
            {
                return new XmlDocument().CreateCDataSection(this.Description); 
            }
            set
            {
                this.Description = value.Value;
            }
        }




        // ##########  以上为 必须输入 .









        /// <summary>
        /// 第三方来源。
        /// </summary>
        [XmlElement("source")]
        public string Source { set; get; }




        /// <summary>
        /// 作者的电子邮件地址。
        /// </summary>
        [XmlElement("author")]
        public string Author { set; get; }






        /// <summary>
        /// 发布日期： 默认=现在.
        /// </summary>
        private DateTime m_PubDate = DateTime.Now;


        /// <summary>
        /// 发布日期。
        /// </summary>
        [XmlElement("pubDate")]
        public DateTime PubDate {
            set
            {
                m_PubDate = value;
            }
            get
            {
                return m_PubDate;
            }
        }







    }
}
