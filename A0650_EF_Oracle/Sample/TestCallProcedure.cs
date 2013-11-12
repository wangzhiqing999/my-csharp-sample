using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0650_EF_Oracle.Sample
{

    /// <summary>
    /// 测试调用存储过程.
    /// </summary>
    class TestCallProcedure
    {


        // 在 EF 中使用存储过程的操作步骤如下：
        // 1. 首先， 在数据库中，创建好 存储过程，并 编译通过。
        // 2. 在 edmx 中，选择 “从数据库更新模型”， 将数据库中的存储过程导入
        // 3. 在 edmx 空白区域  鼠标右键， 弹出菜单中选择 “添加 -- 函数导入”
        // 4. 保存 edmx 后， 在 生成的代码中，应该包含新增的 存储过程.



        /// <summary>
        /// 正常的测试.
        /// </summary>
        private static void TestNormal()
        {
            Console.WriteLine("测试调用存储过程！");

            using (TestEntities context = new TestEntities())
            {

                Console.WriteLine("调用插入数据的存储过程！");
                context.TestInsertMainSub("procMain", "procSub");


                Console.WriteLine("查询数据，查看存储过程是否成功执行！");
                TEST_MAIN mainData = context.TEST_MAIN.FirstOrDefault(p => p.VALUE == "procMain");
                Console.WriteLine("Main: ID = {0}; VALUE = {1}", mainData.ID, mainData.VALUE);

                TEST_SUB subData = context.TEST_SUB.FirstOrDefault(p => p.VALUE == "procSub");
                Console.WriteLine("SUB: ID = {0}; VALUE = {1}", subData.ID, subData.VALUE);



                Console.WriteLine();
                Console.WriteLine("调用删除数据的存储过程！");

                decimal mainID = mainData.ID;

                context.TestRemoveMainSub(mainID);
                Console.WriteLine("查询数据，查看存储过程是否成功执行！");



                mainData = context.TEST_MAIN.FirstOrDefault(p => p.ID == mainID);
                if (mainData == null)
                {
                    Console.WriteLine("Main 数据已被删除！");
                }
                subData = context.TEST_SUB.FirstOrDefault(p => p.MAIN_ID == mainID);
                if (subData == null)
                {
                    Console.WriteLine("Sub 数据已被删除！");
                }


                context.SaveChanges();

            }
        }



        /// <summary>
        /// 测试 不 调用 SaveChanges 方法。
        /// 调用存储过程， 是否会更新数据。
        /// </summary>
        private static void TestWithOutSaveChanges()
        {

            Console.WriteLine("测试调用存储过程！");

            using (TestEntities context = new TestEntities())
            {

                Console.WriteLine("调用插入数据的存储过程！");
                context.TestInsertMainSub("procMain2", "procSub2");                
            }

            Console.WriteLine("查询数据！  看看在调用存储过程后， 没有执行 SaveChanges， 是否实际更新了数据！");



            decimal mainID = 0;

            using (TestEntities context = new TestEntities())
            {


                TEST_MAIN mainData = context.TEST_MAIN.FirstOrDefault(p => p.VALUE == "procMain2");
                if (mainData != null)
                {
                    mainID = mainData.ID;
                    Console.WriteLine("Main: ID = {0}; VALUE = {1}", mainData.ID, mainData.VALUE);
                }
                else
                {
                    Console.WriteLine("Main 数据不存在！");
                }


                TEST_SUB subData = context.TEST_SUB.FirstOrDefault(p => p.VALUE == "procSub2");
                if (subData != null)
                {
                    Console.WriteLine("SUB: ID = {0}; VALUE = {1}", subData.ID, subData.VALUE);
                }
                else
                {
                    Console.WriteLine("Sub 数据不存在！");
                }


                if (mainID != 0)
                {
                    // 没有 SaveChanges
                    // 但是数据还是更新了.
                    context.TestRemoveMainSub(mainID);
                }

            }


        }





        /// <summary>
        /// 测试.
        /// </summary>
        public static void DoTest()
        {

            // 正常测试.
            TestNormal();


            // 测试 不 调用 SaveChanges 方法。
            // 调用存储过程， 是否会更新数据。
            TestWithOutSaveChanges();
        }

    }

}
