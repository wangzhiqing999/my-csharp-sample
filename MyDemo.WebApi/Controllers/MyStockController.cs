using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;


namespace MyDemo.WebApi.Controllers
{


    [Authorize]
    public class MyStockController : ApiController
    {

        private static List<TestStockData> testDataList = new List<TestStockData>()
        {
            new TestStockData() {
                UserID = 1,
                StockCode = "SH600929",
                StockName = "湖南盐业"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SZ300152",
                StockName = "科融环境"
            },
            new TestStockData() {
                UserID = 3,
                StockCode = "SZ002307",
                StockName = "北新路桥"
            },

            new TestStockData() {
                UserID = 1,
                StockCode = "SZ300698",
                StockName = "万马科技"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SZ300663",
                StockName = "科蓝软件"
            },
            new TestStockData() {
                UserID = 3,
                StockCode = "SZ300562",
                StockName = "乐心医疗"
            },

            new TestStockData() {
                UserID = 1,
                StockCode = "SZ300504",
                StockName = "天邑股份"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SZ002931",
                StockName = "锋龙股份"
            },
            new TestStockData() {
                UserID = 3,
                StockCode = "SH603897",
                StockName = "长城科技"
            },

            new TestStockData() {
                UserID = 1,
                StockCode = "SZ300673",
                StockName = "佩蒂股份"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SZ300288",
                StockName = "朗玛信息"
            },
            new TestStockData() {
                UserID = 3,
                StockCode = "SZ300541",
                StockName = "先进数通"
            },

            new TestStockData() {
                UserID = 1,
                StockCode = "SZ300634",
                StockName = "彩讯股份"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SZ300706",
                StockName = "阿石创"
            },
            new TestStockData() {
                UserID = 3,
                StockCode = "SH603917",
                StockName = "合力科技"
            },

            new TestStockData() {
                UserID = 1,
                StockCode = "SZ300469",
                StockName = "信息发展"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SH603214",
                StockName = "爱婴室"
            },
            new TestStockData() {
                UserID = 3,
                StockCode = "SH600180",
                StockName = "瑞茂通"
            },
            
            new TestStockData() {
                UserID = 1,
                StockCode = "SH600283",
                StockName = "钱江水利"
            },
            new TestStockData() {
                UserID = 2,
                StockCode = "SZ002908",
                StockName = "德生科技"
            },
        };




        // GET api/<controller>
        public IEnumerable<TestStockData> Get()
        {
            // 获取令牌内的详细信息.
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value;

            long uid = Convert.ToInt64(userid);

            var query =
                from data in testDataList
                where
                    data.UserID == uid
                select
                    data;

            var resultList = query.ToList();
            return resultList;
        }

    }




    /// <summary>
    /// 测试股票数据.
    /// </summary>
    public class TestStockData
    {
        /// <summary>
        /// 用户代码.
        /// </summary>
        public long UserID { set; get; }


        /// <summary>
        /// 股票代码.
        /// </summary>
        public string StockCode { set; get; }


        /// <summary>
        /// 股票名称.
        /// </summary>
        public string StockName { set; get; }

    }


}