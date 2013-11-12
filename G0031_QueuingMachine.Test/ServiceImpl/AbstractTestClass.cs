using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;




using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.ServiceImpl
{


    public class AbstractTestClass
    {
        /// <summary>
        /// 测试用的消息.
        /// </summary>
        protected QueuingMachineMessage message;




        [Test]
        public void SendRecvTest()
        {

            if (message == null)
            {
                // 当没有消息的情况下，不处理。
                return;
            }



            // 消息发送.
            MemoryMessageSender sender = new MemoryMessageSender();




            // 发送消息.
            sender.SendMessage(message);
            // 取得字节数组.
            byte[] data = sender.MessageData;
            // 字节数组应该非空.
            Assert.IsNotNull(data);
            // 字节数组长度大于0.
            Assert.IsTrue(data.Length > 0);





            // 消息接收.
            MemoryMessageReceiver receiver = new MemoryMessageReceiver();
            // 接收消息.
            receiver.MessageData = data;
            QueuingMachineMessage resultMessage = receiver.ReceiveMessage();
            // 结果消息非空.
            Assert.IsNotNull(resultMessage);
            // 发送的消息，  与接收的消息， 应该一致.
            Assert.AreEqual(message, resultMessage);
        }


    }



}
