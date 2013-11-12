using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 注意： EF 中测试 事务处理， 需要增加这个 引用
using System.Transactions;



namespace A0650_EF_SqlServer.Sample
{
    class TestTransaction
    {



        /// <summary>
        /// 正常的测试.
        /// </summary>
        private static void TestNormal()
        {


            Console.WriteLine();
            Console.WriteLine("开始测试 事务处理...");

            try
            {

                // 这里用于 模拟2个 Context ， 执行同样的操作。
                // 导致 异常， 最后 回滚数据修改的处理.
                using (TransactionScope scope = new TransactionScope())
                {

                    TestEntities context1 = new TestEntities();
                    TestEntities context2 = new TestEntities();


                    test_main testData = new test_main()
                    {
                        id = 99,
                        value = "测试事务处理."
                    };


                    context1.test_main.AddObject(testData);
                    context2.test_main.AddObject(testData);



                    // 注意， 这里  调用  SaveChanges 方法时， 传入的参数是  
                    //     "在保存更改后，调用 AcceptAllChangesAfterSave() 方法，该方法会在 ObjectStateManager 中重置更改跟踪。 " .
                    context1.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                    // Save Changes but don't discard yet 
                    context2.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                    scope.Complete();


                    // 调用 AcceptAllChanges 意味着 真正地更新了数据库的数据.
                    context1.AcceptAllChanges();

                    context2.AcceptAllChanges();
                }
            }
            catch
            {
                Console.WriteLine("异常发生了，数据更改回滚！");
                Console.WriteLine("当前数据库中，TEST_MAIN 表应当没有 ID = 99 的 数据。");

                using (TestEntities context = new TestEntities())
                {
                    test_main mainData = context.test_main.FirstOrDefault(p => p.id == 99);

                    if (mainData == null)
                    {
                        Console.WriteLine("数据核对成功，TEST_MAIN 表没有 ID = 99 的 数据。");
                    }
                    else
                    {
                        Console.WriteLine("数据核对失败，TEST_MAIN 表有 ID = 99 的 数据。");
                    }

                }

            }


        }









        /// <summary>
        /// 测试 正常的调用 + 存储过程调用
        /// </summary>
        private static void TestCallProc()
        {


            Console.WriteLine();
            Console.WriteLine("开始测试 事务处理 （先调用存储过程， 后添加数据）...");



            // 注意： 运行的时候
            
            // 如果是 Oracle 数据库， 会提示
            // 无法启动此程序，因为计算机中丢失 MSVCRTD.dll 
            // 忽略对话框， 直接按确定按钮以后， 程序可正常执行。

            // 对于 SQL Server 数据库来说， 则没有这个问题.


            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (TestEntities context = new TestEntities())
                    {
                        Console.WriteLine("调用插入数据的存储过程！");
                        context.TestInsertMainSub("procMain2", "procSub2");

                        test_main testData = new test_main()
                        {
                            id = 99,
                            value = "测试事务处理."
                        };
                        context.test_main.AddObject(testData);
                        context.test_main.AddObject(testData);


                        // 注意， 这里  调用  SaveChanges 方法时， 传入的参数是  false.
                        context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                        scope.Complete();

                        // 调用 AcceptAllChanges 意味着 真正地更新了数据库的数据.
                        context.AcceptAllChanges();
                    }

                }
            }
            catch
            {
                Console.WriteLine("异常发生了，数据更改回滚！");
                Console.WriteLine("当前数据库中，TEST_MAIN 表应当没有 ID = 99 的 数据。");

                using (TestEntities context = new TestEntities())
                {
                    test_main mainData = context.test_main.FirstOrDefault(p => p.id == 99);

                    if (mainData == null)
                    {
                        Console.WriteLine("数据核对成功，TEST_MAIN 表没有 ID = 99 的 数据。");
                    }
                    else
                    {
                        Console.WriteLine("数据核对失败，TEST_MAIN 表有 ID = 99 的 数据。");
                    }




                    int mainID = 0;

                    mainData = context.test_main.FirstOrDefault(p => p.value == "procMain2");
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

            }

            Console.WriteLine();

        }




        /// <summary>
        /// 测试事务处理.
        /// </summary>
        public static void DoTest()
        {
            // 正常的测试
            TestNormal();


            // 事务中 调用存储过程.
            TestCallProc();
        }





    }
}
