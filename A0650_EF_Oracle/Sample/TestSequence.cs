using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0650_EF_Oracle.Sample
{

    /// <summary>
    /// 本类用于测试 在 Entity Framework 中。
    /// 
    /// 如果 Oracle 的表的主键， 是使用 sequence 的。
    /// 会对使用造成哪些影响.
    /// </summary>
    public class TestSequence
    {

        /// <summary>
        /// 测试 序列号+触发器 在系统中，是否会影响 EF 的运作。
        /// </summary>
        public static void DoTest()
        {


            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine();
                Console.WriteLine("测试 触发器 + 序列号 Start!");



                Console.WriteLine("首先测试  执行插入处理！");
                try
                {
                    TEST_SEQ_TAB test1 = new TEST_SEQ_TAB()
                    {
                        VALUE = "测试"
                    };

                    context.TEST_SEQ_TAB.AddObject(test1);
                    context.SaveChanges();
                    Console.WriteLine("执行插入成功！");



                    Console.WriteLine("数据库那里产生序列号了， 但是没有更新到当前这个字段上.");
                    Console.WriteLine("test1 的 ID = {0}", test1.ID);


                    Console.WriteLine("尝试再检索.");
                    var query =
                        from data in context.TEST_SEQ_TAB
                        where data.VALUE == "测试"
                        select data;

                    foreach (TEST_SEQ_TAB t in query)
                    {
                        Console.WriteLine("id = {0};  value = {1} ", t.ID, t.VALUE);
                        context.TEST_SEQ_TAB.DeleteObject(t);
                    }

                    context.SaveChanges();
                    Console.WriteLine("执行删除成功！");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("执行失败！");

                    Console.WriteLine(ex.Message);
                }


                // 对数据库所做的更改已成功提交，但在更新对象上下文时出错。此 ObjectContext 可能处
                //于不一致状态。内部异常消息: AcceptChanges 无法继续，因为该对象的键值与 ObjectSta
                //teManager 中的另一个对象冲突。请在调用 AcceptChanges 之前，确保键值是唯一的。





                Console.WriteLine("测试 触发器 + 序列号 Finish!");
                Console.WriteLine();
            }

        }

    }
}
