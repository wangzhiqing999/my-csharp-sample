﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using A0662_EF_MySql_Work.DataAccess;
using A0662_EF_MySql_Work.Model;


namespace A0662_EF_MySql_Work.Sample
{


    public class TestRowVersion
    {



        /// <summary>
        /// 初始化测试数据.
        /// </summary>
        public void InitTestWorkData()
        {

            using (MyWorkContext context = new MyWorkContext())
            {
                TestWorkData testWorkData = context.TestWorkDatas.Find("TEST");
                if (testWorkData == null)
                {
                    testWorkData = new TestWorkData()
                    {
                        Code = "TEST",
                    };

                    context.TestWorkDatas.Add(testWorkData);
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
            try
            {
                using (MyWorkContext context = new MyWorkContext())
                {
                    TestWorkData testWorkData = context.TestWorkDatas.Find("TEST");
                    Console.WriteLine($"----- 测试更新工作数据1 {testWorkData.WorkValue} -----");

                    testWorkData.WorkValue++;

                    // 模拟耗时操作.
                    Thread.Sleep(1000);
                    context.SaveChanges();
                }

                Console.WriteLine($"----- 测试更新工作数据1 成功 -----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试更新工作数据1发生异常：{ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }



        public void UpdateWorkValue2()
        {
            try
            {
                using (MyWorkContext context = new MyWorkContext())
                {
                    TestWorkData testWorkData = context.TestWorkDatas.Find("TEST");
                    Console.WriteLine($"----- 测试更新工作数据2 {testWorkData.WorkValue2} -----");

                    testWorkData.WorkValue2++;

                    // 模拟耗时操作.
                    Thread.Sleep(1000);
                    context.SaveChanges();
                }

                Console.WriteLine($"----- 测试更新工作数据2 成功 -----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试更新工作数据2发生异常：{ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }



    }
}
