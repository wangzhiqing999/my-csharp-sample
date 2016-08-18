using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Text;
using System.Xml;




namespace W0600_Weixin.Models.Event
{

    /// <summary>
    /// 扫描带参数二维码事件
    /// </summary>
    public class ScanEventRequest : AbstractEventRequest
    {

        public ScanEventRequest()
        {
        }


        public ScanEventRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;

            // 事件KEY值
            EventKey = root.SelectSingleNode("EventKey").InnerText;
            // 二维码的ticket
            Ticket = root.SelectSingleNode("Ticket").InnerText;

        }


        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { set; get; }


        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { set; get; }


        protected override string EventRequestToString()
        {
            return String.Format(
                "EventKey = {0}; Ticket = {1}; ",
                EventKey, Ticket);
        }
    }


}