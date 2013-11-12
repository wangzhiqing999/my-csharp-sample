using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using System.Runtime.CompilerServices;


namespace A0650_EF_SqlServer.Sample
{
    
    /// <summary>
    /// 并发测试.
    /// </summary>
    public class TestConcurrency
    {

        /// <summary>
        /// 测试.
        /// 
        /// 经过测试，如果多线程打开多个  Context
        /// 如果 Context 不 SaveChanges();
        /// 
        /// 那么本 Context 对数据的修改， 不会影响到其他的 Context。
        /// 
        /// 因此，对于某些更新多个表的操作， 只好加上线程同步的处理。
        /// 处理起来比较简单， 但是以牺牲性能作为代价。
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        static void DoTestConcurrency()
        {
            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine("Start!");
                // 取得 数据库的序列号数据.
                test_sequence sequence = context.test_sequence.FirstOrDefault(p => p.table_name == "test_main");
                // 获取序列号.
                int newSeq = sequence.sequence_number;
                // 更新序列号表.
                sequence.sequence_number++;
                Console.WriteLine("sequence = " + newSeq);

                // 模拟一个长时间操作.
                Thread.Sleep(1000);


                // 插入数据.
                test_main testData = new test_main()
                {
                    id = newSeq,
                    value = "Main" + newSeq
                };
                context.test_main.AddObject(testData);
                // 提交保存.
                context.SaveChanges();
                Console.WriteLine("Finish!");
            }
        }




        /// <summary>
        /// 测试并发.
        /// </summary>
        public static void DoTest()
        {
            for (int i = 0; i < 3; i++)
            {
                ThreadStart tsa = new ThreadStart(DoTestConcurrency);
                Thread ta = new Thread(tsa);
                ta.Start();
            }
        }



    }



}
