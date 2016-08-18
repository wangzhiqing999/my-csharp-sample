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
    /// 取消关注事件
    /// </summary>
    public class UnsubscribeEventRequest : AbstractEventRequest
    {


        public UnsubscribeEventRequest()
        {
        }


        public UnsubscribeEventRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);           
        }


        protected override string EventRequestToString()
        {
            return "";
        }

    }
}