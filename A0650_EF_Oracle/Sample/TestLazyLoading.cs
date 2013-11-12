using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace A0650_EF_Oracle.Sample
{
    /// <summary>
    /// 测试延迟加载.
    /// </summary>
    public class TestLazyLoading
    {
        /// <summary>
        /// 测试.
        /// </summary>
        public static void DoTest()
        {
            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine("测试 使用 延迟加载！");
                // 使用 延迟加载.
                context.ContextOptions.LazyLoadingEnabled = true;



                Console.WriteLine("### 开始测试 一对多 的延迟加载！ ###");
                // 这里主动查询 test_main
                foreach (TEST_MAIN m in context.TEST_MAIN.Where(p => p.ID < 100))
                {
                    Console.WriteLine("Main = {0}:{1}", m.ID, m.VALUE);

                    // 下面使用 延迟加载， 自动取查询 TEST_SUB
                    if (m.TEST_SUB != null)
                    {
                        foreach (TEST_SUB s in m.TEST_SUB)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.ID, s.VALUE);
                        }
                    }
                }



                Console.WriteLine("### 开始测试 多对多 的延迟加载！ ###");

                foreach (TEST_STUDENT m in context.TEST_STUDENT)
                {
                    Console.WriteLine("学生 = {0}:{1}", m.STUDENT_CODE, m.STUDENT_NAME);
                    // 下面使用 延迟加载， 自动取查询 test_score
                    if (m.TEST_SCORE != null)
                    {
                        foreach (TEST_SCORE s in m.TEST_SCORE)
                        {
                            Console.WriteLine("----- 成绩 = {0}:{1}:{2}", 
                                s.COURSE_CODE, s.TEST_COURSE.COURSE_NAME, s.SCORE_VALUE);
                        }
                    }
                }
            }



            Console.WriteLine();

            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine("测试 不使用 延迟加载！");
                // 不使用 延迟加载.
                context.ContextOptions.LazyLoadingEnabled = false;

                Console.WriteLine("普通方式查询 test_main！");
                // 这里主动查询 test_main
                foreach (TEST_MAIN m in context.TEST_MAIN.Where(p => p.ID < 100))
                {
                    Console.WriteLine("Main = {0}:{1}", m.ID, m.VALUE);                   
                    if (m.TEST_SUB != null)
                    {
                        // 注意：
                        //    使用 非延迟加载的， 结果不是 NULL, 是一个空白列表.

                        foreach (TEST_SUB s in m.TEST_SUB)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.ID, s.VALUE);
                        }
                    }
                    else
                    {
                        Console.WriteLine("m.TEST_SUB  is  null...");
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Include 方式查询 test_main！");
                // 这里使用 贪婪加载.
                foreach (TEST_MAIN m in context.TEST_MAIN.Include("TEST_SUB").Where(p => p.ID < 100))
                {
                    Console.WriteLine("Main = {0}:{1}", m.ID, m.VALUE);
                    if (m.TEST_SUB != null)
                    {
                        foreach (TEST_SUB s in m.TEST_SUB)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.ID, s.VALUE);
                        }
                    }
                    else
                    {
                        Console.WriteLine("m.TEST_SUB  is  null...");
                    }
                }



                Console.WriteLine();
                Console.WriteLine("多对多关系，Include 多层次 查询！");

                foreach (TEST_STUDENT m in context.TEST_STUDENT.Include("TEST_SCORE.TEST_COURSE"))
                {
                    Console.WriteLine("学生 = {0}:{1}", m.STUDENT_CODE, m.STUDENT_NAME);
                    // 下面使用 延迟加载， 自动取查询 test_score
                    if (m.TEST_SCORE != null)
                    {
                        foreach (TEST_SCORE s in m.TEST_SCORE)
                        {
                            Console.WriteLine("----- 成绩 = {0}:{1}:{2}", 
                                s.COURSE_CODE, s.TEST_COURSE.COURSE_NAME, s.SCORE_VALUE);
                        }
                    }
                }


                Console.WriteLine();
                Console.WriteLine("多对多关系，Include 多表 查询！");
                foreach (TEST_SCORE s in context.TEST_SCORE.Include("TEST_STUDENT").Include("TEST_COURSE"))
                {
                    Console.WriteLine("学生 = {0}  课程 = {1}  成绩 = {2} ",
                        s.TEST_STUDENT.STUDENT_NAME,
                        s.TEST_COURSE.COURSE_NAME,
                        s.SCORE_VALUE);
                }

            }
        }
    }

}
