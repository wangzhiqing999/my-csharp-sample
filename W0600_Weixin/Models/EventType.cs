using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0600_Weixin.Models
{
    public class EventType
    {


        /// <summary>
        /// 关注事件.
        /// </summary>
        public const string SubscribeEventType = "subscribe";


        /// <summary>
        /// 取消关注事件.
        /// </summary>
        public const string UnsubscribeEventType = "unsubscribe";



        /// <summary>
        /// 用户已关注时 扫描带参数二维码事件
        /// </summary>
        public const string ScanEventType = "SCAN";



        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        public const string LocationEventType = "LOCATION";
        


        /// <summary>
        /// 自定义菜单事件
        /// </summary>
        public const string ClickEventType = "CLICK";
        

    }
}