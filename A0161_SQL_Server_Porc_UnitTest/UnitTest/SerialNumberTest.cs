using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A0161_SQL_Server_Porc_UnitTest;


namespace A0161_SQL_Server_Porc_UnitTest.UnitTest
{

    /// <summary>
    /// 序列号处理测试
    /// </summary>
    [TestFixture]
    public class SerialNumberTest
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

            Console.WriteLine("TestFixtureSetUp Start!");

            // TestFixtureSetUp 意味着整个测试过程，本方法只执行一次.
            context = new MySerialNumberDataContext(ConnString);

            Console.WriteLine("TestFixtureSetUp Finish!");
        }




        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {

            // 下面没有使用  context.my_serial_number.DeleteOnSubmit 的方法.
            // 因为会发生 Linq 找不到行或行已更改 的错误. 

            // 原因在于， 在 my_serial_number mySeq = new my_serial_number();
            // 本地已经缓存了数据
            // 而存储过程，会修改表的数据
            // 但是 linq2sql 没有去重新读取表的数据.
            // 因此，当 context.SubmitChanges(); 的时候
            // 客户端的数据， 与 SQL Server 服务器上面的数据，不一致了
            // 从而导致  Linq 找不到行或行已更改 的错误.


            Console.WriteLine("TestFixtureTearDown Start!");

            // 清理测试数据.
            context.ExecuteCommand("DELETE FROM my_serial_number WHERE sn_name LIKE 'TEST_SEQ%'");


            Console.WriteLine("TestFixtureTearDown Finish!");
        }






        #region 简单测试.


        [Test]
        [Category("简单测试")]
        public void TestSample1()
        {

            // 插入数据.
            my_serial_number mySeq = new my_serial_number();
            mySeq.sn_name = "TEST_SEQ1";
            mySeq.sn_desc = "测试流水号1";
            mySeq.sn_howto = "Normal";
            mySeq.sn_format = "X-[@Today:YYYYMMDD]_[@Seq:0000]";
            mySeq.sn_seq_max = 9999;
            mySeq.sn_seq_min = 1;
            mySeq.sn_seq_curr = 1;
            mySeq.sn_auto_close_date = true;

            context.my_serial_number.InsertOnSubmit(mySeq);
            context.SubmitChanges();


            // 预期的序列号.
            string sn = null;


            for (int i = 1; i < 100; i++)
            {
                // 调用 存储过程 获取的 流水号.
                context.MySerialNumber_NextVal("TEST_SEQ1", ref sn);

                // C# 中模拟计算的 流水号.
                string csn = String.Format(
                    "X-{0}_{1}",
                    DateTime.Today.ToString("yyyyMMdd"),
                    i.ToString("0000"));

                Assert.AreEqual(csn, sn);



                context.MySerialNumber_CurrVal("TEST_SEQ1", ref sn);
                Assert.AreEqual(csn, sn);
            }


        }


        [Test]
        [Category("简单测试")]
        public void TestSample2()
        {
            // 插入数据.
            my_serial_number mySeq = new my_serial_number();
            mySeq.sn_name = "TEST_SEQ2";
            mySeq.sn_desc = "测试流水号2";
            mySeq.sn_howto = "Normal";
            mySeq.sn_format = "ABCD-[@Today:YYYYMM]_[@Seq:0000]";
            mySeq.sn_seq_max = 9999;
            mySeq.sn_seq_min = 1;
            mySeq.sn_seq_curr = 1;
            mySeq.sn_auto_close_date = true;

            context.my_serial_number.InsertOnSubmit(mySeq);
            context.SubmitChanges();


            // 预期的序列号.
            string sn = null;

            for (int i = 1; i < 100; i++)
            {
                // 调用 存储过程 获取的 流水号.
                context.MySerialNumber_NextVal("TEST_SEQ2", ref sn);

                // C# 中模拟计算的 流水号.
                string csn = String.Format(
                    "ABCD-{0}_{1}",
                    DateTime.Today.ToString("yyyyMM"),
                    i.ToString("0000"));

                Assert.AreEqual(csn, sn);



                context.MySerialNumber_CurrVal("TEST_SEQ2", ref sn);
                Assert.AreEqual(csn, sn);
            }
        }



        [Test]
        [Category("简单测试")]
        public void TestSample3()
        {
            // 插入数据.
            my_serial_number mySeq = new my_serial_number();
            mySeq.sn_name = "TEST_SEQ3";
            mySeq.sn_desc = "测试流水号3";
            mySeq.sn_howto = "Normal";
            mySeq.sn_format = "ABCDEF-[@Today:YYYY]_[@Seq:0000]";
            mySeq.sn_seq_max = 9999;
            mySeq.sn_seq_min = 1;
            mySeq.sn_seq_curr = 1;
            mySeq.sn_auto_close_date = true;

            context.my_serial_number.InsertOnSubmit(mySeq);
            context.SubmitChanges();


            // 预期的序列号.
            string sn = null;

            for (int i = 1; i < 100; i++)
            {
                // 调用 存储过程 获取的 流水号.
                context.MySerialNumber_NextVal("TEST_SEQ3", ref sn);

                // C# 中模拟计算的 流水号.
                string csn = String.Format(
                    "ABCDEF-{0}_{1}",
                    DateTime.Today.ToString("yyyy"),
                    i.ToString("0000"));

                Assert.AreEqual(csn, sn);



                context.MySerialNumber_CurrVal("TEST_SEQ3", ref sn);
                Assert.AreEqual(csn, sn);
            }
        }


        #endregion







        #region 异常测试.


        [Test]
        [Category("异常测试")]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void TestNull()
        {
            string sn = null;

            // 调用 存储过程 获取的 流水号.
            // 传入的 流水号名称为 null
            context.MySerialNumber_NextVal(null, ref sn);

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");

        }



        [Test]
        [Category("异常测试")]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void TestNotFound()
        {
            string sn = null;

            // 调用 存储过程 获取的 流水号.
            // 传入的 流水号名称为  不存在的 流水号.
            context.MySerialNumber_NextVal("_TEST_NOT_EXISTS_", ref sn);

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");

        }



        [Test]
        [Category("异常测试")]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void TestOverFlow()
        {
            // 插入数据.
            my_serial_number mySeq = new my_serial_number();
            mySeq.sn_name = "TEST_SEQ_OVERFLOW";
            mySeq.sn_desc = "测试流水号溢出";
            mySeq.sn_howto = "Normal";
            mySeq.sn_format = "ABCDEF-[@Today:YYYY]_[@Seq:00]";
            mySeq.sn_seq_max = 99;
            mySeq.sn_seq_min = 1;
            mySeq.sn_seq_curr = 1;
            mySeq.sn_auto_close_date = true;

            context.my_serial_number.InsertOnSubmit(mySeq);
            context.SubmitChanges();


            // 预期的序列号.
            string sn = null;

            for (int i = 1; i < 100; i++)
            {
                // 调用 存储过程 获取的 流水号.
                context.MySerialNumber_NextVal("TEST_SEQ_OVERFLOW", ref sn);

                // C# 中模拟计算的 流水号.
                string csn = String.Format(
                    "ABCDEF-{0}_{1}",
                    DateTime.Today.ToString("yyyy"),
                    i.ToString("00"));

                Assert.AreEqual(csn, sn);



                context.MySerialNumber_CurrVal("TEST_SEQ_OVERFLOW", ref sn);
                Assert.AreEqual(csn, sn);
            }

            // 前面已经获取了 流水号 01 - 99
            // 下面再次获取流水号， 将为 100， 大于 流水的最大序号 99;
            context.MySerialNumber_NextVal("TEST_SEQ_OVERFLOW", ref sn);


            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");

        }


        #endregion



    }


}
