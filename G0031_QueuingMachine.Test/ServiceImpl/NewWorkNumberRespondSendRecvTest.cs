using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using G0031_QueuingMachine.Message;


namespace G0031_QueuingMachine.ServiceImpl
{

    public class NewWorkNumberRespondSendRecvTest : AbstractTestClass
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            message = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_NewWorkNumber_Resp,
                    SequenceNo = 1,
                },
                Body = new NewWorkNumberRespond()
                {
                    ResultWorkNumber = "A0009",
                    TopWorkNumber = "A0005",
                    QueueLength = 4,
                },
            };
        }
    }
}
