using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// 注意： EF 中测试 事务处理， 需要增加这个 引用
using System.Transactions;


namespace A0650_EF_Oracle.Sample
{

    /// <summary>
    /// 事务处理的测试.
    /// </summary>
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


                    TEST_MAIN testData = new TEST_MAIN()
                    {
                        ID = 99,
                        VALUE = "测试事务处理."
                    };


                    context1.TEST_MAIN.AddObject(testData);
                    context2.TEST_MAIN.AddObject(testData);



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
                    TEST_MAIN mainData = context.TEST_MAIN.FirstOrDefault(p => p.ID == 99);

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


            
            // 注意： 运行的时候，可能会提示。
            // 无法启动此程序，因为计算机中丢失 MSVCRTD.dll 
            // 忽略对话框， 直接按确定按钮以后， 程序可正常执行。

            
            // 在某些有 VC ++ 开发工具的计算机上面， 可以找到这个 MSVCRTD.dll  文件.
            // 从那些机器上复制下来，粘贴到 C:\Windows\system32  ( 64 位系统，复制到  C:\Windows\SysWOW64 )
            // 然后再运行，将没有上面的问题。

            try
            {                
                using (TransactionScope scope = new TransactionScope())
                {
                    using (TestEntities context = new TestEntities())
                    {
                        Console.WriteLine("调用插入数据的存储过程！");
                        context.TestInsertMainSub("procMain2", "procSub2");

                        TEST_MAIN testData = new TEST_MAIN()
                        {
                            ID = 99,
                            VALUE = "测试事务处理."
                        };
                        context.TEST_MAIN.AddObject(testData);
                        context.TEST_MAIN.AddObject(testData);


                        // 注意， 这里  调用  SaveChanges 方法时， 传入的参数是  false.
                        context.SaveChanges(false);

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
                    TEST_MAIN mainData = context.TEST_MAIN.FirstOrDefault(p => p.ID == 99);

                    if (mainData == null)
                    {
                        Console.WriteLine("数据核对成功，TEST_MAIN 表没有 ID = 99 的 数据。");
                    }
                    else
                    {
                        Console.WriteLine("数据核对失败，TEST_MAIN 表有 ID = 99 的 数据。");
                    }




                    decimal mainID = 0;

                    mainData = context.TEST_MAIN.FirstOrDefault(p => p.VALUE == "procMain2");
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
