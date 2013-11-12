using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using A0740_AutoMatch.Sample;


namespace A0740_AutoMatch.Test
{

    [TestFixture]
    public class MinRemainderAutoMatchProcesserPlusTest
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


            // 执行自动分摊计算， 积分 1490.  (预期结果：  2C 1B   剩余 90 )
            actual = autoMatchProcesser.DoAutoMatchProcess(1490);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 1390.  (预期结果：  2C 1A    剩余 90  )
            actual = autoMatchProcesser.DoAutoMatchProcess(1390);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);




            // 执行自动分摊计算， 积分 1290.  (预期结果：  1C1B1A  剩余 90  )
            actual = autoMatchProcesser.DoAutoMatchProcess(1290);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);






            // 执行自动分摊计算， 积分 1190.  (预期结果：  1C2A   剩余 90 )
            actual = autoMatchProcesser.DoAutoMatchProcess(1190);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 1090.  (预期结果：  2C  剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(1090);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 990.  (预期结果：  1C 1B   剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(990);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 890.  (预期结果：  1C 1A 剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(890);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 790.  (预期结果：  1B1A 剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(790);
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
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);




            // 执行自动分摊计算， 积分 690.  (预期结果：  2A 剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(690);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 590.  (预期结果：  1C 剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(590);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 490.  (预期结果：  1B  剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(490);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 B
            Assert.AreEqual("B", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 390.  (预期结果：  1A  剩余 90)
            actual = autoMatchProcesser.DoAutoMatchProcess(390);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 A
            Assert.AreEqual("A", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
            // 剩余积分数量为 90
            Assert.AreEqual(90, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 290.  (预期结果：  空白列表    剩余 290 )
            actual = autoMatchProcesser.DoAutoMatchProcess(290);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 0行.
            Assert.AreEqual(0, actual.Count);
            // 剩余积分数量为 290
            Assert.AreEqual(290, autoMatchProcesser.RemainderValue);


            // 执行自动分摊计算， 积分 190.  (预期结果：  空白列表    剩余 190 )
            actual = autoMatchProcesser.DoAutoMatchProcess(190);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 0行.
            Assert.AreEqual(0, actual.Count);
            // 剩余积分数量为 190
            Assert.AreEqual(190, autoMatchProcesser.RemainderValue);

        }



    }


}
