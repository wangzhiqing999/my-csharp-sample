using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;



namespace R0004_Consuming
{


    /// <summary>
    /// 用于测试 RabbitMQ 的消费者程序.
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


                    // 公平分发
                    // 告诉RabbitMQ 不要在同一时间给一个工作者发送多于1个的消息
                    // 或者换句话说，在一个工作者还在处理消息，并且没有响应消息之前，不要给他分发新的消息。
                    channel.BasicQos(0, 1, false);


                    // 消息响应默认是开启的。
                    // 下面的第2个参数， 设置为 false.
                    // 意味着， 如果一个工作者（worker）挂掉了，我们希望该消息会重新发送给其他的工作者（worker）。
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume("task_queue", false, consumer);
 

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
            Console.WriteLine("Received： {0}", message);


            // 休眠5秒。 模拟一个长时间操作.
            System.Threading.Thread.Sleep(5000);


            // 注意： 自动消息响应关闭的情况下， 下面这句话， 必须要加上， 否则会导致消息被多个客户端重复处理.
            ((EventingBasicConsumer)sender).Model.BasicAck(e.DeliveryTag, false);

            Console.WriteLine("Done");
        }



    }
}
