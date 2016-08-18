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
    /// 自定义菜单事件
    /// </summary>
    public class ClickEventRequest : AbstractEventRequest
    {
        public ClickEventRequest()
        {
        }


        public ClickEventRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);

            XmlElement root = doc.DocumentElement;
            // 事件KEY值，与自定义菜单接口中KEY值对应
            EventKey = root.SelectSingleNode("EventKey").InnerText;

        }

        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { set; get; }





        protected override string EventRequestToString()
        {
            return String.Format("EventKey = {0}", EventKey);
        }
    }
}