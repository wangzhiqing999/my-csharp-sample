using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A0161_SQL_Server_Porc_UnitTest;


namespace A0161_SQL_Server_Porc_UnitTest.UnitTest
{


    /// <summary>
    /// 格式化方法测试
    /// </summary>
    [TestFixture]
    public class FormatValTest
    {

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String ConnString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=UnitTest;Integrated Security=True";


        /// <summary>
        /// 数据库会话.
        /// </summary>
        private MySerialNumberDataContext context;



        /// <summary>
        /// 
        /// TestFixtureSetup：在当前测试类中的所有测试函数运行前调用；
        /// TestFixtureTearDown：在当前测试类的所有测试函数运行完毕后调用；
        /// 
        /// 例如测试项目是要访问数据库/文件/网络端口的
        /// 那么可以在 TestFixtureSetup 那里打开数据库/文件/网络端口
        /// 并在 TestFixtureTearDown 那里关闭数据库/文件/网络端口
        /// 
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // TestFixtureSetUp 意味着整个测试过程，本方法只执行一次.
            context = new MySerialNumberDataContext(ConnString);
        }





        [Test]
        [Category("日期格式测试")]
        public void TestToday1()
        {
            // 用于测试的日期.
            DateTime testDate = new DateTime(2012, 2, 20);

            Assert.AreEqual("20120220", 
                context.MySerialNumber_FormatVal("[@Today:YYYYMMDD]", testDate, null));

            Assert.AreEqual("201202", 
                context.MySerialNumber_FormatVal("[@Today:YYYYMM]", testDate, null));

            Assert.AreEqual("2012",
                context.MySerialNumber_FormatVal("[@Today:YYYY]", testDate, null));

        }


        [Test]
        [Category("日期格式测试")]
        public void TestToday2()
        {
            // 用于测试的日期.
            DateTime testDate = new DateTime(2012, 1, 1);

            Assert.AreEqual("20120101",
                context.MySerialNumber_FormatVal("[@Today:YYYYMMDD]", testDate, null));

            Assert.AreEqual("201201",
                context.MySerialNumber_FormatVal("[@Today:YYYYMM]", testDate, null));

            Assert.AreEqual("2012",
                context.MySerialNumber_FormatVal("[@Today:YYYY]", testDate, null));

        }



        [Test]
        [Category("序列号格式测试")]
        public void TestSeq1()
        {
            for (int i = 0; i < 100; i++)
            {

                Assert.AreEqual( i.ToString("000000"),
                    context.MySerialNumber_FormatVal("[@Seq:000000]", null, i));

                Assert.AreEqual(i.ToString("00000"),
                    context.MySerialNumber_FormatVal("[@Seq:00000]", null, i));

                Assert.AreEqual(i.ToString("0000"),
                    context.MySerialNumber_FormatVal("[@Seq:0000]", null, i));

                Assert.AreEqual(i.ToString("000"),
                    context.MySerialNumber_FormatVal("[@Seq:000]", null, i));

                Assert.AreEqual(i.ToString("00"),
                    context.MySerialNumber_FormatVal("[@Seq:00]", null, i));

            }
        }



        [Test]
        [Category("默认值测试")]
        public void TestDefault()
        {
            // 格式为空的情况下， 返回 null.
            Assert.IsNull(context.MySerialNumber_FormatVal(null, null, null));


            // 日期为空的情况下， 默认为今天.
            Assert.AreEqual(DateTime.Today.ToString("yyyyMMdd"),
                context.MySerialNumber_FormatVal("[@Today:YYYYMMDD]", null, null));


            // 序列号为空的情况下， 默认为 1.
            Assert.AreEqual("001",
                context.MySerialNumber_FormatVal("[@Seq:000]", null, null));


            // 综合测试.
            Assert.AreEqual(DateTime.Today.ToString("yyyyMMdd") + "001",
                context.MySerialNumber_FormatVal("[@Today:YYYYMMDD][@Seq:000]", null, null));

            Assert.AreEqual("UnitTest" + DateTime.Today.ToString("yyyyMMdd") + "001",
                context.MySerialNumber_FormatVal("UnitTest[@Today:YYYYMMDD][@Seq:000]", null, null));
        }


        [Test]
        public void TestSample()
        {

            // 用于测试的日期.
            DateTime testDate = new DateTime(2012, 2, 20);

            Assert.AreEqual("UnitTest_20120220_001",
                context.MySerialNumber_FormatVal("UnitTest_[@Today:YYYYMMDD]_[@Seq:000]", testDate, 1));

        }


    }



}
