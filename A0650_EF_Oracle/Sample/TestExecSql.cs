using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0650_EF_Oracle.Sample
{


    /// <summary>
    /// 测试在 Entity Framework 中， 直接执行 SQL 语句.
    /// </summary>
    class TestExecSql
    {


        /// <summary>
        /// 用于 动态执行的 SQL 语句.
        /// </summary>
        private const string testSql = @"select
  s.id		as id,
  m.value 	as main_value, 
  s.value 	as sub_value
from
  test_main  m
    join test_sub  s
      on (m.id = s.main_id) ";


        
        /// <summary>
        /// 测试.
        /// </summary>
        public static void DoTest()
        {

            Console.WriteLine("测试 直接执行 SQL 语句！");

            using (TestEntities context = new TestEntities())
            {


                // 通过下面这种方式， 执行一个 SQL 语句.
                // 要求 SQL 查询返回的结果形式， 要是一个 Entity类。
                // 这里的做法是， 根据查询的结果字段， 去数据库建一个空的表，然后导入到 EntityFramework 的 edmx 文件中.
                var query =
                    context.ExecuteStoreQuery<QUERY_RESULT_MAIN_AND_SUB>(testSql);


                foreach (QUERY_RESULT_MAIN_AND_SUB result in query)
                {
                    Console.WriteLine(
                        "直接执行 SQL 语句结果：MainVal = {0}， SubVal = {1} ",
                        result.MAIN_VALUE, 
                        result.SUB_VALUE );
                }


            }

            Console.WriteLine("测试 直接执行 SQL 语句 结束！");
            Console.WriteLine();
        }



    }
}
