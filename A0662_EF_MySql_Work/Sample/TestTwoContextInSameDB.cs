using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using A0662_EF_MySql_Work.DataAccess;
using A0662_EF_MySql_Work.Model;
using System.Configuration;

namespace A0662_EF_MySql_Work.Sample
{


    /// <summary>
    /// 测试两个 Context 在同一个数据库上的操作.
    /// </summary>
    public class TestTwoContextInSameDB
    {

        /// <summary>
        /// 初始化测试数据.
        /// </summary>
        public void InitTestWorkData()
        {

            using (MyWorkContext context = new MyWorkContext())
            {
                TestWorkData testWorkData = context.TestWorkDatas.Find("TEST_TWO");
                if (testWorkData == null)
                {
                    testWorkData = new TestWorkData()
                    {
                        Code = "TEST_TWO",
                    };

                    context.TestWorkDatas.Add(testWorkData);
                    context.SaveChanges();
                    return;
                }

                testWorkData.WorkValue = 0;
                testWorkData.WorkValue2 = 0;

                context.SaveChanges();
            }


            using (MyWork2Context context = new MyWork2Context())
            {
                TestWorkData2 testWorkData = context.TestWorkData2s.Find("TEST_TWO");
                if (testWorkData == null)
                {
                    testWorkData = new TestWorkData2()
                    {
                        Code = "TEST_TWO",
                    };

                    context.TestWorkData2s.Add(testWorkData);
                    context.SaveChanges();
                    return;
                }

                testWorkData.WorkValue = 0;
                testWorkData.WorkValue2 = 0;

                context.SaveChanges();
            }


        }






        public void UpdateWorkValue()
        {

            Console.WriteLine($"----- 测试更新 模块1 与 模块2 的工作数据-----");

            try
            {

                string connString = ConfigurationManager.ConnectionStrings["MyWorkContext"].ToString();

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        using (MyWorkContext context1 = new MyWorkContext(conn))
                        {
                            context1.Database.UseTransaction(transaction);
                            TestWorkData testWorkData = context1.TestWorkDatas.Find("TEST_TWO");                            
                            testWorkData.WorkValue++;
                            context1.SaveChanges();
                        }

                        using (MyWork2Context context2 = new MyWork2Context(conn))
                        {
                            context2.Database.UseTransaction(transaction);
                            TestWorkData2 testWorkData2 = context2.TestWorkData2s.Find("TEST_TWO");
                            testWorkData2.WorkValue++;
                            context2.SaveChanges();
                        }

                        Console.WriteLine("--- COMMIT ---");
                        transaction.Commit();
                    }
                }

                Console.WriteLine($"----- 测试更新工作数据 成功 -----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试更新工作数据发生异常：{ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }







        public void UpdateWorkValue2()
        {

            Console.WriteLine($"----- 测试更新 模块1 与 模块2 的工作数据-----");
            Console.WriteLine($"----- 测试前一个处理成功，后一个处理失败，最终回滚的情况 -----");

            try
            {

                string connString = ConfigurationManager.ConnectionStrings["MyWorkContext"].ToString();

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        using (MyWorkContext context1 = new MyWorkContext(conn))
                        {
                            context1.Database.UseTransaction(transaction);
                            TestWorkData testWorkData = context1.TestWorkDatas.Find("TEST_TWO");
                            testWorkData.WorkValue2++;
                            context1.SaveChanges();
                        }

                        using (MyWork2Context context2 = new MyWork2Context(conn))
                        {
                            context2.Database.UseTransaction(transaction);
                            TestWorkData2 testWorkData2 = new TestWorkData2()
                            {
                                Code = "TEST_TWO",
                                WorkValue2 = 1,
                            };

                            context2.TestWorkData2s.Add(testWorkData2);

                            // 这里主键冲突，将导致异常，最终回滚掉.
                            context2.SaveChanges();
                        }

                        Console.WriteLine("--- COMMIT ---");
                        transaction.Commit();
                    }
                }

                Console.WriteLine($"----- 测试更新工作数据 成功 -----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试更新工作数据发生异常：{ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }





    }
}
