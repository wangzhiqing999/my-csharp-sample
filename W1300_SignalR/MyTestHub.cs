using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace W1300_SignalR
{


    /// <summary>
    /// 这个 测试的 Hub， 是用于  .NET 客户端进行测试的。
    /// </summary>
    [HubName("MyTest")]
    public class MyTestHub : Hub
    {
        /// <summary>
        /// 随机数.
        /// </summary>
        private Random random = new Random();


        /// <summary>
        /// 默认的， 无参数， 无返回值的 方法.
        /// </summary>
        public void Hello()
        {

            // 将调用 所有客户端的 hello 方法.
            Clients.All.hello();
        }



        /// <summary>
        /// 有返回值得方法.
        /// 
        /// 查询股票数据.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Stock GetStockData(string code)
        {
            Stock result = new Stock()
            {
                Symbol = code,
                Price = 100 + random.Next(-100, 100),
            };

            return result;
        }


        /// <summary>
        /// 测试 参数是 对象， 结果为集合.
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public IEnumerable<Stock> GetStockList(Stock stock)
        {
            List<Stock> resultList = new List<Stock>();

            
            resultList.Add(stock);


            Stock result = new Stock()
            {
                Symbol = stock.Symbol,
                Price = 100 + random.Next(-100, 100),
            };
            resultList.Add(result);


            result = new Stock()
            {
                Symbol = stock.Symbol,
                Price = 100 + random.Next(-100, 100),
            };
            resultList.Add(result);


            return resultList;
        }


    }



    /// <summary>
    /// 用于测试的 股票数据对象.
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// 股票号码.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 股票价格.
        /// </summary>
        public decimal Price { get; set; }
    }




}