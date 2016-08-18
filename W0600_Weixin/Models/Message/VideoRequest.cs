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
    /// 微信 视频信息请求.
    /// </summary>
    public class VideoRequest : AbstractMessageRequest
    {


        public VideoRequest()
        {
        }


        public VideoRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;
            // 视频消息媒体id
            MediaId = root.SelectSingleNode("MediaId").InnerText;
            // 视频消息缩略图的媒体id
            ThumbMediaId = root.SelectSingleNode("ThumbMediaId").InnerText;
        }




        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { set; get; }


        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { set; get; }


        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string MessageRequestToString()
        {
            return String.Format("MediaId = {0}; ThumbMediaId = {1};", MediaId, ThumbMediaId);
        }
    }

}