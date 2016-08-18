using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Xml;


namespace W0600_Weixin.Models
{

    /// <summary>
    /// 微信 文本信息请求.
    /// </summary>
    public class TextRequest
    {

        public TextRequest()
        {
        }


        public TextRequest(XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            CreateTime = Convert.ToInt32(root.SelectSingleNode("CreateTime").InnerText);
            Content = root.SelectSingleNode("Content").InnerText;
            MsgId = Convert.ToInt64(root.SelectSingleNode("MsgId").InnerText);
        }



        /// <summary>
        /// 开发者微信号 
        /// </summary>
        public string ToUserName { set; get; }


        /// <summary>
        /// 发送方帐号（一个OpenID）  
        /// </summary>
        public string FromUserName {set;get;}


        /// <summary>
        /// 消息创建时间 （整型）  
        /// 微信消息接口中的CreateTime表示距离1970年的秒数
        /// </summary>
        public int CreateTime {set;get;}


        /// <summary>
        /// 消息创建时间 
        /// </summary>
        public DateTime CreateDateTime
        {
            get
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddSeconds(CreateTime);
                return dt;
            }
        }



        /// <summary>
        /// text
        /// </summary>
        public string MsgType {set;get;}   
 
        /// <summary>
        /// 文本消息内容  
        /// </summary>
        public string Content {set;get;}   


        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId {set;get;}



        public override string ToString()
        {
            StringBuilder buff = new StringBuilder("TextRequest:");

            buff.AppendFormat("ToUserName = {0};", ToUserName);
            buff.AppendFormat("FromUserName = {0};", FromUserName);
            buff.AppendFormat("CreateTime = {0};", CreateTime);
            buff.AppendFormat("CreateDateTime = {0};", CreateDateTime);
            buff.AppendFormat("Content = {0};", Content);
            buff.AppendFormat("MsgId = {0};", MsgId);

            return buff.ToString();
        }

    }


}