using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0600_Weixin.Models
{
    public class MessageType
    {

        /// <summary>
        /// 文本消息类型.
        /// </summary>
        public const string TextMsgType = "text";

        /// <summary>
        /// 图片消息类型.
        /// </summary>
        public const string ImageMsgType = "image";

        /// <summary>
        /// 语音消息类型.
        /// </summary>
        public const string VoiceMsgType = "voice";

        /// <summary>
        /// 视频消息类型.
        /// </summary>
        public const string VideoMsgType = "video";

        /// <summary>
        /// 地理位置消息类型.
        /// </summary>
        public const string LocationMsgType = "location";

        /// <summary>
        /// 链接消息类型.
        /// </summary>
        public const string LinkMsgType = "link";






        /// <summary>
        /// 事件.
        /// </summary>
        public const string EventMsgType = "event";


    }
}