using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;


using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Message
{

    /// <summary>
    /// 微信 文本信息反馈.
    /// </summary>
    public class TextResponse : AbstractResponse
    {

        public TextResponse()
        {
            this.MsgType = "text";
        }


        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）  
        /// </summary>
        public string Content { set; get; }


        protected override string ResponseToString()
        {
            return String.Format("Content = {0};", Content);
        }

        protected override string ResponseToXml()
        {
            return String.Format("<Content><![CDATA[{0}]]></Content>", Content);
        }
    }

}