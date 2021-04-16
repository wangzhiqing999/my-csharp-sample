using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{
    /// <summary>
    /// 测试 List 的存储与获取.
    /// </summary>
    public class ListTest : BasicTest
    {

        /// <summary>
        /// 测试使用 EnqueueItemOnList 执行 入队列的操作.
        /// 队列的方式，先进先出。
        /// </summary>
        public void TestEnqueueItemOnList()
        {
            using (RedisClient client = GetRedisClient())
            {
                for(int i = 0; i < 10; i ++)
                {                    
                    // 入队列.
                    client.EnqueueItemOnList("QueueList", $"Queue_{i + 1}");
                    Console.WriteLine($"入队列：Queue_{i + 1}");
                }
            }
        }

        /// <summary>
        /// 测试使用 DequeueItemFromList 执行 出队列的操作.
        /// 队列的方式，先进先出。
        /// </summary>
        public void TestDequeueItemFromList()
        {
            using (RedisClient client = GetRedisClient())
            {
                long q = client.GetListCount("QueueList");

                for (int i = 0; i < q; i++)
                {
                    Console.WriteLine($"出队列：{client.DequeueItemFromList("QueueList")}");
                }
            }
        }







        /// <summary>
        /// 测试使用 PushItemToList 执行 入堆栈的操作.
        /// 堆栈的方式，先进后出。
        /// </summary>
        public void TestPushItemToList()
        {
            using (RedisClient client = GetRedisClient())
            {
                for (int i = 0; i < 10; i++)
                {
                    // 入队列.
                    client.PushItemToList("StackList", $"Stack_{i + 1}");
                    Console.WriteLine($"入堆栈：Stack_{i + 1}");
                }
            }
        }


        /// <summary>
        /// 测试使用 PopItemFromList 执行 出堆栈的操作.
        /// 堆栈的方式，先进后出。
        /// </summary>
        public void TestPopItemFromList()
        {
            using (RedisClient client = GetRedisClient())
            {
                long q = client.GetListCount("StackList");

                for (int i = 0; i < q; i++)
                {
                    Console.WriteLine($"出堆栈：{client.PopItemFromList("StackList")}");
                }
            }
        }


    }
}
