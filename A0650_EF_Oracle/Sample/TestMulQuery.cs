using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0650_EF_Oracle.Sample
{

    /// <summary>
    /// 测试  未保存， 重复查询.
    /// </summary>
    public class TestMulQuery
    {


        /// <summary>
        /// 测试多次重复查询.
        /// </summary>
        public static void DoTest()
        {

            using (TestEntities context = new TestEntities())
            {
                Console.WriteLine("测试多次重复更改/查询 Start!");


                for (int i = 0; i < 10; i++)
                {

                    // 取得 数据库的序列号数据.
                    TEST_SEQUENCE sequence = context.TEST_SEQUENCE.FirstOrDefault(p => p.TABLE_NAME == "test_main");

                    // 获取序列号.
                    decimal newSeq = sequence.SEQUENCE_NUMBER;

                    // 更新序列号表.
                    sequence.SEQUENCE_NUMBER++;

                    Console.WriteLine("sequence = " + newSeq);


                    
                    // 注意： 这里修改了数据以后， 并没有  context.SaveChanges();  提交保存.
                    // 将循环回去， 再做 FirstOrDefault 查询.
                }


                Console.WriteLine("测试多次重复更改/查询 Finish! (本方法未执行 context.SaveChanges() )");
            }

        }


    }


}
