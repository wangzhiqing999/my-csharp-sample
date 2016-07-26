using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0660_EF_MySql.Sample;


namespace A0660_EF_MySql
{
    class Program
    {
        static void Main(string[] args)
        {

            // 测试延迟加载.
            TestLazyLoading.DoTest();


            // 测试自动递增列.
            TestAutoIncrement.DoTest();


            // 测试 存储过程
            TestCallProcedure.DoTest();


            // 测试  中文汉字.
            TestUtf8.DoTest();


            Console.ReadLine();
        }
    }
}
