using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Xml;



using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Message
{

    /// <summary>
    /// 微信 链接信息请求.
    /// </summary>
    public class LinkRequest : AbstractMessageRequest
    {

        public LinkRequest()
        {
        }


        public LinkRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;
            // 消息标题
            Title = root.SelectSingleNode("Title").InnerText;
            // 消息描述
            Description = root.SelectSingleNode("Description").InnerText;
            // 消息链接
            Url = root.SelectSingleNode("Url").InnerText;

        }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { set; get; }






        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string MessageRequestToString()
        {
            return String.Format(
                "Title = {0}; Description = {1}; Url = {2}; ",
                Title, Description, Url);
        }
    }


}