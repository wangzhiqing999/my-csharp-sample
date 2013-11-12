using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;



namespace G0031_QueuingMachine.ServiceImpl
{

    /// <summary>
    /// 队列的测试.
    /// </summary>
    [TestFixture]
    public class DefaultQueueManagerTest
    {

        [Test]
        public void QueueTest()
        {
            // 队列管理.
            DefaultQueueManager queueManager = new DefaultQueueManager();

            // 加入3组号码.
            queueManager.AddNewIWorkNumberManager(new DefaultWorkNumberManager("A", 6));
            queueManager.AddNewIWorkNumberManager(new DefaultWorkNumberManager("B", 6));
            queueManager.AddNewIWorkNumberManager(new DefaultWorkNumberManager("C", 6));


            // 请求5个号码.
            for (int i = 0; i < 5; i++)
            {
                // 请求号码.
                string code = queueManager.GetNewWorkNumber("A");
                // 非空.
                Assert.IsNotNull(code);
                // 数据.
                Assert.AreEqual("A0000" + (i + 1), code);


                code = queueManager.GetNewWorkNumber("B");
                // 非空.
                Assert.IsNotNull(code);
                // 数据.
                Assert.AreEqual("B0000" + (i + 1), code);


                code = queueManager.GetNewWorkNumber("C");
                // 非空.
                Assert.IsNotNull(code);
                // 数据.
                Assert.AreEqual("C0000" + (i + 1), code);
            }


            // 提取五个号码.
            for (int i = 0; i < 5; i++)
            {
                // 提取号码.
                string code = queueManager.GetAskWorkNumber("A");
                // 非空.
                Assert.IsNotNull(code);
                // 数据.
                Assert.AreEqual("A0000" + (i + 1), code);
            }

            // 提取五个号码.
            for (int i = 0; i < 5; i++)
            {
                // 提取号码.
                string code = queueManager.GetAskWorkNumber("B");
                // 非空.
                Assert.IsNotNull(code);
                // 数据.
                Assert.AreEqual("B0000" + (i + 1), code);

                // 提取号码.
                code = queueManager.GetAskWorkNumber("C");
                // 非空.
                Assert.IsNotNull(code);
                // 数据.
                Assert.AreEqual("C0000" + (i + 1), code);
            }



        }

    }


}
