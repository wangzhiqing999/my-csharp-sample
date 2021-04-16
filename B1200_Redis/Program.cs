using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using B1200_Redis.Sample;

namespace B1200_Redis
{
    class Program
    {
        static void Main(string[] args)
        {


            // 普通字符串.
            DoStringTest();

            // C# 对象 序列化为 字符串.
            DoObjectTest();

            // 哈希.
            DoHashTest();

            // 队列
            DoQueueTest();

            // 堆栈.
            DoStackTest();

            // 集合.
            DoSetTest();

            // 有序集合.
            DoSortedSetTest();





            // 限制高频访问.
            ParameterizedThreadStart ts1 = new ParameterizedThreadStart(DoLimitTest);
            ParameterizedThreadStart ts2 = new ParameterizedThreadStart(DoLimitTest);
            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(ts2);
            t1.Start("ZhangSan");
            t2.Start("LiSi");







            Console.WriteLine("Finish");
            Console.ReadLine();
        }



        private static void DoStringTest()
        {
            Console.WriteLine("---------- DoStringTest ----------");

            StringTest stringTest = new StringTest();
            string writeResult = stringTest.SaveStringToRedis("StringTest", "测试存储字符串信息！");
            Console.WriteLine($"测试写入字符串，结果：{writeResult}");

            string readResult = stringTest.LoadStringFromRedis("StringTest");
            Console.WriteLine($"测试读取字符串，结果：{readResult}");

            Console.WriteLine();

            // 测试完成后，服务器上，redis-cli 的查询结果：
            /*

            127.0.0.1:6379[1] > dump StringTest
            "\x00 \"\xe6\xb5\x8b\xe8\xaf\x95\xe5\xad\x98\xe5\x82\xa8\xe5\xad\x97\xe7\xac\xa6\xe4\xb8\xb2\xe4\xbf\xa1\xe6\x81\xaf\xef\xbc\x81\"\t\x0001\xed?\xf5)s\xa1"

            127.0.0.1:6379[1] > type StringTest
            string

            */

        }


        private static void DoObjectTest()
        {
            Console.WriteLine("---------- DoObjectTest ----------");

            ObjectTest objectTest = new ObjectTest();
            TestObj testObj = new TestObj()
            {
                Code = 1003,
                Name = "张三",
                LastUpdateTime = DateTime.Now
            };

            string writeResult = objectTest.SaveTestObjToRedis("ObjectTest", testObj);
            Console.WriteLine($"测试写入对象数据，结果：{writeResult}");

            TestObj testObj2 = objectTest.LoadTestObjFromRedis("ObjectTest");
            Console.WriteLine($"测试读取对象数据，结果：{testObj2}");

            Console.WriteLine();


            // 测试完成后，服务器上，redis-cli 的查询结果：
            /*

            127.0.0.1:6379[1] > dump ObjectTest
            "\x00@M{\"Code\":1003,\"Name\":\"\xe5\xbc\xa0\xe4\xb8\x89\",\"LastUpdateTime\":\"\\/Date(1618545148420+0800)\\/\"}\t\x00\xa4\xa2\x0eJ*Z\xbd\x1e"

            127.0.0.1:6379[1] > type ObjectTest
            string

            */
        }






        private static void DoHashTest()
        {
            Console.WriteLine("---------- DoHashTest ----------");

            HashTest hashTest = new HashTest();

            Dictionary<string, string> hashInfo = new Dictionary<string, string>();
            hashInfo.Add("Host", "192.168.1.39");
            hashInfo.Add("Port", "6379");
            hashInfo.Add("Db", "1");


            string writeResult = hashTest.SaveHashToRedis("HashTest", hashInfo);
            Console.WriteLine($"测试写入哈希数据，结果：{writeResult}");

            Dictionary<string, string> hashInfo2 = hashTest.LoadHashFromRedis("HashTest");
            Console.WriteLine($"测试读取哈希数据，结果：{hashInfo2}");

            if (hashInfo2 != null)
            {
                foreach (var key in hashInfo2.Keys)
                {
                    Console.WriteLine($"{key} = {hashInfo2[key]}");
                }
            }

            Console.WriteLine();


            // 测试完成后，服务器上，redis-cli 的查询结果：
            /*
             * 
            127.0.0.1:6379[1]> dump HashTest
            "\r//\x00\x00\x00,\x00\x00\x00\x06\x00\x00\x04Host\x06\x0c192.168.1.39\x0e\x04Port\x06\xc0\xeb\x18\x04\x02Db\x04\xf2\xff\t\x00O\xf4A#\xef\x92\xf9\xe2"

            127.0.0.1:6379[1]> type HashTest
            hash

             */
        }






