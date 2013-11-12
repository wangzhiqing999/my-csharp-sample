using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;



namespace A0340_ThreadReadWrite
{

    class Program
    {

        /// <summary>
        /// 生产 / 消费 的数据队列.
        /// </summary>
        static Queue<int> data = new Queue<int>();


        /// <summary>
        /// 用于 锁定 生产 / 消费 的数据队列 的对象.
        /// </summary>
        static object locker = new object();


        /// <summary>
        /// 处理结束标志.
        /// 消费线程 不能通过 队列是否为空， 来判断程序结束
        /// 只能通过标志位来判断.
        /// </summary>
        static bool finishResult = false;


        /// <summary>
        /// 测试的数量.
        /// </summary>
        const int TEST_COUNT = 5;


        /// <summary>
        /// 写入线程需要的时间.
        /// (用于测试 生产 / 消费 的快慢情况)
        /// </summary>
        const int WRITE_NEED_SECOND = 1;


        /// <summary>
        /// 读取线程需要的时间.
        /// (用于测试 生产 / 消费 的快慢情况)
        /// 这里为模拟：  生产时间1秒1个， 消费时间3秒1个.
        /// </summary>
        const int READ_NEED_SECOND = 3;



        /// <summary>
        /// 消费的方法.
        /// 可以假象为是 从队列中获取数据， 写入到文件中.
        /// </summary>
        private static void ReadData()
        {
            Console.WriteLine("##{0} 读取开始！", Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                // 需要确保 lock 代码段里面的代码
                // 尽可能仅仅用于 队列数据的判断与获取
                // 获取数据以后的业务处理逻辑，放到 lock 代码段以外.
                lock (locker)
                {
                    if (data.Count == 0)
                    {
                        // 如果 队列为空.
                        if (finishResult)
                        {
                            // 如果执行结束了.
                            // 退出循环.
                            break;
                        }
                        Console.WriteLine("##RR{0} 无法读取数据，等待！",
                            Thread.CurrentThread.ManagedThreadId);

                        // 等待通知.
                        Monitor.Wait(locker);
                    }

                    Console.WriteLine("##RR{0} 读取结果: {1}",
                        Thread.CurrentThread.ManagedThreadId, data.Dequeue());
                }

                // 请注意避免把 长时间的 写入操作 的代码，放在 lock 段里面.
                // 用于模拟一个 长时间的 写入操作.
                Thread.Sleep(1000 * READ_NEED_SECOND);

            }

            Console.WriteLine("##{0} 读取结束！", Thread.CurrentThread.ManagedThreadId);
        }




        /// <summary>
        /// 生产的方法.
        /// 可以假象为是 从数据库中检索数据， 存储到队列中.
        /// </summary>
        private static void WriteData()
        {
            Console.WriteLine("##{0} 写入开始！", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < TEST_COUNT; i++)
            {

                // 请注意避免把 长时间的 写入操作 的代码，放在 lock 段里面.
                // 线程休眠.
                // 用于模拟一个 长时间的 读取操作.
                Thread.Sleep(1000 * WRITE_NEED_SECOND);


                // 需要确保 lock 代码段里面的代码
                // 尽可能仅仅用于 队列数据的判断与获取
                // 获取数据以后的业务处理逻辑，放到 lock 代码段以外.
                lock (locker)
                {
                    int s = DateTime.Now.Second;
                    Console.WriteLine("##WW{0} 设置数据: {1}",
                        Thread.CurrentThread.ManagedThreadId, s);
                    data.Enqueue(s);
                    // 通知 其他等待的线程
                    Monitor.Pulse(locker);
                }
            }

            // 处理完毕后， 设置结束标志.
            finishResult = true;

            Console.WriteLine("##{0} 写入完成！", Thread.CurrentThread.ManagedThreadId);
        }




        static void Main(string[] args)
        {
            // 生产线程.
            Thread writer = new Thread(WriteData);
            writer.Start();


            // 消费线程.
            Thread reader = new Thread(ReadData);
            reader.Start();


            Console.ReadLine();
        }



    }
}
