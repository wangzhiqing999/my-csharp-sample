using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


using A5300_UDP_P2P.Message;


namespace A5300_UDP_P2P.ServiceImpl
{

    /// <summary>
    /// 登录请求 发功接收测试.
    /// </summary>
    [TestFixture]
    public class LoginRequestSendRecvTest : AbstractTestClass
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
            message = new SystemMessage()
            {
                Header = new MessageHeader()
                {
                    CommandID = MessageHeader.QM_Login_Req,
                    SequenceNo = 1,
                },

                Body = new LoginRequest()
                {
                     UserName = "UnitTest",
                     Password = "123456"
                },
            };
        }



    }

}
