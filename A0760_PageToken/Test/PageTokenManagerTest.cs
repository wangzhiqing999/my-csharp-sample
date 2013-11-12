using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using NUnit.Framework;
using A0760_PageToken.Sample;


namespace A0760_PageToken.Test
{


    [TestFixture]
    public class PageTokenManagerTest
    {


        /// <summary>
        /// 页面令牌管理.
        /// </summary>
        PageTokenManager pageTokenManager;



        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // 初始化令牌管理器.
            pageTokenManager = PageTokenManager.GetInstance();
        }



        [Test]
        public void TestPushToken()
        {

            // 加入一个令牌
            bool pushResult = pageTokenManager.PushToken("001");
            // 首次加入，肯定成功的.
            Assert.IsTrue(pushResult);


            // 重复加入，将失败.
            pushResult = pageTokenManager.PushToken("001");
            Assert.IsFalse(pushResult);


            // 加入其它的令牌，是没有问题的.
            for (int i = 2; i < 100; i++)
            {
                pushResult = pageTokenManager.PushToken(i.ToString("000"));
                Assert.IsTrue(pushResult);
            }


            // 休眠，让 令牌超时
            Thread.Sleep(1500 * PageTokenManager.Max_Token_Keep_Second);

            // 再次进入，将又变为可用的.
            for (int i = 1; i < 100; i++)
            {
                pushResult = pageTokenManager.PushToken(i.ToString("000"));
                Assert.IsTrue(pushResult);
            }

            // 再次进入，将失败！
            for (int i = 1; i < 100; i++)
            {
                pushResult = pageTokenManager.PushToken(i.ToString("000"));
                Assert.IsFalse(pushResult);
            }
        }



    }


}
