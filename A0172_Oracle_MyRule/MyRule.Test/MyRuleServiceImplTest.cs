using MyRule.ServiceImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using MyRule.EF;
using System.Collections.Generic;

namespace MyRule.Test
{
    
    
    /// <summary>
    ///这是 MyRuleServiceImplTest 的测试类，旨在
    ///包含所有 MyRuleServiceImplTest 单元测试
    ///</summary>
    [TestClass()]
    public class MyRuleServiceImplTest
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
        ///GetUserAccessAbleDeptList 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserAccessAbleDeptListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl();
            List<MR_DEPT> orgList;

            // 查询 张三 的 可访问部门列表.
            orgList = target.GetUserAccessAbleDeptList("H00I001");
            // 查询结果非空.
            Assert.IsNotNull(orgList);
            // 预期结果为 9 个 组织部门.
            Assert.AreEqual(9, orgList.Count);

            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_1));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_2));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_3));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_4));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_5));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_6));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_7));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_8));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_9));


            // 查询测试数据中 “李四” 的可访问部门 列表.
            orgList = target.GetUserAccessAbleDeptList("H00I002");
            // 查询结果非空.
            Assert.IsNotNull(orgList);
            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_1));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_9));


            // 查询测试数据中 “王五” 的可访问部门 列表.
            orgList = target.GetUserAccessAbleDeptList("H00I003");
            // 查询结果非空.
            Assert.IsNotNull(orgList);
            // 1个 组织部门.
            Assert.AreEqual(1, orgList.Count);
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_2));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_3));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_6));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_7));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_8));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_9));


            // 查询测试数据中 “赵六” 的可访问部门 列表.
            orgList = target.GetUserAccessAbleDeptList("H00I004");
            // 查询结果非空.
            Assert.IsNotNull(orgList);
            // 4个 组织部门.
            Assert.AreEqual(4, orgList.Count);
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_1));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_2));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_3));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_4));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_5));
            Assert.AreEqual(0, orgList.Count(p => p.DEPT_NAME == TestData.Org_6));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_7));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_8));
            Assert.AreEqual(1, orgList.Count(p => p.DEPT_NAME == TestData.Org_9));

        }







        /// <summary>
        ///GetUserAccessAbleModuleList 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserAccessAbleModuleListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl();

            List<MR_MODULE> modelList;

            // 查询测试数据中 “张三” 的可访问 “模块” 列表.
            modelList = target.GetUserAccessAbleModuleList("H00I001");
            // 9个 模块.
            Assert.AreEqual(9, modelList.Count);
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));




            // 查询测试数据中 “李四” 的可访问 “模块” 列表.
            modelList = target.GetUserAccessAbleModuleList("H00I002");
            // 4个 模块.
            Assert.AreEqual(4, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));




            // 查询测试数据中 “王五” 的可访问 “模块” 列表.
            modelList = target.GetUserAccessAbleModuleList("H00I003");
            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));




            // 查询测试数据中 “赵六” 的可访问 “模块” 列表.
            modelList = target.GetUserAccessAbleModuleList("H00I004");
            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));
        }




        /// <summary>
        ///GetUserAccessAbleActionList 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserAccessAbleActionListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl();
            List<MR_ACTION> actionList;

            // 查询测试数据中 “张三” 的可访问 “动作” 列表.
            actionList = target.GetUserAccessAbleActionList("H00I001", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I001", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I001", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I001", "M04");
            // 4个 动作. 部门管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);

            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_2));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));


            actionList = target.GetUserAccessAbleActionList("H00I001", "M05");
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));


            actionList = target.GetUserAccessAbleActionList("H00I001", "M06");
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));


            actionList = target.GetUserAccessAbleActionList("H00I001", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I001", "M08");
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I001", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);







            // 查询测试数据中 “李四” 的可访问 “动作” 列表.
            actionList = target.GetUserAccessAbleActionList("H00I002", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I002", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I002", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I002", "M04");
            // 3个 动作. 部门管理 有  改 删  (查)  3个 动作.
            Assert.AreEqual(3, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));

            actionList = target.GetUserAccessAbleActionList("H00I002", "M05");
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));

            actionList = target.GetUserAccessAbleActionList("H00I002", "M06");
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));

            actionList = target.GetUserAccessAbleActionList("H00I002", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I002", "M08");
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetUserAccessAbleActionList("H00I002", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

        }




        /// <summary>
        ///GetRoleAccessAbleModuleList 的测试
        ///</summary>
        [TestMethod()]
        public void GetRoleAccessAbleModuleListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl(); 

            List<MR_MODULE> modelList;


            modelList = target.GetRoleAccessAbleModuleList("R01");
            // 9个 模块.
            Assert.AreEqual(9, modelList.Count);
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));



            modelList = target.GetRoleAccessAbleModuleList("R02");
            // 4个 模块.
            Assert.AreEqual(4, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));



            modelList = target.GetRoleAccessAbleModuleList("R03");
            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));

        }

        /// <summary>
        ///GetRoleAccessAbleActionList 的测试
        ///</summary>
        [TestMethod()]
        public void GetRoleAccessAbleActionListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl();
            List<MR_ACTION> actionList;

            
            actionList = target.GetRoleAccessAbleActionList("R01", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);
            
            actionList = target.GetRoleAccessAbleActionList("R01", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R01", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R01", "M04");
            // 4个 动作. 部门管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_2));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));


            actionList = target.GetRoleAccessAbleActionList("R01", "M05");
            // 4个 动作. 职位管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_6));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_7));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_8));


            actionList = target.GetRoleAccessAbleActionList("R01", "M06");
            // 4个 动作. 人员管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_10));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_11));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_12));


            actionList = target.GetRoleAccessAbleActionList("R01", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R01", "M08");
            // 权限功能管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R01", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);





            actionList = target.GetRoleAccessAbleActionList("R02", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R02", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R02", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R02", "M04");
            // 1个 动作. 部门管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_2));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));


            actionList = target.GetRoleAccessAbleActionList("R02", "M05");
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_6));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_7));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_8));


            actionList = target.GetRoleAccessAbleActionList("R02", "M06");
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_10));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_11));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_12));


            actionList = target.GetRoleAccessAbleActionList("R02", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R02", "M08");
            // 权限功能管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetRoleAccessAbleActionList("R02", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);



        }






        /// <summary>
        ///GetAllUserAccessAbleModuleList 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllUserAccessAbleModuleListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl();

            List<MR_MODULE> modelList;

            // 查询测试数据中 “张三” 的可访问 “模块” 列表.
            modelList = target.GetAllUserAccessAbleModuleList("H00I001");
            // 9个 模块.
            Assert.AreEqual(9, modelList.Count);
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));




            // 查询测试数据中 “李四” 的可访问 “模块” 列表.
            modelList = target.GetAllUserAccessAbleModuleList("H00I002");
            // 4个 模块.
            Assert.AreEqual(4, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));




            // 查询测试数据中 “王五” 的可访问 “模块” 列表.
            modelList = target.GetAllUserAccessAbleModuleList("H00I003");
            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));




            // 查询测试数据中 “赵六” 的可访问 “模块” 列表.
            modelList = target.GetAllUserAccessAbleModuleList("H00I004");
            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));



            // 测试数据中，  张A 仅仅配置了 “全部权限”角色.
            modelList = target.GetAllUserAccessAbleModuleList("H00I005");
            // 9个 模块.
            Assert.AreEqual(9, modelList.Count);
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));


            // 测试数据中，  李B 仅仅配置了 “只读权限”角色.
            modelList = target.GetAllUserAccessAbleModuleList("H00I006");
            // 4个 模块.
            Assert.AreEqual(4, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));


            // 测试数据中，  李B 仅仅配置了 “只读权限”角色.
            modelList = target.GetAllUserAccessAbleModuleList("H00I007");
            // 1个 模块.
            Assert.AreEqual(1, modelList.Count);
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_1));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_2));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_3));
            Assert.AreEqual(1, modelList.Count(p => p.MODULE_NAME == TestData.Model_4));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_5));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_6));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_7));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_8));
            Assert.AreEqual(0, modelList.Count(p => p.MODULE_NAME == TestData.Model_9));


            // 测试数据中，  赵D 什么也没有配置.
            modelList = target.GetAllUserAccessAbleModuleList("H00I008");
            // 0个 模块.
            Assert.AreEqual(0, modelList.Count);

        }



        /// <summary>
        ///GetAllUserAccessAbleActionList 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllUserAccessAbleActionListTest()
        {
            MyRuleServiceImpl target = new MyRuleServiceImpl();

            List<MR_ACTION> actionList;

            // 查询测试数据中 “张三” 的可访问 “动作” 列表.
            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M04");
            // 4个 动作. 部门管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);

            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_2));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));


            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M05");
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));


            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M06");
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));


            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M08");
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I001", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);







            // 查询测试数据中 “李四” 的可访问 “动作” 列表.
            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M04");
            // 3个 动作. 部门管理 有  改 删  (查)  3个 动作.
            Assert.AreEqual(3, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M05");
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M06");
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M08");
            // 权限功能管理   没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I002", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);









            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M04");
            // 4个 动作. 部门管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_2));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));


            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M05");
            // 4个 动作. 职位管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_6));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_7));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_8));


            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M06");
            // 4个 动作. 人员管理 有  增改删 (查)  4个 动作.
            Assert.AreEqual(4, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_10));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_11));
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_12));


            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M08");
            // 权限功能管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I005", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);





            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M01");
            // 0个 动作.  人事管理 是 顶级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M02");
            // 0个 动作.  人事组织管理  是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M03");
            // 0个 动作.  权限管理 是 1级模块无 动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M04");
            // 1个 动作. 部门管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_1));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_2));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_3));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_4));


            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M05");
            // 1个 动作. 职位管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_5));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_6));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_7));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_8));


            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M06");
            // 1个 动作. 人员管理 有   (查)  1个 动作.
            Assert.AreEqual(1, actionList.Count);
            Assert.AreEqual(1, actionList.Count(p => p.ACTION_NAME == TestData.Action_9));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_10));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_11));
            Assert.AreEqual(0, actionList.Count(p => p.ACTION_NAME == TestData.Action_12));


            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M07");
            // 权限管理模块  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M08");
            // 权限功能管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

            actionList = target.GetAllUserAccessAbleActionList("H00I006", "M09");
            // 接口角色管理  没有定义动作.
            Assert.AreEqual(0, actionList.Count);

        }
    }
}
