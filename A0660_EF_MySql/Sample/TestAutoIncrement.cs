using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0660_EF_MySql.Sample
{
 
    
    /// <summary>
    /// 测试 MySQL 的 AUTO_INCREMENT
    /// (自增列)
    /// </summary>
    public class TestAutoIncrement
    {

        
        /// <summary>
        /// 测试 AUTO_INCREMENT 在系统中，是否会影响 EF 的运作。
        /// </summary>
        public static void DoTest()
        {
            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine();
                Console.WriteLine("测试 AUTO_INCREMENT Start!");



                Console.WriteLine("首先测试  执行插入处理！");
                try
                {
                    test_auto_increment_tab test1 = new test_auto_increment_tab()
                    {
                        value = "测试"
                    };

                    context.test_auto_increment_tab.AddObject(test1);
                    context.SaveChanges();
                    Console.WriteLine("执行插入成功！");



                    Console.WriteLine("数据库那里产生了自增的 AUTO_INCREMENT 数值， 同时更新到当前这个字段上.");
                    Console.WriteLine("test1 的 id = {0}", test1.id);


                    Console.WriteLine("尝试再检索.");
                    var query =
                        from data in context.test_auto_increment_tab
                        where data.value == "测试"
                        select data;

                    foreach (test_auto_increment_tab t in query)
                    {
                        Console.WriteLine("id = {0};  value = {1} ", t.id, t.value);
                        context.test_auto_increment_tab.DeleteObject(t);
                    }

                    context.SaveChanges();
                    Console.WriteLine("执行删除成功！");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("执行失败！");

                    Console.WriteLine(ex.Message);
                }



                Console.WriteLine("测试 AUTO_INCREMENT Finish!");
                Console.WriteLine();
            }
        }


    }
}
