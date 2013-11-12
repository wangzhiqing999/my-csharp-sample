using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0650_EF_SqlServer.Sample
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
                test_main mainData = context.test_main.FirstOrDefault(p => p.value == "procMain");
                Console.WriteLine("Main: ID = {0}; VALUE = {1}", mainData.id, mainData.value);

                test_sub subData = context.test_sub.FirstOrDefault(p => p.value == "procSub");
                Console.WriteLine("SUB: ID = {0}; VALUE = {1}", subData.id, subData.value);



                Console.WriteLine();
                Console.WriteLine("调用删除数据的存储过程！");

                int mainID = mainData.id;

                context.TestRemoveMainSub(mainID);
                Console.WriteLine("查询数据，查看存储过程是否成功执行！");



                mainData = context.test_main.FirstOrDefault(p => p.id == mainID);
                if (mainData == null)
                {
                    Console.WriteLine("Main 数据已被删除！");
                }
                subData = context.test_sub.FirstOrDefault(p => p.main_id == mainID);
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



            int mainID = 0;

            using (TestEntities context = new TestEntities())
            {


                test_main mainData = context.test_main.FirstOrDefault(p => p.value == "procMain2");
                if (mainData != null)
                {
                    mainID = mainData.id;
                    Console.WriteLine("Main: ID = {0}; VALUE = {1}", mainData.id, mainData.value);
                }
                else
                {
                    Console.WriteLine("Main 数据不存在！");
                }


                test_sub subData = context.test_sub.FirstOrDefault(p => p.value == "procSub2");
                if (subData != null)
                {
                    Console.WriteLine("SUB: ID = {0}; VALUE = {1}", subData.id, subData.value);
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

            Console.WriteLine();
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
