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
    /// 微信 图片信息请求.
    /// </summary>
    public class ImageRequest : AbstractMessageRequest
    {

        public ImageRequest()
        {
        }

        public ImageRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);

            XmlElement root = doc.DocumentElement;

            // 图片链接
            PicUrl = root.SelectSingleNode("PicUrl").InnerText;

            // 图片消息媒体id
            MediaId = root.SelectSingleNode("MediaId").InnerText;
        }



        /// <summary>
        /// 图片链接  
        /// </summary>
        public string PicUrl { set; get; }


        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。  
        /// </summary>
        public string MediaId { set; get; }



        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string MessageRequestToString()
        {
            return String.Format("PicUrl = {0}; MediaId = {1};", PicUrl, MediaId);
        }

    }


}