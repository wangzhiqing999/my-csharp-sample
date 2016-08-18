using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Xml;

using W0600_Weixin.Models;


namespace W0600_Weixin.Models.Event
{

    /// <summary>
    /// 微信 地理位置信息请求.
    /// </summary>
    public class LocationEventRequest : AbstractEventRequest
    {
        public LocationEventRequest()
        {
        }


        public LocationEventRequest(XmlDocument doc)
        {
            // 初始化共通信息.
            base.InitRequest(doc);


            XmlElement root = doc.DocumentElement;
            // 地理位置维度
            Latitude = root.SelectSingleNode("Latitude").InnerText;
            // 地理位置经度
            Longitude = root.SelectSingleNode("Longitude").InnerText;
            // 地理位置精度
            Precision = root.SelectSingleNode("Precision").InnerText;

        }

        /// <summary>
        /// 地理位置维度
        /// </summary>
        public string Latitude { set; get; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Longitude { set; get; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        public string Precision { set; get; }





        /// <summary>
        /// 具体消息 特有的 消息数据.
        /// </summary>
        /// <returns></returns>
        protected override string EventRequestToString()
        {
            return String.Format(
                "Latitude = {0}; Longitude = {1}; Precision = {2}; ",
                Latitude, Longitude, Precision);
        }
    }


}