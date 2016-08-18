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
    /// 关注事件
    /// </summary>
    public class SubscribeEventRequest : AbstractEventRequest
    {



        public SubscribeEventRequest()
        {
        }


        public SubscribeEventRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;

            if (root.SelectSingleNode("EventKey") != null)
            {
                // 用户是通过 扫码关注的.
                // 事件KEY值
                EventKey = root.SelectSingleNode("EventKey").InnerText;
            }
            if (root.SelectSingleNode("Ticket") != null)
            {
                // 用户是通过 扫码关注的.
                // 二维码的ticket
                Ticket = root.SelectSingleNode("Ticket").InnerText;
            }

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
            if (!String.IsNullOrEmpty(this.EventKey))
            {
                return String.Format(
                    "EventKey = {0}; Ticket = {1}; ",
                    EventKey, Ticket);
            }

            // 不是扫码关注的， 返回空白.
            return "";
        }


    }
}