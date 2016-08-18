using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W0300_WCF_Ajax.Autocomplete
{
    public class TestCityData
    {
        /// <summary>
        /// 关键字.
        /// </summary>
        public string CityKeyword { set; get; }


        /// <summary>
        /// 城市名.
        /// </summary>
        public string CityName { set; get; }




        /// <summary>
        /// 测试数据.
        /// </summary>
        public static List<TestCityData> testCityList = new List<TestCityData>()
        {
            new TestCityData() { CityKeyword = "北京", CityName = "北京" },
            new TestCityData() { CityKeyword = "bj", CityName = "北京" },
            new TestCityData() { CityKeyword = "beijing", CityName = "北京" },

            new TestCityData() { CityKeyword = "上海", CityName = "上海" },
            new TestCityData() { CityKeyword = "sh", CityName = "上海" },
            new TestCityData() { CityKeyword = "shanghai", CityName = "上海" },

            new TestCityData() { CityKeyword = "广州", CityName = "广州" },
            new TestCityData() { CityKeyword = "gz", CityName = "广州" },
            new TestCityData() { CityKeyword = "guangzhou", CityName = "广州" },

            new TestCityData() { CityKeyword = "深圳", CityName = "深圳" },
            new TestCityData() { CityKeyword = "sz", CityName = "深圳" },
            new TestCityData() { CityKeyword = "shenzhen", CityName = "深圳" },

            new TestCityData() { CityKeyword = "苏州", CityName = "苏州" },
            new TestCityData() { CityKeyword = "sz", CityName = "苏州" },
            new TestCityData() { CityKeyword = "suzhou", CityName = "苏州" },

            new TestCityData() { CityKeyword = "南京", CityName = "南京" },
            new TestCityData() { CityKeyword = "nj", CityName = "南京" },
            new TestCityData() { CityKeyword = "nanjing", CityName = "南京" },

            new TestCityData() { CityKeyword = "南宁", CityName = "南宁" },
            new TestCityData() { CityKeyword = "nn", CityName = "南宁" },
            new TestCityData() { CityKeyword = "nanning", CityName = "南宁" },

        };


    }
}