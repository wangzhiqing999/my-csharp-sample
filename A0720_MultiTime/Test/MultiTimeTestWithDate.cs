using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A0720_MultiTime.Sample;



namespace A0720_MultiTime.Test
{

    [TestFixture]
    public class MultiTimeTestWithDate
    {

        /// <summary>
        /// 被测试的目标服务.
        /// </summary>
        private MultiTimeDataProcess<TestData> processer;



        /// <summary>
        /// 简单测试 有2次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestSimple2NotInOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                // 至少2次.
                AccessAbleCount = 2,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-1), });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today.AddDays(i+1), });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }
        }


        /// <summary>
        /// 简单测试 有2次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestSimple2InOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                // 至少2次.
                AccessAbleCount = 2,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入， 但是还是在 同一天的情况， 因此， 结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                // 由于是同一天的情况， 因此， 结果列表中数据为 0.
                Assert.AreEqual(0, processer.ResultList.Count);
            }
        }






        /// <summary>
        /// 简单测试 有3次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestSimple3NotInOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 3,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-3), });
            // 由于是第一次加入， 不满足 “至少3次”，  因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today.AddDays(-2), });
            // 由于是第二次加入， 不满足 “至少3次”， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第三行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today.AddDays(-1), });

            // 由于是第三次加入， 满足 “至少3次”的条件，因此结果列表数据中 3行数据都被加入.
            Assert.AreEqual(3, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today.AddDays(i), });
                Assert.AreEqual(3 + i + 1, processer.ResultList.Count);
            }
        }




        /// <summary>
        /// 简单测试 有3次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestSimple3InOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 3,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
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

            // 由于是第三次加入，  但是还是在 同一天的情况， 因此， 结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                // 还是在 同一天的情况， 因此， 结果列表中数据为 0.
                Assert.AreEqual(0, processer.ResultList.Count);
            }
        }






        /// <summary>
        /// 测试多个 关键字 有2次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestMul2NotInOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-4), });
            // 由于是第一次加入， 不满足 “至少2次”，  因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V02", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today.AddDays(-4), });
            // 加入了 2 行， 2个不同的 Vip，  不满足 “至少2次”，(因为目前每个 vip 各1次) 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第三行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 130, SalesDate = DateTime.Today.AddDays(-2), });

            // 由于本次加入的数据， 使 V01 满足 “至少2次”的条件，因此结果列表数据中 V01 的 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today.AddDays(i), });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }
        }


        /// <summary>
        /// 测试多个 关键字 有2次 才认为有效的情况.
        /// </summary>
        [Test]
        public void DoTestMul2InOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
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

            // 由于本次加入的数据， 但是还是在 同一天的情况， 因此， 结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                //  但是还是在 同一天的情况， 因此， 结果列表中数据为 0.
                Assert.AreEqual(0, processer.ResultList.Count);
            }
        }





        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  避免重复 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove2NotInOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-2), });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today.AddDays(-1), });
            // 由于是第二次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today.AddDays(i), });
                Assert.AreEqual(2 + i + 1, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today.AddDays(i), });
                Assert.AreEqual(12 - i - 1, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-2), });
            // 只剩下一个了.
            Assert.AreEqual(1, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-1), });
            // 全部删除干净了.
            Assert.AreEqual(0, processer.ResultList.Count);
        }





        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  避免重复 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove2InOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            // 由于是第二次加入，  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                //  但是在同一天， 因此还是为 0
                Assert.AreEqual(0, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                //  同一天， 因此还是为 0
                Assert.AreEqual(0, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            //  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today, });
            //  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);
        }








        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  取消数据 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove2WithAutoResetNotInOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                IsNeedAutoReset = true,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-1), });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today.AddDays(-2), });
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
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-1), });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 2个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再加入数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 120, SalesDate = DateTime.Today.AddDays(-3), });
            // 本次加入， 满足 “至少2次”的条件，因此结果列表数据中 2行数据都被加入.
            Assert.AreEqual(2, processer.ResultList.Count);

            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today.AddDays(-2), });
            // 因为 启用了 “自动重置”
            // 当结果列表中数据不足 2个的时候， 自动将数据从结果列表中 移出.
            Assert.AreEqual(0, processer.ResultList.Count);
        }







        /// <summary>
        /// 测试新增 与 删除的处理.
        /// 
        /// （测试  取消数据 处理 的 删除）
        /// </summary>
        [Test]
        public void DoTestAddRemove2WithAutoResetInOneDay()
        {
            processer = new MultiTimeDataProcess<TestData>()
            {
                AccessAbleCount = 2,
                IsNeedAutoReset = true,
                // 不允许同一天.
                NotAllowAllInOneDay = true,
            };


            // 加入第一行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            // 由于是第一次加入， 因此结果列表中数据为 0.
            Assert.AreEqual(0, processer.ResultList.Count);

            // 加入第二行数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 120, SalesDate = DateTime.Today, });
            //  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);

            // 后续持续加入
            for (int i = 0; i < 10; i++)
            {
                processer.AddData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                //  但是在同一天， 因此还是为 0
                Assert.AreEqual(0, processer.ResultList.Count);
            }


            // 开始持续删除.
            for (int i = 0; i < 10; i++)
            {
                processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "A0" + i, SalesAmt = 120 + i, SalesDate = DateTime.Today, });
                //  但是在同一天， 因此还是为 0
                Assert.AreEqual(0, processer.ResultList.Count);
            }


            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S01", SalesAmt = 100, SalesDate = DateTime.Today, });
            //  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);


            // 再加入数据.
            processer.AddData(new TestData() { VipNo = "V01", SalesNo = "S03", SalesAmt = 120, SalesDate = DateTime.Today, });
            //  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);

            // 再删除.
            processer.RemoveData(new TestData() { VipNo = "V01", SalesNo = "S02", SalesAmt = 100, SalesDate = DateTime.Today, });
            //  但是在同一天， 因此还是为 0
            Assert.AreEqual(0, processer.ResultList.Count);
        }







    }


}
