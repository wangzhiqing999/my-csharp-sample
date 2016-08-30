using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RabbitMQ.Client;
using RabbitMQ.Client.Events;



namespace R0002_Consuming
{


    /// <summary>
    /// 用于测试 RabbitMQ 的消费者程序.
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


            /*
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);

                    channel.BasicConsume("hello", true, consumer);

                    Console.WriteLine("waiting for message.");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Received {0}", message);

                    }
                }

            }
            */



            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    // 名称为  hello 队列.
                    channel.QueueDeclare("hello", false, false, false, null);


                    var consumer = new EventingBasicConsumer(channel);


                    channel.BasicConsume("hello", true, consumer);


                    Console.WriteLine("waiting for message.");


                    // 队列中有数据来的时候， 触发的事件.
                    consumer.Received += consumer_Received;


                    Console.ReadKey();
                }
            }
        }


        /// <summary>
        /// 队列中有数据来的时候， 触发的事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received {0}", message);
        }

    }
}
