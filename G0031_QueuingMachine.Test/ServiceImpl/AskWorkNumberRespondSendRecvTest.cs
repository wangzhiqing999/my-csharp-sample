using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


using G0031_QueuingMachine.Message;




namespace G0031_QueuingMachine.ServiceImpl
{


    /// <summary>
    /// 叫号反馈消息  发功接收测试.
    /// </summary>
    [TestFixture]
    public class AskWorkNumberRespondSendRecvTest : AbstractTestClass
    {
   


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            message = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_AskWorkNumber_Resp,
                    SequenceNo = 1,
                },
                Body = new AskWorkNumberRespond()
                {
                    ResultStatus = 1,
                    ResultWorkNumber = "00100",
                },
            };
        }




    }


}
