using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;



namespace W1310_SignalRClient.Sample
{
    class TestSignalRClient2
    {

        /// <summary>
        /// 服务器的连接.
        /// </summary>
        private HubConnection hubConnection;



        /// <summary>
        /// Hub 代理.
        /// </summary>
        private IHubProxy myTestHubProxy;



        public void DoTest()
        {
            // 服务器的连接.
            hubConnection = new HubConnection("http://localhost:15858/");

            // 如果网络连接速度慢了.
            hubConnection.ConnectionSlow += () => Console.WriteLine("Connection problems.");

            // 如果发生了异常.
            hubConnection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);

            // 日志开关.
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = Console.Out;


            // 关联 Hub.
            myTestHubProxy = hubConnection.CreateHubProxy("MyTest");





            // Hub 中， 需要客户端实现的方法.
            myTestHubProxy.On("hello", () => Console.WriteLine("服务器调用客户端的 Hello !"));





            // hubConnection.Start();

            // 注意： 如果遇到那种 后台程序， 是连接上以后，需要立即发送消息的情况下。
            // 需要将代码修改为：
            hubConnection.Start().Wait();

            // 如果没有 Wait() ， hubConnection.Start();  下一行马上就 发消息。 将会报错，提示连接处于断开的状态.
            myTestHubProxy.Invoke("Hello");

        }


        public void TestHello()
        {
            Console.WriteLine("客户端调用 服务器的 Hello() 方法！");
            myTestHubProxy.Invoke("Hello");
        }


        public void TestStock(string code)
        {
            Console.WriteLine("客户端调用 服务器的， 有参数， 有返回值的 GetStockData 方法 ");

            var stock = myTestHubProxy.Invoke<Stock>("GetStockData", code).Result;

            Console.WriteLine("调用结果：{0}", stock);
        }


        public void TestList(string code)
        {
            Console.WriteLine("客户端调用 服务器的， 参数是 对象， 结果为集合 的 GetStockList 方法 ");

            var stocks = myTestHubProxy.Invoke<IEnumerable<Stock>>("GetStockList", new Stock() { Symbol = code, Price = 135 }).Result; 


            foreach (var stock in stocks)
            {
                Console.WriteLine("调用结果：{0}", stock);
            }
            
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


        public override string ToString()
        {
            return String.Format("Symbol = {0}, Price = {1}", Symbol, Price);
        }
    }


}
