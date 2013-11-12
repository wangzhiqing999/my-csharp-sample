using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NUnit.Framework;

using A0740_AutoMatch.Sample;



namespace A0740_AutoMatch.Test
{
    [TestFixture]
    public class AbstractAutoMatchProcesserTest
    {

        
        /// <summary>
        /// 分摊测试.
        /// 
        /// 测试 兑换礼品列表为 null 的情况.
        /// </summary>
        [Test]
        public void DoAutoMatchProcessNullDataTest()
        {
            // 可兑换礼品列表.
            List<IAutoMatchAble> baseDataList = null;

            // 构造处理类.
            IAutoMatchProcesser autoMatchProcesser = new BiggerFirstAutoMatchProcesser()
            {
                BaseDataList = baseDataList,
            };

            // 处理结果变量定义.
            List<AutoMatchResult> actual = null;

            // 执行自动分摊计算， 积分 1500.  (预期结果：  空白列表 )
            actual = autoMatchProcesser.DoAutoMatchProcess(1500);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表只有 0行.
            Assert.AreEqual(0, actual.Count);
        }


        /// 
        /// 测试 兑换礼品列表为 空白列表 的情况.
        /// </summary>
        [Test]
        public void DoAutoMatchProcessEmptyDataTest()
        {
            // 可兑换礼品列表.
            List<IAutoMatchAble> baseDataList = new List<IAutoMatchAble>();

            // 构造处理类.
            IAutoMatchProcesser autoMatchProcesser = new BiggerFirstAutoMatchProcesser()
            {
                BaseDataList = baseDataList,
            };

            // 处理结果变量定义.
            List<AutoMatchResult> actual = null;

            // 执行自动分摊计算， 积分 1500.  (预期结果：  空白列表 )
            actual = autoMatchProcesser.DoAutoMatchProcess(1500);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表只有 0行.
            Assert.AreEqual(0, actual.Count);
        }



        /// 
        /// 测试 兑换礼品列表为 仅仅有一行数据 的情况.
        /// </summary>
        [Test]
        public void DoAutoMatchProcessOnlyOneDataTest()
        {
            // 可兑换礼品列表.
            List<IAutoMatchAble> baseDataList = new List<IAutoMatchAble>()
            {
                new AutoMatchAbleTest("C", 500),
            };

            // 构造处理类.
            IAutoMatchProcesser autoMatchProcesser = new BiggerFirstAutoMatchProcesser()
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



            // 执行自动分摊计算， 积分 1200.  (预期结果：  2C )
            actual = autoMatchProcesser.DoAutoMatchProcess(1200);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 2
            Assert.AreEqual(2, actual[0].Count);
            // 剩余积分数量为 200
            Assert.AreEqual(200, autoMatchProcesser.RemainderValue);



            // 执行自动分摊计算， 积分 700.  (预期结果：  1C )
            actual = autoMatchProcesser.DoAutoMatchProcess(700);
            // 结果非空.
            Assert.IsNotNull(actual);
            // 结果列表有 1行.
            Assert.AreEqual(1, actual.Count);
            // 商品代码为 C
            Assert.AreEqual("C", actual[0].ID);
            // 商品数量为 1
            Assert.AreEqual(1, actual[0].Count);
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
