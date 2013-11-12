using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0530_LINQ_SQL.Sample;

namespace A0530_LINQ_SQL
{
	class Program
	{
		/// <summary>
		/// SQL Server 的数据库连接字符串.
		/// </summary>
		private const String connString =
			@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestLinq2Sql;Integrated Security=True";



		static void Main(string[] args)
		{
            // 基本功能测试.
            BaseTest();

            // 事务处理的测试. 
            TransactionTest();

            // 动态查询的测试.
            IQueryableTest(null, null);
            IQueryableTest(1, null);
            IQueryableTest(null, "ONE");
            IQueryableTest(1, "ONE");

            // 手动执行SQL.
            ExecuteQueryTest();
            ExecuteCommandTest();


            // 测试单表 identity 处理.
            TestIdeneity();

            // 测试调存储过程.
            CallProc();

            // 测试调函数
            CallFunc();

            Console.ReadLine();
		}



        /// <summary>
        /// Linq2SQL 基本功能测试
        /// 
        /// 基本的 查询 / 插入 / 更新 / 删除 处理.
        /// 
        /// </summary>
        private static void BaseTest()
        {
            Test context = new Test(connString);






            // 单表查询
            var query =
                from testMain in context.TestMain
                select testMain;
            foreach (TestMain main in query)
            {
                Console.WriteLine("Main[{0}, {1}]", main.Id, main.Value);
            }

            // 关联查询
            var query2 =
                from testSub in context.TestSub
                where testSub.TestMain.Value == "ONE"
                select testSub;
            foreach (TestSub sub in query2)
            {
                Console.WriteLine("Sub[{0}, {1}]", sub.Id, sub.Value);
            }

            // 插入.
            TestMain main3 = new TestMain();
            main3.Id = 3;
            main3.Value = "Three";
            context.TestMain.InsertOnSubmit(main3);
            context.SubmitChanges();

            Console.WriteLine("INSERT FINISH! --- Please Press Enter Ket");
            Console.ReadLine();

            // 更新.
            var newTestMain =
                (from testMain in context.TestMain
                 where testMain.Id == 3
                 select testMain).First();
            newTestMain.Value = "Three3";
            context.SubmitChanges();

            Console.WriteLine("UPDATE FINISH!  --- Please Press Enter Ket");
            Console.ReadLine();


            // 单表查询 TOP 2
            var queryTop2 =
                (from testMain in context.TestMain
                 orderby testMain.Id descending
                 select testMain).Take(2);

            foreach (TestMain main in queryTop2)
            {
                Console.WriteLine("Main[{0}, {1}]", main.Id, main.Value);
            }

            // 删除.
            context.TestMain.DeleteOnSubmit(newTestMain);
            context.SubmitChanges();

            Console.WriteLine("DELETE FINISH! --- Please Press Enter Ket");
            Console.ReadLine();

        }


        /// <summary>
        /// 事务处理的测试.
        /// 
        /// 隐式创建事务
        /// 
        /// </summary>
        private static void TransactionTest()
        {
            // 在我们没有显式的开启事务时，
            // DataContext.SubmitChanges在提交时会隐式创建事务

            Test context = new Test(connString);

            try
            {

                // 插入.
                TestMain main3 = new TestMain();
                main3.Id = 3;
                main3.Value = "Three";
                context.TestMain.InsertOnSubmit(main3);


                TestMain main3x = new TestMain();
                main3x.Id = 3;
                main3x.Value = "Three Err";
                context.TestMain.InsertOnSubmit(main3x);


                context.SubmitChanges();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());              
            }


            var query =
               from testMain in context.TestMain
               where testMain.Id == 3
               select testMain;

            Console.WriteLine("TestMain 表中， id=3 的记录有{0}条 ", query.Count());


        }





        /// <summary>
        /// 用于 动态的查询处理.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        private static void IQueryableTest(int? id, string val)
        {
            // 如果 用户只输入了 id， 那么 只 where id = ?
            // 如果 用户只输入了 val， 那么 只 where value = ?
            // 如果 用户 id 和 val 都输入了， 那么 where  id=? and value = ?
            // 如果 用户 id 和 val 都没输入， 那么 where 也不需要了.

            Console.WriteLine("传入的参数：id={0}, val={1}", id, val);


            Test context = new Test(connString);


            // 在控制台窗口中显示生成的 SQL.
            // 当需要做 Debug 处理的时候， 可以这么设置.            
            context.Log = Console.Out;

            IQueryable<TestMain> result = context.TestMain;

            if (id != null)
            {
                result = result.Where(c => c.Id  == id); 
            }
            if (val != null)
            {
                result = result.Where(c => c.Value == val);
            }

            foreach (TestMain data in result)
            {
                Console.WriteLine("Main[{0}, {1}]", data.Id, data.Value);
            }
        }




