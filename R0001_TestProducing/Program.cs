using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RabbitMQ.Client;


namespace R0001_TestProducing
{


    /// <summary>
    /// 用于测试 RabbitMQ 的 生产者程序.
    /// 
    /// Hello World 版本
    /// </summary>
    class Program
    {


        
        static void Main(string[] args)
        {            
            var factory = new ConnectionFactory();

            // RabbitMQ 服务器的 ip/用户名/密码.
            factory.HostName = "172.19.6.52";
            factory.UserName = "tester";
            factory.Password = "hello!";


            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    // 名称为  hello 队列.
                    channel.QueueDeclare("hello", false, false, false, null);


                    string message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);


                    // 队列中发布一条消息.
                    channel.BasicPublish("", "hello", null, body);


                    Console.WriteLine("set {0}", message);
                }
            }


            Console.WriteLine("Finish!");
            Console.ReadKey();

        }
    }
}
