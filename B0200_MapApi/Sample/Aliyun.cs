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
    /// 阿里云 地图服务.
    /// 
    /// 参考文档：
    /// http://ditu.aliyun.com/jsdoc/geocode_api.html
    /// </summary>
    public class AliyunMapServuce
    {

        private const string BASE_URL = "http://gc.ditu.aliyun.com/geocoding?a=";


        public AliyunGeocodingResult Geocoding(string addressName)
        {
            string url = BASE_URL + System.Web.HttpUtility.UrlEncode(addressName, Encoding.UTF8);


            //访问该链接
            WebRequest wrt = WebRequest.Create(url);
            //获得返回值
            WebResponse wrs = wrt.GetResponse();
            // 从 Internet 资源返回数据流。
            Stream s = wrs.GetResponseStream();
            // 构造 序列化类.
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(AliyunGeocodingResult));
            // 读取结果.
            AliyunGeocodingResult result = (AliyunGeocodingResult)dcjs.ReadObject(s);

            // 返回.
            return result;
        }

    }


    /// <summary>
    /// 阿里云地址匹配结果
    /// </summary>
    [Serializable]
    [DataContract] 
    public class AliyunGeocodingResult
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        [DataMember]
        public string cityName { set; get; }


        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string adress { set; get; }


        /// <summary>
        /// 匹配级别
        /// （0 中国，1 省，2 地级市，3 县，4 乡镇，5街道，6 小区，7 具体的POI，8 门牌号级别，-1 查询失败）
        /// </summary>
        [DataMember]
        public int level { set; get; }


        /// <summary>
        ///  精确度 
        ///  （1 完全正确，2 比较正确 ，3 可能正确）
        /// </summary>
        [DataMember]
        public int alevel { set; get; }


        /// <summary>
        /// 纬度
        /// </summary>
        [DataMember]
        public decimal lat { set; get; }


        /// <summary>
        /// 经度
        /// </summary>
        [DataMember]
        public decimal lon { set; get; }



        public override string ToString()
        {
            return String.Format("阿里云Geocoding结果：城市名称={0},地址={1},匹配级别={2},精确度={3},纬度={4},经度={5}",
                this.cityName,
                this.adress,
                this.level,
                this.alevel,
                this.lat,
                this.lon);
        }

    }

}
