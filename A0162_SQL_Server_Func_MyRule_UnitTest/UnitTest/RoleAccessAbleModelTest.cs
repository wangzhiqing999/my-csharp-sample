using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NUnit.Framework;


using A0162_SQL_Server_Func_MyRule_UnitTest;



namespace A0162_SQL_Server_Func_MyRule_UnitTest.UnitTest
{

    /// <summary>
    ///  角色的 "可访问模块" 列表 方法测试.
    /// </summary>
    [TestFixture]
    public class RoleAccessAbleModuleTest
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
        [Category("角色模块")]
        public void TestRole1()
        {
            // 测试数据中， 角色1 是  人事管理  全部权限 

            // 查询测试数据中 “角色1” 的可访问 “模块” 列表.
            List<MyRule_RoleAccessAbleModuleResult> modelList =
                context.MyRule_RoleAccessAbleModule(1).ToList();

            // 9个 模块.
            Assert.AreEqual(9, modelList.Count);

            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_2));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_7));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_8));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_9));




            // 查询测试数据中 “角色1 ” 的可访问 “模块动作” 列表.

            List<MyRule_RoleAccessAbleActionResult> actionList =
                context.MyRule_RoleAccessAbleAction(1, 1).ToList();
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(1, 2).ToList();
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList =
                context.MyRule_RoleAccessAbleAction(1, 3).ToList();
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);



            actionList =
                context.MyRule_RoleAccessAbleAction(1, 4).ToList();
            // 4个 动作. 部门管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);

            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_2));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_4));


            actionList =
                context.MyRule_RoleAccessAbleAction(1, 5).ToList();
            // 4个 动作. 职位管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_5));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_6));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_7));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_8));


            actionList =
                context.MyRule_RoleAccessAbleAction(1, 6).ToList();
            // 4个 动作. 人员管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_9));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_10));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_11));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_12));



            actionList =
                context.MyRule_RoleAccessAbleAction(1, 7).ToList();
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(1, 8).ToList();
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(1, 9).ToList();
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);
        }





        [Test]
        [Category("角色模块")]
        public void TestRole2()
        {
            // 测试数据中， 角色2 是 人事组织管理 只读权限 
            int roleID = 2;


            // 查询测试数据中 “角色2” 的可访问 “模块” 列表.
            List<MyRule_RoleAccessAbleModuleResult> modelList =
                context.MyRule_RoleAccessAbleModule(roleID).ToList();

            // 4个 模块.
            Assert.AreEqual(4, modelList.Count);

            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_9));




            // 查询测试数据中 “角色2 ” 的可访问 “模块动作” 列表.

            List<MyRule_RoleAccessAbleActionResult> actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 1).ToList();
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 2).ToList();
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 3).ToList();
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);



            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 4).ToList();
            // 1个 动作. 部门管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);

            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_1));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_2));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_3));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_4));


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 5).ToList();
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_5));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_6));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_7));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_8));


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 6).ToList();
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_9));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_10));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_11));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_12));



            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 7).ToList();
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 8).ToList();
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 9).ToList();
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);
        }





        [Test]
        [Category("角色模块")]
        public void TestRole3()
        {
            // 测试数据中， 角色3 是 部门管理 读写权限 
            int roleID = 3;


            // 查询测试数据中 “角色3” 的可访问 “模块” 列表.
            List<MyRule_RoleAccessAbleModuleResult> modelList =
                context.MyRule_RoleAccessAbleModule(roleID).ToList();

            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);

            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.module_name == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.module_name == TestData.Model_9));




            // 查询测试数据中 “角色3 ” 的可访问 “模块动作” 列表.

            List<MyRule_RoleAccessAbleActionResult> actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 1).ToList();
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 2).ToList();
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 3).ToList();
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);



            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 4).ToList();
            // 2个 动作. 部门管理 有   修改 (查)  2个 动作.
            Assert.AreEqual(2, actionList.Count);

            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_1));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_2));
            Assert.AreEqual(1, actionList.Count(p => p.action_name == TestData.Action_3));
            Assert.AreEqual(0, actionList.Count(p => p.action_name == TestData.Action_4));


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 5).ToList();
            // 0个 动作. 职位管理 有   0 个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 6).ToList();
            // 0个 动作. 人员管理 有  0个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 7).ToList();
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 8).ToList();
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 9).ToList();
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);
        }



        [Test]
        [Category("角色模块")]
        public void TestRole99()
        {
            // 99 = 不存在的角色.
            int roleID = 99;


            // 查询测试数据中 “不存在的角色” 的可访问 “模块” 列表.
            List<MyRule_RoleAccessAbleModuleResult> modelList =
                context.MyRule_RoleAccessAbleModule(roleID).ToList();

            // 0个 模块.
            Assert.AreEqual(0, modelList.Count);



            // 查询测试数据中 “不存在的角色 ” 的可访问 “模块动作” 列表.

            List<MyRule_RoleAccessAbleActionResult> actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 1).ToList();
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 2).ToList();
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 3).ToList();
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);



            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 4).ToList();
            // 0个 动作. 部门管理 有   修改 (查)  2个 动作.
            Assert.AreEqual(0, actionList.Count);

 
            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 5).ToList();
            // 0个 动作. 职位管理 有   0 个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 6).ToList();
            // 0个 动作. 人员管理 有  0个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 7).ToList();
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 8).ToList();
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 9).ToList();
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);
        }




        [Test]
        [Category("角色模块")]
        public void TestRoleNull()
        {
            // null = 不存在的角色.
            int? roleID = null;


            // 查询测试数据中 “不存在的角色” 的可访问 “模块” 列表.
            List<MyRule_RoleAccessAbleModuleResult> modelList =
                context.MyRule_RoleAccessAbleModule(roleID).ToList();

            // 0个 模块.
            Assert.AreEqual(0, modelList.Count);



            // 查询测试数据中 “不存在的角色 ” 的可访问 “模块动作” 列表.

            List<MyRule_RoleAccessAbleActionResult> actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 1).ToList();
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 2).ToList();
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 3).ToList();
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);



            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 4).ToList();
            // 0个 动作. 部门管理 有   修改 (查)  2个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 5).ToList();
            // 0个 动作. 职位管理 有   0 个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 6).ToList();
            // 0个 动作. 人员管理 有  0个 动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 7).ToList();
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 8).ToList();
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);


            actionList =
                context.MyRule_RoleAccessAbleAction(roleID, 9).ToList();
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);
        }



    }


}
