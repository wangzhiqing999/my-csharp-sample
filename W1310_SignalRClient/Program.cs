using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using W1310_SignalRClient.Sample;


namespace W1310_SignalRClient
{


    /// <summary>
    /// SignalR  测试 客户端
    /// 
    /// 主要参考下面的网页，进行编码处理。
    /// http://www.asp.net/signalr/overview/guide-to-the-api/hubs-api-guide-net-client
    /// 
    /// http://www.asp.net/signalr/overview/guide-to-the-api/hubs-api-guide-server
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Test1();

            
        }



        /// <summary>
        /// 聊天的测试.
        /// </summary>
        static void Test1()
        {
            TestSignalRClient client = new TestSignalRClient();

            client.DoTest();


            while (true)
            {
                string text = Console.ReadLine();

                if (String.IsNullOrEmpty(text))
                {
                    continue;
                }
                client.SendMessage(text);


                if (text == "exit" || text == "quit")
                {
                    break;
                }
            }
        }



        /// <summary>
        /// 调用参数与返回值的测试.
        /// </summary>
        static void Test2()
        {
            TestSignalRClient2 client = new TestSignalRClient2();

            client.DoTest();


            char[] emptyChars = { ' ' };

            while (true)
            {
                string text = Console.ReadLine();

                if (String.IsNullOrEmpty(text))
                {
                    continue;
                }

                
                string[] inputData = text.Split(emptyChars, StringSplitOptions.RemoveEmptyEntries);

                switch (inputData[0])
                {
                    case "hello":
                        client.TestHello();
                        break;

                    case "get":
                        if (inputData.Length > 1)
                        {
                            client.TestStock(inputData[1]);
                        }
                        else
                        {
                            Console.WriteLine("Bad Command Param.");
                        }
                        
                        break;

                    case "list":
                        if (inputData.Length > 1)
                        {
                            client.TestList(inputData[1]);
                        }
                        else
                        {
                            Console.WriteLine("Bad Command Param.");
                        }
                        
                        break;

                    default:
                        Console.WriteLine("Unknoe Command.");
                        break;
                }


                if (text == "exit" || text == "quit")
                {
                    break;
                }
            }
        }


    }
}
