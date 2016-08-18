using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



namespace W0900_Rss.Model
{


    public class RssChannel
    {



        /// <summary>
        /// 频道的标题
        /// </summary>
        [XmlElement("title")]
        public string Title { set; get; }



        /// <summary>
        /// 到达频道的超链接
        /// </summary>
        [XmlElement("link")]
        public string Link { set; get; }



        /// <summary>
        /// 描述此频道
        /// </summary>
        [XmlElement("description")]
        public string Description { set; get; }



        // ##########  以上为 必须输入 .




        [XmlElement("item")]
        public RssChannelItem[] Items { set; get; }





        // ##########  以下为 可选输入 .



        /// <summary>
        /// 种类
        /// </summary>
        [XmlElement("category")]
        public string Category { set; get; }



        /// <summary>
        /// 版权信息.
        /// </summary>
        [XmlElement("copyright")]
        public string Copyright { set; get; }



        /// <summary>
        /// 文档语言.
        /// </summary>
        [XmlElement("language")]
        public string Language { set; get; }



        /// <summary>
        /// 生成器.
        /// </summary>
        [XmlElement("generator")]
        public string generator { set; get; }



        /// <summary>
        /// feed 内容定义最后发布日期。
        /// </summary>
        [XmlElement("pubDate")]
        public DateTime PubDate { set; get; }


        /// <summary>
        ///  feed 内容的最后修改日期。
        /// </summary>
        [XmlElement("lastBuildDate")]
        public DateTime LastBuildDate { set; get; }

    }

}
