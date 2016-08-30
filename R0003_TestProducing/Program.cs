using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RabbitMQ.Client;


namespace R0003_TestProducing
{


    /// <summary>
    /// 用于测试 RabbitMQ 的 生产者程序.
    /// 
    /// 持久化 / 消息响应 / 公平分发 版本.
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

                    // 名称为  task_queue 队列.  
                    // 消息持久化标志.
                    bool durable = true;
                    channel.QueueDeclare("task_queue", durable, false, false, null);


                    // 需要保证消息也是持久化的
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;


                    for (int i = 0; i < 10; i++)
                    {
                        string message = String.Format("测试消息.{0}", i);

                        var body = Encoding.UTF8.GetBytes(message);

                        // 队列中发布一条消息.
                        channel.BasicPublish("", "task_queue", properties, body);

                        Console.WriteLine("set {0}", message);
                    }

                }
            }


            Console.WriteLine("Finish!");
            Console.ReadKey();

        }

    }
}
