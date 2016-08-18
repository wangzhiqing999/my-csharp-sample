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
    /// 微信 地理位置信息请求.
    /// </summary>
    public class LocationRequest : AbstractMessageRequest
    {
        public LocationRequest()
        {
        }


        public LocationRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;
            // 地理位置维度
            Location_X = root.SelectSingleNode("Location_X").InnerText;
            // 地理位置经度
            Location_Y = root.SelectSingleNode("Location_Y").InnerText;
            // 地图缩放大小
            Scale = root.SelectSingleNode("Scale").InnerText;
            // 地理位置信息
            Label = root.SelectSingleNode("Label").InnerText;
        }

        /// <summary>
        /// 地理位置维度
        /// </summary>
        public string Location_X { set; get; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y { set; get; }

        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { set; get; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { set; get; }



        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string MessageRequestToString()
        {
            return String.Format(
                "Location_X = {0}; Location_Y = {1}; Scale = {2}; Label = {3};",
                Location_X, Location_Y, Scale, Label);
        }
    }
}