        private static void DoQueueTest()
        {
            Console.WriteLine("---------- DoQueueTest ----------");

            ListTest listTest = new ListTest();

            listTest.TestEnqueueItemOnList();

            Console.WriteLine("### 入队列完成，前往 redis-cli 查询 ###");
            Console.WriteLine("按【回车】执行出队列！");
            Console.ReadLine();

            // 执行到这里时.
            /*
             
             127.0.0.1:6379[1]> dump QueueList
            "\x0e\x01\xc3=@f\x04f\x00\x00\x00\\ \x03\r\n\x00\x00\bQueue_10\n\a\x80\t\x019\t\xa0\b\x008\xc0\b\x007\xc0\b\x006\xc0\b\x005\xc0\b\x004\xc0\b\x003\xc0\b\x002\xc0\b\x011\xff\t\x00\x8c%\x13\x91\x18\x1f\x93\x9d"

            127.0.0.1:6379[1]> type QueueList
            list
             */




            listTest.TestDequeueItemFromList();
            Console.WriteLine("### 出队列完成，前往 redis-cli 查询 ###");
            Console.WriteLine("按【回车】结束！");
            Console.ReadLine();

            // 执行到这里时.
            /*
             127.0.0.1:6379[1]> dump QueueList
            (nil)

            127.0.0.1:6379[1]> type QueueList
            none
             */

        }



        private static void DoStackTest()
        {
            Console.WriteLine("---------- DoStackTest ----------");

            ListTest listTest = new ListTest();

            listTest.TestPushItemToList();

            Console.WriteLine("### 入堆栈完成，前往 redis-cli 查询 ###");
            Console.WriteLine("按【回车】执行出堆栈！");
            Console.ReadLine();

            // 执行到这里时.
            /*
            127.0.0.1:6379[1]> dump StackList
            "\x0e\x01\xc3<@f\x04f\x00\x00\x00[ \x03\x0b\n\x00\x00\aStack_1\t\xa0\b\x002\xc0\b\x003\xc0\b\x004\xc0\b\x005\xc0\b\x006\xc0\b\x007\xc0\b\x008\xc0\b\x029\t\b\xa0P\x010\xff\t\x00\x9a2\xb4\x80U\xf6\xed\x90"

            127.0.0.1:6379[1]> type StackList
            list
            */


            listTest.TestPopItemFromList();
            Console.WriteLine("### 出堆栈完成，前往 redis-cli 查询 ###");
            Console.WriteLine("按【回车】结束！");
            Console.ReadLine();

            // 执行到这里时.
            /*
             127.0.0.1:6379[1]> dump StackList
            (nil)

            127.0.0.1:6379[1]> type StackList
            none
             */
        }







        private static void DoSetTest()
        {
            Console.WriteLine("---------- DoSetTest ----------");

            SetTest setTest = new SetTest();

            setTest.TestAddItemToSet();

            Console.WriteLine();


            // 测试完成后，服务器上，redis-cli 的查询结果：
            /*

            127.0.0.1:6379[1]> Dump SetTest
            "\x02\x05\x03003\x03002\x03004\x03001\x03005\t\x00\xe6r_`:{K\xc1"

            127.0.0.1:6379[1]> type SetTest
            set


             */
        }




        private static void DoSortedSetTest()
        {
            Console.WriteLine("---------- DoSortedSetTest ----------");

            SortedSetTest setTest = new SortedSetTest();

            setTest.TestAddItemToSortedSetWithoutScore();

            Console.WriteLine();


            // 测试完成后，服务器上，redis-cli 的查询结果：
            /*

            127.0.0.1:6379[1]> dump SortedSetTest
            "\x0c\xc3:@B\x04B\x00\x00\x00; \x03\r\n\x00\x00\x03001\x05\xd0\x00100\x06 \n\x002 \n\x002\x80\n\x003 \n\x003\x80\n\x004 \n\x004\x80\n\x005 \n\x03500\xff\t\x00\xa2\x84\xd2\xad,\xf5\xcd\xb2"

            127.0.0.1:6379[1]> type SortedSetTest
            zset


             */


            setTest.TestAddItemToSortedSetWithScore();

            Console.WriteLine();
        }




        private static void DoLimitTest(object userCode)
        {
            Console.WriteLine("---------- DoLimitTest ----------");
            LimitTest limitTest = new LimitTest();
            for (int i = 0; i < 20; i++)
            {
                bool res = limitTest.IsActionAllowed(userCode.ToString(), "Talk", 3, 10);
                if (res)
                {
                    Console.WriteLine($"{userCode}正常发言:" + i);
                }
                else
                {
                    Console.WriteLine($"{userCode}被限制，不允许高频发言:" + i);
                }
            }
            // 休眠 4s
            Thread.Sleep(4000);
            // 超过最大执行时间之后，再从发起请求
            bool res2 = limitTest.IsActionAllowed(userCode.ToString(), "Talk", 3, 10);
            if (res2)
            {
                Console.WriteLine($"休眠后，{userCode}正常执行请求");
            }
            else
            {
                Console.WriteLine($"休眠后，{userCode}被限流");
            }
        }





    }

}