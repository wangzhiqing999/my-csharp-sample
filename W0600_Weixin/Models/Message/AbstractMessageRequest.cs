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
    /// 抽象消息请求.
    /// </summary>
    public abstract class AbstractMessageRequest : AbstractRequest
    {


        protected override void InitRequest(System.Xml.XmlDocument doc)
        {
            base.InitRequest(doc);

            // 文档根节点.
            XmlElement root = doc.DocumentElement;

            // 消息id，64位整型
            MsgId = Convert.ToInt64(root.SelectSingleNode("MsgId").InnerText);
        }



        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { set; get; }






        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected abstract string MessageRequestToString();



        protected override string RequestToString()
        {
            StringBuilder buff = new StringBuilder();

            // 具体消息 特有的 消息数据.
            buff.AppendFormat(MessageRequestToString());

            buff.AppendFormat("MsgId = {0};", MsgId);

            return buff.ToString();
        }
    }

}