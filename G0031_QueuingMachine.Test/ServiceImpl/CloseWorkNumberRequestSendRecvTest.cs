using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.ServiceImpl
{


    /// <summary>
    /// 完成服务处理请求消息 发功接收测试.
    /// </summary>
    [TestFixture]
    public class CloseWorkNumberRequestSendRecvTest : AbstractTestClass
    {

        /*
        TestFixtureSetup：在当前测试类中的所有测试函数运行前调用；
        TestFixtureTearDown：在当前测试类的所有测试函数运行完毕后调用；

        例如测试项目是要访问数据库/文件/网络端口的
        那么可以在 TestFixtureSetup 那里打开数据库/文件/网络端口
        并在 TestFixtureTearDown 那里关闭数据库/文件/网络端口
        */
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            message = new QueuingMachineMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_CloseWorkNumber_Req,
                    SequenceNo = 1,
                },
                Body = new CloseWorkNumberRequest ()
                {
                    ServiceCode = "A001",
                    WorkNumber = "00100",
                },
            };
        }



    }
}
