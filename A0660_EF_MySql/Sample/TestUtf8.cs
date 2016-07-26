using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0660_EF_MySql.Sample
{

    /// <summary>
    /// 测试 UTF8 编码的情况.
    /// </summary>
    class TestUtf8
    {

        /// <summary>
        /// 测试.
        /// </summary>
        public static void DoTest()
        {

            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine();
                Console.WriteLine("测试 中文汉字输入 Start!");


                test_tab testData = new test_tab()
                {
                     value1 = "测试中文1",
                     value2 = "测试中文2",
                };

                context.test_tab.AddObject(testData);
                context.SaveChanges();
                Console.WriteLine("执行插入成功！");



                Console.WriteLine("尝试再检索.");
                var query =
                    from data in context.test_tab
                    where data.value1 == "测试中文1"
                    select data;


                foreach (test_tab t in query)
                {
                    Console.WriteLine("id = {0};  value1 = {1};  value2 = {2} ", t.id, t.value1, t.value2);
                    context.test_tab.DeleteObject(t);
                }

                context.SaveChanges();
                Console.WriteLine("执行删除成功！");


                Console.WriteLine("测试 中文汉字输入 Finish!");
            }


        }

    }



}
