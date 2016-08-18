using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Xml;


using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Message
{

    /// <summary>
    /// 微信 语音信息请求.
    /// </summary>
    public class VoiceRequest : AbstractMessageRequest
    {

        public VoiceRequest()
        {
        }


        public VoiceRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;
            // 语音消息媒体id
            MediaId = root.SelectSingleNode("MediaId").InnerText;
            // 语音格式，如amr，speex等
            Format = root.SelectSingleNode("Format").InnerText;
        }




        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { set; get; }


        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { set; get; }



        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string MessageRequestToString()
        {
            return String.Format("MediaId = {0}; Format = {1};", MediaId, Format);
        }


    }
}