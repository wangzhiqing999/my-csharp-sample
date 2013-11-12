using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using A0740_AutoMatch.Sample;


namespace A0740_AutoMatch.Test
{

    [TestFixture]
    public class MinRemainderAutoMatchProcesserTest
    {


        /// <summary>
        /// 分摊测试.
        /// </summary>
        [Test]
        public void DoAutoMatchProcessTest()
        {
            // 可兑换礼品列表.
            List<IAutoMatchAble> baseDataList = new List<IAutoMatchAble>()
            {
                new AutoMatchAbleTest("A", 300),
                new AutoMatchAbleTest("C", 500),
                new AutoMatchAbleTest("B", 400),
            };


            // 构造处理类.
            IAutoMatchProcesser autoMatchProcesser = new MinRemainderAutoMatchProcesser()
            {
                BaseDataList = baseDataList,
            };

            // 处理结果变量定义.
            List<AutoMatchResult> actual = null;



            // 执行自动分摊计算， 积分 1500.  (预期结果：  3C )
            actual = autoMatchProcesser.DoAutoMatchProcess(1500);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表只有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 3
            Assert.AreEqual(3, actual[0].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 1400.  (预期结果：  2C 1B )
            actual = autoMatchProcesser.DoAutoMatchProcess(1400);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 2行.
            Assert.AreEqual(2, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 商品代码为 B
            Assert.AreEqual("B", actual[1].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[1].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 1300.  (预期结果：  2C 1A )
            actual = autoMatchProcesser.DoAutoMatchProcess(1300);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 2行.
            Assert.AreEqual(2, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[1].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[1].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);




            // 执行自动分摊计算， 积分 1200.  (预期结果：  1C1B1A )
            actual = autoMatchProcesser.DoAutoMatchProcess(1200);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 3行.
            Assert.AreEqual(3, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 商品代码为 B
            Assert.AreEqual("B", actual[1].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[1].Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[2].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[2].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);






            // 执行自动分摊计算， 积分 1100.  (预期结果：  1C2A )
            actual = autoMatchProcesser.DoAutoMatchProcess(1100);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 2行.
            Assert.AreEqual(2, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[1].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[1].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 1000.  (预期结果：  2C )
            actual = autoMatchProcesser.DoAutoMatchProcess(1000);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 900.  (预期结果：  1C 1B )
            actual = autoMatchProcesser.DoAutoMatchProcess(900);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 2行.
            Assert.AreEqual(2, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 商品代码为 B
            Assert.AreEqual("B", actual[1].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[1].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 800.  (预期结果：  1C 1A )
            actual = autoMatchProcesser.DoAutoMatchProcess(800);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 2行.
            Assert.AreEqual(2, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[1].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[1].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 700.  (预期结果：  1B1A )
            actual = autoMatchProcesser.DoAutoMatchProcess(700);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 2行.
            Assert.AreEqual(2, actual.Count);
            // 商品代码为 B
            Assert.AreEqual("B", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[1].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[1].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);




            // 执行自动分摊计算， 积分 600.  (预期结果：  2A )
            actual = autoMatchProcesser.DoAutoMatchProcess(600);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 500.  (预期结果：  1C )
            actual = autoMatchProcesser.DoAutoMatchProcess(500);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 400.  (预期结果：  1B )
            actual = autoMatchProcesser.DoAutoMatchProcess(400);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 B
            Assert.AreEqual("B", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 300.  (预期结果：  1A )
            actual = autoMatchProcesser.DoAutoMatchProcess(300);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 剩余积分数量为 0
            Assert.AreEqual(0, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 200.  (预期结果：  空白列表 )
            actual = autoMatchProcesser.DoAutoMatchProcess(200);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 0行.
            Assert.AreEqual(0, actual.Count);
            // 剩余积分数量为 200
            Assert.AreEqual(200, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 100.  (预期结果：  空白列表 )
            actual = autoMatchProcesser.DoAutoMatchProcess(100);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 0行.
            Assert.AreEqual(0, actual.Count);
            // 剩余积分数量为 100
            Assert.AreEqual(100, autoMatchProcesser.RemainderValue);

        }



    }


}
