using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A0162_SQL_Server_Func_MyRule_UnitTest;



namespace A0162_SQL_Server_Func_MyRule_UnitTest.UnitTest
{

    /// <summary>
    ///  用户的 "可访问部门" 列表 方法测试.
    /// </summary>
    [TestFixture]
    public class UserAccessAbleDeptTest
    {

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String ConnString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=UnitTest;Integrated Security=True";



        /// <summary>
        /// 数据库会话.
        /// </summary>
        private MyRuleDataContext context;








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
            context = new MyRuleDataContext(ConnString);
        }






        [Test]
        [Category("部门用户")]
        public void TestUser1()
        {
            // 测试数据中， 张三是  总公司+全国

            // 查询测试数据中 “张三” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(1, "Org").ToList();

            // 9个 组织部门.
            Assert.AreEqual(9, orgList.Count);

            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “张三” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(1, "Area").ToList();

            // 9个 城市区域.
            Assert.AreEqual(9, areaList.Count);


            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_9));
        }




        [Test]
        [Category("部门用户")]
        public void TestUser2()
        {
            // 测试数据中， 李四是  总公司+管理部

            // 查询测试数据中 “李四” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(2, "Org").ToList();

            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “李四” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(2, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(1, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_9));
        }



        [Test]
        [Category("部门用户")]
        public void TestUser3()
        {
            // 测试数据中， 王五是  人事部+上海

            // 查询测试数据中 “王五” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(3, "Org").ToList();

            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “王五” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(3, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(1, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_9));
        }




        [Test]
        [Category("部门用户")]
        public void TestUser4()
        {
            // 测试数据中，赵六 是  技术开发部+广州

            // 查询测试数据中 “赵六” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(4, "Org").ToList();

            // 4个 组织部门.
            Assert.AreEqual(4, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “赵六” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(4, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(1, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_9));
        }





        [Test]
        [Category("部门用户")]
        public void TestUser5()
        {
            // 测试数据中，张Ａ 是  系统运行部+重庆

            // 查询测试数据中 “张Ａ” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(5, "Org").ToList();

            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “张Ａ” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(5, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(1, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_9));
        }






        [Test]
        [Category("部门用户")]
        public void TestUser6()
        {
            // 测试数据中，李Ｂ 是  市场部+浙江省

            // 查询测试数据中 “李Ｂ” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(6, "Org").ToList();

            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “李Ｂ” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(6, "Area").ToList();

            // 4个 城市区域.
            Assert.AreEqual(4, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_9));
        }




        [Test]
        [Category("部门用户")]
        public void TestUser7()
        {
            // 测试数据中，王Ｃ 是  硬件组+杭州

            // 查询测试数据中 “王Ｃ” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(7, "Org").ToList();

            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “王Ｃ” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(7, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(1, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_9));
        }





        [Test]
        [Category("部门用户")]
        public void TestUser8()
        {
            // 测试数据中，赵Ｄ 是  软件组+宁波

            // 查询测试数据中 “赵Ｄ” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(8, "Org").ToList();

            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);

            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_7));
            Assert.AreEqual(1, orgList.Count(p => p.dept_name == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.dept_name == TestData.Org_9));





            // 查询测试数据中 “赵Ｄ” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(8, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(1, areaList.Count);


            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_1));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_2));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_3));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_4));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_5));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_6));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_7));
            Assert.AreEqual(1, areaList.Count(p => p.dept_name == TestData.Area_8));
            Assert.AreEqual(0, areaList.Count(p => p.dept_name == TestData.Area_9));
        }




        [Test]
        [Category("部门用户")]
        public void TestUser99()
        {
            // 99 == 不存在用户.
            int userID = 99;


            // 查询测试数据中 “不存在用户” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(userID, "Org").ToList();

            // 0个 组织部门.
            Assert.AreEqual(0, orgList.Count);


            // 查询测试数据中 “不存在用户” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(userID, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(0, areaList.Count);


        }



        [Test]
        [Category("部门用户")]
        public void TestUserNull()
        {
            // null  == 不存在用户.
            int? userID = null;


            // 查询测试数据中 “不存在用户” 的可访问 “组织机构” 列表.
            List<MyRule_UserAccessAbleDeptResult> orgList =
                context.MyRule_UserAccessAbleDept(userID, "Org").ToList();

            // 0个 组织部门.
            Assert.AreEqual(0, orgList.Count);


            // 查询测试数据中 “不存在用户” 的可访问 “区域” 列表.
            List<MyRule_UserAccessAbleDeptResult> areaList =
                context.MyRule_UserAccessAbleDept(userID, "Area").ToList();

            // 1个 城市区域.
            Assert.AreEqual(0, areaList.Count);


        }



    }



}
