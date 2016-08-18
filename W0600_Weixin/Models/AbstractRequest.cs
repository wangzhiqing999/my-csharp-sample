using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Xml;



namespace W0600_Weixin.Models
{

    /// <summary>
    /// 微信 请求.
    /// 
    /// 抽象类，用于存储 公共的请求属性.
    /// </summary>
    public abstract class AbstractRequest
    {


        /// <summary>
        /// 开发者微信号 
        /// </summary>
        public string ToUserName { set; get; }


        /// <summary>
        /// 发送方帐号（一个OpenID）  
        /// </summary>
        public string FromUserName { set; get; }


        /// <summary>
        /// 消息创建时间 （整型）  
        /// 微信消息接口中的CreateTime表示距离1970年的秒数
        /// </summary>
        public int CreateTime { set; get; }


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
        /// 消息类型
        /// </summary>
        public string MsgType { set; get; }











        /// <summary>
        /// 初始化数据.
        /// </summary>
        /// <param name="doc"></param>
        protected virtual void InitRequest(XmlDocument doc)
        {
            // 文档根节点.
            XmlElement root = doc.DocumentElement;

            // 开发者微信号
            ToUserName = root.SelectSingleNode("ToUserName").InnerText;

            // 发送方帐号（一个OpenID）
            FromUserName = root.SelectSingleNode("FromUserName").InnerText;

            // 消息创建时间 （整型）
            CreateTime = Convert.ToInt32(root.SelectSingleNode("CreateTime").InnerText);

            // 消息类型.
            MsgType = root.SelectSingleNode("MsgType").InnerText;


        }







        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected abstract string RequestToString();


        /// <summary>
        /// 调试信息.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder("Request:");

            buff.AppendFormat("ToUserName = {0};", ToUserName);
            buff.AppendFormat("FromUserName = {0};", FromUserName);
            buff.AppendFormat("CreateTime = {0};", CreateTime);
            buff.AppendFormat("CreateDateTime = {0};", CreateDateTime);
            buff.AppendFormat("MsgType = {0};", MsgType);

            // 具体消息 特有的 消息数据.
            buff.AppendFormat(RequestToString());


            return buff.ToString();
        }






    }
}