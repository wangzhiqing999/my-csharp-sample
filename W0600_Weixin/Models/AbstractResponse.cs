using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Configuration;


namespace W0600_Weixin.Models
{

    /// <summary>
    /// 微信 回复.
    /// 
    /// 抽象类，用于存储 公共的请求属性.
    /// </summary>
    public abstract class AbstractResponse
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID） 
        /// </summary>
        public string ToUserName { set; get; }


        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string FromUserName { set; get; }


        /// <summary>
        /// 消息创建时间 （整型）  
        /// 微信消息接口中的CreateTime表示距离1970年的秒数
        /// </summary>
        public int CreateTime
        {
            get
            {
                DateTime dt = new DateTime(1970, 1, 1);
                return (int)(DateTime.Now - dt).TotalSeconds;
            }
        }  



        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { set; get; }




        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected abstract string ResponseToString();


        /// <summary>
        /// 调试信息.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder("Response:");

            buff.AppendFormat("ToUserName = {0};", ToUserName);
            buff.AppendFormat("FromUserName = {0};", FromUserName);
            buff.AppendFormat("CreateTime = {0};", CreateTime);
            buff.AppendFormat("MsgType = {0};", MsgType);

            // 具体消息 特有的 消息数据.
            buff.AppendFormat(ResponseToString());


            return buff.ToString();
        }




        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected abstract string ResponseToXml();


        public string ToXml()
        {
            string result = String.Format(
                @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
{4}
</xml>",
                    this.ToUserName,
                    this.FromUserName,
                    // ConfigurationManager.AppSettings["WeixinUsername"],
                    this.CreateTime,
                    this.MsgType,
                    ResponseToXml()
                );

            return result;
        }


    }
}