        /// <summary>
        /// 测试直接执行 SQL 语句.
        /// </summary>
        private static void ExecuteQueryTest()
        {
            Test context = new Test(connString);

            Console.WriteLine("手动执行 SQL : SELECT * FROM test_main WHERE id = 2 ");
            var mainData = context.ExecuteQuery<TestMain>("SELECT * FROM TestMain WHERE id = 2");

            foreach (TestMain data in mainData)
            {
                Console.WriteLine("Main[{0}, {1}]", data.Id, data.Value);
            }
        }




        /// <summary>
        /// 测试直接执行 SQL 语句.
        /// </summary>
        private static void ExecuteCommandTest()
        {
            

            Test context = new Test(connString);


            Console.WriteLine("手动执行 SQL : INSERT INTO TestMain(id, value) VALUES (4, 'FOUR') ");
            int r1 = context.ExecuteCommand("INSERT INTO TestMain(id, value) VALUES (4, 'FOUR') ");
            Console.WriteLine("执行结果：{0}", r1);



            Console.WriteLine("手动执行 SQL : SELECT * FROM TestMain WHERE id = 4 ");
            var mainData = context.ExecuteQuery<TestMain>("SELECT * FROM TestMain WHERE id = 4");
            foreach (TestMain data in mainData)
            {
                Console.WriteLine("Main[{0}, {1}]", data.Id, data.Value);
            }


            Console.WriteLine("手动执行 SQL : DELETE TestMain WHERE  id = 4");
            int r2 = context.ExecuteCommand("DELETE TestMain WHERE  id = 4");
            Console.WriteLine("执行结果：{0}", r2);
        }



        /// <summary>
        /// 测试 Identity 的处理.
        /// </summary>
        private static void TestIdeneity()
        {

            Console.WriteLine("===== 测试父子关系表的 Identity 的处理.");

            using (Test context = new Test(connString))
            {
                test_Identity_tab testMainData = new test_Identity_tab()
                {
                    value = "测试主"
                };

                test_Identity_tab_Sub testSubData = new test_Identity_tab_Sub()
                {
                    Value = "测试子"
                };

                testSubData.test_Identity_tab = testMainData;


                // 插入.
                context.test_Identity_tab.InsertOnSubmit(testMainData);
                context.test_Identity_tab_Sub.InsertOnSubmit(testSubData);

                Console.WriteLine("Before SubmitChanges testMainData.id = {0}", testMainData.id);
                Console.WriteLine("Before SubmitChanges testSubData.id = {0}", testSubData.Id);

                context.SubmitChanges();

                Console.WriteLine("After SubmitChanges testMainData.id = {0}", testMainData.id);
                Console.WriteLine("After SubmitChanges testSubData.id = {0}", testSubData.Id);
            }

        }



        /// <summary>
        /// 调存储过程.
        /// </summary>
        private static void CallProc()
        {
            Console.WriteLine("===== 测试执行存储过程的处理.");

            using (Test context = new Test(connString))
            {
                string outVal = "", inoutVal=" Hello";

                int result = context.HelloWorld2("Edward", ref outVal, ref inoutVal);

                Console.WriteLine("执行存储过程 HelloWorld2， 返回值={0}， out参数1={1}, out参数2={2}",
                    result, outVal, inoutVal);



                // 执行返回结果集的存储过程.
                var query = context.testProc();

                foreach (testProcResult data in query)
                {
                    Console.WriteLine("执行返回结果集的存储过程，执行结果：A={0},B={1}", data.A, data.B);
                }

            }
        }



        /// <summary>
        /// 调函数.
        /// </summary>
        private static void CallFunc()
        {
            Console.WriteLine("===== 测试执行函数的处理.");

            using (Test context = new Test(connString))
            {
                string test = context.HelloWorldFunc();
                Console.WriteLine("调用 HelloWorldFunc， 返回结果={0}", test);


                var query = context.getHelloWorld();
                foreach (getHelloWorldResult data in query)
                {
                    Console.WriteLine("调用返回结果集的函数，返回结果 A={0}; B={1}", data.A, data.B);
                }

            }
        }


	}
}
