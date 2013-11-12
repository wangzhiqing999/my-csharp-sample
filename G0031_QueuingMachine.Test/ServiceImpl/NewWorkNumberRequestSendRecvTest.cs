using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using G0031_QueuingMachine.Message;


namespace G0031_QueuingMachine.ServiceImpl
{

    public class NewWorkNumberRequestSendRecvTest : AbstractTestClass
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            message = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_NewWorkNumber_Req,
                    SequenceNo = 1,
                },
                Body = new NewWorkNumberRequest()
                {
                    ServiceCode = "A",
                },
            };
        }
    }
}
