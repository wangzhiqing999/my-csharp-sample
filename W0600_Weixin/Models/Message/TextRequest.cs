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
    /// 微信 文本信息请求.
    /// </summary>
    public class TextRequest : AbstractMessageRequest
    {

        public TextRequest()
        {
        }


        public TextRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;
            // 文本消息内容
            Content = root.SelectSingleNode("Content").InnerText;            
        }


        /// <summary>
        /// 文本消息内容  
        /// </summary>
        public string Content {set;get;}   





        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string MessageRequestToString()
        {
            return String.Format("Content = {0};", Content);
        }


    }


}