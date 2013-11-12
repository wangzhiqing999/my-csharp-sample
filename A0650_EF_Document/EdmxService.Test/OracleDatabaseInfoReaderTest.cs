using EdmxService.ServiceImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using EdmxService.Model;
using System.Collections.Generic;

namespace EdmxService.Test
{
    
    
    /// <summary>
    ///这是 OracleDatabaseInfoReaderTest 的测试类，旨在
    ///包含所有 OracleDatabaseInfoReaderTest 单元测试
    ///</summary>
    [TestClass()]
    public class OracleDatabaseInfoReaderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///ReadAllTableAndViewInfo 的测试
        ///</summary>
        [TestMethod()]
        public void ReadAllTableAndViewInfoTest()
        {
            OracleDatabaseInfoReader target = new OracleDatabaseInfoReader();

            string connString =
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.56.102)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=TEST;Password=TEST";


            List<TableOrViewInfo> tableInfoList = target.ReadAllTableAndViewInfo(connString);


            // 查询目标数据库， 结果列表应该非空.
            Assert.IsNotNull(tableInfoList);



            TableOrViewInfo testMainTableInfo = tableInfoList.FirstOrDefault(p => p.Name == "TEST_MAIN");
            // 结果列表应该 包含有  TEST_MAIN 表的信息.
            Assert.IsNotNull(testMainTableInfo);
            // 备注信息 应该与 数据库中像匹配.
            Assert.AreEqual("测试主表", testMainTableInfo.Comment);


            TableOrViewInfo testSubTableInfo = tableInfoList.FirstOrDefault(p => p.Name == "TEST_SUB");
            // 结果列表应该 包含有  TEST_SUB 表的信息.
            Assert.IsNotNull(testSubTableInfo);
            // 备注信息 应该与 数据库中像匹配.
            Assert.AreEqual("测试子表", testSubTableInfo.Comment);




            // 结果列表应该 包含有  TEST_MAIN 表  中具体每一列 的信息.
            // 列的 List 应该非空.
            Assert.IsNotNull(testMainTableInfo.ColumnList);
            // TEST_MAIN 表 只有2列.
            Assert.AreEqual(2, testMainTableInfo.ColumnList.Count);

            ColumnInfo testMainId = testMainTableInfo.ColumnList.FirstOrDefault(p => p.Name == "ID");
            // 应该能够检索到 TEST_MAIN 表的 ID 列.
            Assert.IsNotNull(testMainId);
            // 列的备注信息应该与数据库一致.
            Assert.AreEqual("测试主表编号", testMainId.Comment);


            ColumnInfo testMainValue = testMainTableInfo.ColumnList.FirstOrDefault(p => p.Name == "VALUE");
            // 应该能够检索到 TEST_MAIN 表的 VALUE 列.
            Assert.IsNotNull(testMainValue);
            // 列的备注信息应该与数据库一致.
            Assert.AreEqual("测试主表数值", testMainValue.Comment);

        }
    }
}
