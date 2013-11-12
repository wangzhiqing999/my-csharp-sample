using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace A0650_EF_SqlServer.Sample
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
                foreach (test_main m in context.test_main.Where(p=>p.id < 100))
                {
                    Console.WriteLine("Main = {0}:{1}", m.id, m.value);
                    // 下面使用 延迟加载， 自动取查询 test_sub
                    if (m.test_sub != null)
                    {
                        foreach (test_sub s in m.test_sub)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.id, s.value);
                        }
                    }


                    Console.WriteLine("========================================");

                    // 测试三层的.
                    if (m.test_sub_s != null)
                    {
                        foreach (test_sub_s s in m.test_sub_s)
                        {
                            Console.WriteLine("----- Sub_S = {0}:{1}", s.id, s.value);

                            if (s.test_sub_of_sub != null)
                            {
                                foreach (test_sub_of_sub ss in s.test_sub_of_sub)
                                {
                                    Console.WriteLine("---------- Sub_S = {0}:{1}", ss.id, ss.value);
                                }
                            }

                        }
                    }
                }



                Console.WriteLine("### 开始测试 多对多 的延迟加载！ ###");

                foreach (test_student m in context.test_student)
                {
                    Console.WriteLine("学生 = {0}:{1}", m.student_code, m.student_name);
                    // 下面使用 延迟加载， 自动取查询 test_score
                    if (m.test_score != null)
                    {
                        foreach (test_score s in m.test_score)
                        {
                            Console.WriteLine("----- 成绩 = {0}:{1}:{2}", s.course_code, s.test_course.course_name, s.score_value );
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
                foreach (test_main m in context.test_main.Where(p => p.id < 100))
                {
                    Console.WriteLine("Main = {0}:{1}", m.id, m.value);
                    if (m.test_sub != null)
                    {
                        // 注意：
                        //    使用 非延迟加载的， 结果不是 NULL, 是一个空白列表.
                        foreach (test_sub s in m.test_sub)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.id, s.value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("m.test_sub  is  null...");
                    }


                    // 三层的这里就不测试了......


                    Console.WriteLine("测试 IsLoaded 的判断");

                    // 在 不使用 延迟加载 的情况下，
                    // 可以通过  IsLoaded / Load 来手动加载.
                    if (!m.test_sub.IsLoaded)
                    {
                        m.test_sub.Load();
                        foreach (test_sub s in m.test_sub)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.id, s.value);
                        }

                    }


                    // 三层的这里就不测试了......
                }






                Console.WriteLine();
                Console.WriteLine("Include 方式查询 test_main！");


                // 这里使用 贪婪加载.
                // 请注意：
                // 1、如果一个 主表， 同时关联有很多套子表， 那么可以通过  Include("子表1").Include("子表2").Include("子表3") 的方式， 来进行加载.
                // 2、当表的层级结构是多层的时候，例如 爷爷-父亲-孙子 ， 那么需要通过 爷爷.Include("父亲.孙子") 的方式来处理。
                foreach (test_main m in context.test_main.Include("test_sub").Include("test_sub_s.test_sub_of_sub").Where(p => p.id < 100))
                {
                    Console.WriteLine("Main = {0}:{1}", m.id, m.value);
                    if (m.test_sub != null)
                    {
                        foreach (test_sub s in m.test_sub)
                        {
                            Console.WriteLine("----- Sub = {0}:{1}", s.id, s.value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("m.test_sub  is  null...");
                    }




                    Console.WriteLine("========================================");

                    // 测试三层的.
                    if (m.test_sub_s != null)
                    {
                        foreach (test_sub_s s in m.test_sub_s)
                        {
                            Console.WriteLine("----- Sub_S = {0}:{1}", s.id, s.value);

                            if (s.test_sub_of_sub != null)
                            {
                                foreach (test_sub_of_sub ss in s.test_sub_of_sub)
                                {
                                    Console.WriteLine("---------- Sub_S = {0}:{1}", ss.id, ss.value);
                                }
                            }

                        }
                    }
                }


                
                
                Console.WriteLine();
                Console.WriteLine("多对多关系，Include 多层次 查询！");

                foreach (test_student m in context.test_student.Include("test_score.test_course"))
                {
                    Console.WriteLine("学生 = {0}:{1}", m.student_code, m.student_name);
                    // 下面使用 延迟加载， 自动取查询 test_score
                    if (m.test_score != null)
                    {
                        foreach (test_score s in m.test_score)
                        {
                            Console.WriteLine("----- 成绩 = {0}:{1}:{2}", s.course_code, s.test_course.course_name, s.score_value);
                        }
                    }



                }


                Console.WriteLine();
                Console.WriteLine("多对多关系，Include 多表 查询！");
                foreach (test_score s in context.test_score.Include("test_student").Include("test_course"))
                {

                    Console.WriteLine("学生 = {0}  课程 = {1}  成绩 = {2} ", 
                        s.test_student.student_name,
                        s.test_course.course_name,
                        s.score_value);
                }


            }

        }
    }

}
