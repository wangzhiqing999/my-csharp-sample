using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.ServiceImpl
{


    /// <summary>
    /// 消息处理器 测试.
    /// </summary>
    [TestFixture]
    public class DefaultMessageProcessTest
    {

        /// <summary>
        /// 消息管理实例.
        /// </summary>
        private DefaultMessageProcess processer = DefaultMessageProcess.GetInstance();


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // 加入3组号码.
            processer.AddNewIWorkNumberManager(new DefaultWorkNumberManager("A", 6));
            processer.AddNewIWorkNumberManager(new DefaultWorkNumberManager("B", 6));
            processer.AddNewIWorkNumberManager(new DefaultWorkNumberManager("C", 6));
        }



        [Test]
        public void MessageProcessTest()
        {

            // 请求5个号码.
            for (uint i = 0; i < 5; i++)
            {

                QueuingMachineMessage message = new QueuingMachineMessage()
                {
                    Header = new MessageHeader()
                    {
                        CommandID = MessageHeader.QM_NewWorkNumber_Req,
                        SequenceNo = i,
                    },
                    Body = new NewWorkNumberRequest()
                    {
                        ServiceCode = "A",
                    },
                };


                // 处理消息.
                QueuingMachineMessage resultMessage = processer.DoMessageProcess(message);

                // 结果消息非空.
                Assert.IsNotNull(resultMessage);

                // 核对消息头.
                // 核对 消息反馈类型.
                Assert.AreEqual(MessageHeader.QM_NewWorkNumber_Resp, resultMessage.Header.CommandID);
                // 核对 流水号.
                Assert.AreEqual(i, resultMessage.Header.SequenceNo);


                // 核对消息体.
                Assert.IsInstanceOf<NewWorkNumberRespond>(resultMessage.Body);

                NewWorkNumberRespond body = resultMessage.Body as NewWorkNumberRespond;
                // 叫号代码.
                Assert.AreEqual("A0000" + (i + 1), body.ResultWorkNumber);
                // 队列首代码.
                Assert.AreEqual("A00001", body.TopWorkNumber);
                // 队列长度.
                Assert.AreEqual(i + 1, body.QueueLength);

            }


             // 消费5个号码.
            for (uint i = 0; i < 5; i++)
            {
                QueuingMachineMessage message = new QueuingMachineMessage()
                {
                    Header = new MessageHeader()
                    {
                        CommandID = MessageHeader.QM_AskWorkNumber_Req ,
                        SequenceNo = i,
                    },
                    Body = new AskWorkNumberRequest()
                    {
                        ServiceCode = "A",                         
                    },
                };

                // 处理消息.
                QueuingMachineMessage resultMessage = processer.DoMessageProcess(message);

                // 结果消息非空.
                Assert.IsNotNull(resultMessage);

                // 核对消息头.
                // 核对 消息反馈类型.
                Assert.AreEqual(MessageHeader.QM_AskWorkNumber_Resp, resultMessage.Header.CommandID);
                // 核对 流水号.
                Assert.AreEqual(i, resultMessage.Header.SequenceNo);


                // 核对消息体.
                Assert.IsInstanceOf<AskWorkNumberRespond>(resultMessage.Body);
                AskWorkNumberRespond body = resultMessage.Body as AskWorkNumberRespond;
                // 叫号代码.
                Assert.AreEqual("A0000" + (i + 1), body.ResultWorkNumber);
            }


        }


    }
}
