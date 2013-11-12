using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A0720_MultiTime.Sample;



namespace A0720_MultiTime.Test
{

    [TestFixture]
    public class MultiTimeTestWithoutDate
    {

        /// <summary>
        /// 被测试的目标服务.
        /// </summary>
        private MultiTimeDataProcess<TestData> processer;



        /// <summary>
        /// 简单测试 有2次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestSimple2()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                 AccessAbleCount = 2,                 
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }
        }



        /// <summary>
        /// 简单测试 有3次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestSimple3()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 3,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 不满足 “至少3次”，  因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 不满足 “至少3次”， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第三行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today, });

            // 由于是第三次加入， 满足 “至少3次”的条件，因此结果列表数据中 3行数据都被加入.
            Assert.AreEqual(3, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(3 + i + 1, processer.ResultList.Count);
            }
        }





        /// <summary>
        /// 测试多个 关键字 有2次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestMul2()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 不满足 “至少2次”，  因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V02", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 加入了 2 行， 2个不同的 Vip，  不满足 “至少2次”，(因为目前每个 vip 各1次) 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第三行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today, });

            // 由于本次加入的数据， 使 V01 满足 “至少2次”的条件，因此结果列表数据中 V01 的 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }
        }




        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  避免重复 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove2()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(12 - i - 1, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 只剩下一个了.
            Assert.AreEqual(1, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 全部删除干净了.
            Assert.AreEqual(0, processer.ResultList.Count);
        }


        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  取消数据 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove2WithAutoReset()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                IsNeedAutoReset = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(12 - i - 1, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 2个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再加入数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 本次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 2个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);
        }




        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  避免重复 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove3()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 3,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });



            // 加入第三行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today, });
            // 由于是第三次加入， 因此结果列表中数据为 1.
            // 因为不数据重置， 前面加2次， 减少2次。 
            // 相当于是 前面加了2次，后面发现前2次 已被加过了，为了重复计算， 从列表中清除了， 但是还是 需要  “算次数”的。
            // 因此这一次加入以后， 由于 进入次数等于 3次。 因此认为数据可以加入列表.
            Assert.AreEqual(1, processer.ResultList.Count);


            // 加入第四行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S04", SalesAmt = 140, SalesDate = DateTime.Today, });
            Assert.AreEqual(2, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(12 - i - 1, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today, });
            // 只剩下1个了.
            Assert.AreEqual(1, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S04", SalesAmt = 140, SalesDate = DateTime.Today, });
            // 全部删除干净了.
            Assert.AreEqual(0, processer.ResultList.Count);
        }



        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  取消数据 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove3WithAutoReset()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 3,
                IsNeedAutoReset = true,
            };



            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 不满足 “至少3次”的条件，因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });



            // 加入第三行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today, });
            // 由于是第三次加入， 因此结果列表中数据为 0.
            // 因为数据重置， 前面加2次， 减少2次。 
            // 相当于是 前面加了2次，后面发现前2次 已被退货了， 需要  取消掉前面的数据。
            // 因此这一次加入以后， 进入次数等于 3次。 但是实际有效数据只有1次。
            Assert.AreEqual(0, processer.ResultList.Count);


            // 加入第四行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S04", SalesAmt = 140, SalesDate = DateTime.Today, });
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第五行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S05", SalesAmt = 150, SalesDate = DateTime.Today, });
            Assert.AreEqual(3, processer.ResultList.Count);





            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(3 + i + 1, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(13 - i - 1, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S05", SalesAmt = 150, SalesDate = DateTime.Today, });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 3个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再加入数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S06", SalesAmt = 160, SalesDate = DateTime.Today, });
            // 本次加入， 满足 “至少3次”的条件，因此结果列表数据中 3行数据都被加入.
            Assert.AreEqual(3, processer.ResultList.Count);

            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S04", SalesAmt = 140, SalesDate = DateTime.Today, });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 3个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);
        }









        /// <summary>
        /// 错误数据测试.
        /// 
        /// 测试插入数据后，  尝试删除不存在的数据.
        /// </summary>
        [Test]
        public void DoTestRemoveNotExistsData2()
        {

            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(12, processer.ResultList.Count);


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(12 - i - 1, processer.ResultList.Count);
            }

            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(2, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 只剩下一个了.
            Assert.AreEqual(1, processer.ResultList.Count);


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(1, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 全部删除干净了.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(0, processer.ResultList.Count);
        }




        /// <summary>
        /// 错误数据测试.
        /// 
        /// 测试插入数据后，  尝试删除不存在的数据.
        /// </summary>
        [Test]
        public void DoTestRemoveNotExistsData2WithAutoReset()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                IsNeedAutoReset = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(12, processer.ResultList.Count);


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                Assert.AreEqual(12 - i - 1, processer.ResultList.Count);
            }


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(2, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 2个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再加入数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 本次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(2, processer.ResultList.Count);

            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 2个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 尝试删除不存在的数据. 检查会不会出异常.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "X00", SalesAmt = 120, SalesDate = DateTime.Today, });
            Assert.AreEqual(0, processer.ResultList.Count);
        }

    }


}
