using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using System.Text;
using System.Xml;


using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Event
{

    /// <summary>
    /// 抽象事件请求.
    /// </summary>
    public abstract class AbstractEventRequest : AbstractRequest
    {


        protected override void InitRequest(System.Xml.XmlDocument doc)
        {
            base.InitRequest(doc);

            // 文档根节点.
            XmlElement root = doc.DocumentElement;

            // 事件类型
            Event = root.SelectSingleNode("Event").InnerText;
        }

        /// <summary>
        /// 事件类型  
        /// </summary>
        public string Event { set; get; }




        /// <summary>
        /// 具体事件 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected abstract string EventRequestToString();



        protected override string RequestToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("Event = {0};", Event);

            // 具体消息 特有的 消息数据.
            buff.AppendFormat(EventRequestToString());

            return buff.ToString();
        }

    }
}