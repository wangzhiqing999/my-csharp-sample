using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Objects;


namespace A0660_EF_MySql.Sample
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
        /// 测试.
        /// </summary>
        public static void DoTest()
        {

            // 测试 in / out 参数.
            TestHelloWorld();


            // 测试 返回结果集的存储过程.
            TestProc();

        }





        /// <summary>
        /// 测试调用 HelloWorld 存储过程.
        /// </summary>
        private static void TestHelloWorld()
        {
            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine("调用 HelloWorld2 存储过程!  该存储过程 3个参数， 1个输入， 2个输出， 返回一个单行的结果集 ");

                ObjectParameter p1 = new ObjectParameter("vOutValue", "");
                ObjectParameter p2 = new ObjectParameter("vInOutValue", "");

                ObjectResult<string> result = context.HelloWorld2("Test", p1, p2);


                Console.WriteLine(result.FirstOrDefault());
                Console.WriteLine(p1.Value);
                Console.WriteLine(p2.Value);
            }
        }



        /// <summary>
        /// 测试调用 testProc 存储过程.
        /// </summary>
        private static void TestProc()
        {
            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine("调用 testProc 存储过程!  该存储过程 无参数， 返回一个2行2列的结果集 ");

                var query = context.TestProc();

                foreach (testprocresult oneResult in query)
                {
                    Console.WriteLine("A={0},  B={1}",  oneResult.A,  oneResult.B);
                }
            }
        }





    }
}
