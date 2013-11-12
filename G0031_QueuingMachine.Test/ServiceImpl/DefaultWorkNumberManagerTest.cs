using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;



namespace G0031_QueuingMachine.ServiceImpl
{

    /// <summary>
    /// 号码创建的测试.
    /// </summary>
    [TestFixture]
    public class DefaultWorkNumberManagerTest
    {

        [Test]
        public void GetNextWorkNumberTest()
        {
            // 创建号码类.
            DefaultWorkNumberManager workNumberManager = new DefaultWorkNumberManager("TEST", 10);

            // 获取一个号码.
            string code1 = workNumberManager.GetNextWorkNumber();
            // 号码非空.
            Assert.IsNotNull(code1);
            // 号码匹配.
            Assert.AreEqual("TEST000001", code1);


            // 连续获取5个.
            for (int i = 0; i < 5; i++)
            {
                code1 = workNumberManager.GetNextWorkNumber();
                // 号码非空.
                Assert.IsNotNull(code1);
                // 号码匹配.
                Assert.AreEqual("TEST00000" + (i+2), code1);
            }
        }

    }
}
