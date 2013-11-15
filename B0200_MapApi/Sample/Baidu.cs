using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;
using System.Web;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace B0200_MapApi.Sample
{

    /// <summary>
    /// 百度地图服务.
    /// 
    /// 参考文档：
    /// http://developer.baidu.com/map/webservice-geocoding.htm
    /// </summary>
    public class BaiduMapService
    {

        /// <summary>
        /// 这里需要去百度注册一个 AK
        /// </summary>
        private const string BASE_URL = "http://api.map.baidu.com/geocoder/v2/?output=json&ak=你的百度AK&address=";



        public BaiduGeocoderResult Geocoding(string addressName)
        {
            string url = BASE_URL + System.Web.HttpUtility.UrlEncode(addressName, Encoding.UTF8);


            //访问该链接
            WebRequest wrt = WebRequest.Create(url);
            //获得返回值
            WebResponse wrs = wrt.GetResponse();
            // 从 Internet 资源返回数据流。
            Stream s = wrs.GetResponseStream();
            // 构造 序列化类.
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(BaiduGeocoderResult));
            // 读取结果.
            BaiduGeocoderResult result = (BaiduGeocoderResult)dcjs.ReadObject(s);

            // 返回.
            return result;
        }

    }


    /// <summary>
    /// 百度地图 匹配结果.
    /// </summary>
    [Serializable]
    [DataContract]     
    public class BaiduGeocoderResult
    {

        /// <summary>
        /// 返回结果状态值， 成功返回0
        /// </summary>
        [DataMember]
        public int status { set; get; }


        /// <summary>
        /// 结果数据.
        /// </summary>
        [DataMember]
        public BaiduResult result{set;get;}


        public override string ToString()
        {
            return String.Format("百度Geocoding结果：status={0}， result={1}", status, result);
        }
    }



    [Serializable]
    [DataContract] 
    public class BaiduResult
    {

        /// <summary>
        /// 经纬度坐标
        /// </summary>
        [DataMember]
        public BaiduLocation location { set; get; }


        /// <summary>
        /// 位置的附加信息，是否精确查找。1为精确查找，0为不精确。
        /// </summary>
        [DataMember]
        public int precise { set; get; }


        /// <summary>
        /// 可信度
        /// </summary>
        [DataMember]
        public int confidence { set; get; }


        /// <summary>
        /// 地址类型
        /// </summary>
        [DataMember]
        public string level { set; get; }



        public override string ToString()
        {
            return String.Format("[经纬度坐标={0};是否精确查找={1};可信度={2};地址类型={3}]", location, precise, confidence, level);
        }
    }



    /// <summary>
    /// 经纬度坐标
    /// </summary>
    [Serializable]
    [DataContract] 
    public class BaiduLocation
    {
        /// <summary>
        /// 纬度值
        /// </summary>
        [DataMember]
        public decimal lat { set; get; }


        /// <summary>
        /// 经度值
        /// </summary>
        [DataMember]
        public decimal lng { set; get; }





        public override string ToString()
        {
            return String.Format("[纬度={0}, 经度={1}]", lat, lng);
        }
    }




}
