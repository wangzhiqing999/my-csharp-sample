using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;

namespace W0600_Weixin.Models
{

    /// <summary>
    /// 微信 文本信息反馈.
    /// </summary>
    public class TextResponse
    {

        /// <summary>
        /// 接收方帐号（收到的OpenID）  
        /// </summary>
        public string  ToUserName{ set; get; }  


        /// <summary>
        /// 开发者微信号  
        /// </summary>
        public string FromUserName{ set; get; }  


        /// <summary>
        /// 消息创建时间 （整型）  
        /// </summary>
        public int CreateTime{
            get
            {
                DateTime dt = new DateTime(1970, 1, 1);
                return (int)(DateTime.Now - dt).TotalSeconds;
            }
        }  

        /// <summary>
        /// text  
        /// </summary>
        public string MsgType {
            get
            {
                return "text";
            }
        }


        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）  
        /// </summary>
        public string Content { set; get; }





        public override string ToString()
        {
            StringBuilder buff = new StringBuilder("TextRequest:");

            buff.AppendFormat("ToUserName = {0};", ToUserName);
            buff.AppendFormat("FromUserName = {0};", FromUserName);
            buff.AppendFormat("CreateTime = {0};", CreateTime);
            buff.AppendFormat("MsgType = {0};", MsgType);
            buff.AppendFormat("Content = {0};", Content);

            return buff.ToString();
        }



        public string ToXml()
        {
            string result = String.Format(
                @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<Content><![CDATA[{4}]]></Content>
</xml>",
                    this.ToUserName,
                    this.FromUserName,
                    this.CreateTime,
                    this.MsgType,
                    this.Content
                );

            return result;
        }


    }

}