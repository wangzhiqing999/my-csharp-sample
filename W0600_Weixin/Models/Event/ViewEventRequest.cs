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
    /// 点击菜单跳转链接时的事件
    /// </summary>
    public class ViewEventRequest : AbstractEventRequest
    {
        public ViewEventRequest()
        {
        }


        public ViewEventRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);

            XmlElement root = doc.DocumentElement;
            // 事件KEY值，设置的跳转URL
            EventKey = root.SelectSingleNode("EventKey").InnerText;

        }

        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { set; get; }





        protected override string EventRequestToString()
        {
            return String.Format("EventKey = {0}", EventKey);
        }
    }
}