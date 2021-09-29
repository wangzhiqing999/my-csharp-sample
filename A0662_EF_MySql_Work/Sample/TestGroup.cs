using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A0662_EF_MySql_Work.DataAccess;
using A0662_EF_MySql_Work.Model;

namespace A0662_EF_MySql_Work.Sample
{


    /// <summary>
    /// 测试 EF 中分组的操作.
    /// </summary>
    public class TestGroup
    {


        /// <summary>
        /// 测试获取分组中， 最新的一行数据.
        /// </summary>
        public void TestLastData()
        {
            Console.WriteLine("----- 获取每个用户， 最近一次访问 X 模块的数据 -----");

            using (MyWorkContext context = new MyWorkContext())
            {

                // 这里是基本查询条件.
                var query =
                    from data in context.TestAccessLogs
                    where
                        data.AccessModule == "X"
                    select data;


                // 这里是 分组， 并查询最新的处理。
                query = query.GroupBy(t => t.UserCode)
                            .Select(gt => gt.FirstOrDefault(p1 => p1.AccessTime == gt.Max(p2 => p2.AccessTime)));


                foreach (TestAccessLog item in query.Take(3))
                {
                    Console.WriteLine(item.ToString());
                }
            }


            Console.WriteLine();

        }



    }
}


// 数据库测试数据.

/*
--测试用户 A、B、C
-- 测试模块 X、Y、Z
INSERT INTO `test_access_log`(
	`user_code`,`access_time`,`access_module`
)
SELECT 'A', '2021-09-01', 'X'  UNION ALL
SELECT 'A', '2021-09-02', 'X'  UNION ALL
SELECT 'A', '2021-09-03', 'X'  UNION ALL
SELECT 'A', '2021-09-04', 'X'  UNION ALL
SELECT 'A', '2021-09-05', 'X'  UNION ALL
SELECT 'A', '2021-09-01', 'Y'  UNION ALL
SELECT 'A', '2021-09-02', 'Y'  UNION ALL
SELECT 'A', '2021-09-03', 'Y'  UNION ALL
SELECT 'A', '2021-09-04', 'Y'  UNION ALL
SELECT 'A', '2021-09-05', 'Y'  UNION ALL
SELECT 'A', '2021-09-01', 'Z'  UNION ALL
SELECT 'A', '2021-09-02', 'Z'  UNION ALL
SELECT 'A', '2021-09-03', 'Z'  UNION ALL
SELECT 'A', '2021-09-04', 'Z'  UNION ALL
SELECT 'A', '2021-09-05', 'Z'
;


INSERT INTO `test_access_log`(
	`user_code`,`access_time`,`access_module`
)
SELECT 'B', '2021-09-01', 'X'  UNION ALL
SELECT 'B', '2021-09-02', 'X'  UNION ALL
SELECT 'B', '2021-09-03', 'X'  UNION ALL
SELECT 'B', '2021-09-04', 'X'  UNION ALL
SELECT 'B', '2021-09-05', 'X'
;


INSERT INTO `test_access_log`(
	`user_code`,`access_time`,`access_module`
)
SELECT 'C', '2021-09-01', 'X'  UNION ALL
SELECT 'C', '2021-09-02', 'X'  UNION ALL
SELECT 'C', '2021-09-03', 'X'
;
*/
