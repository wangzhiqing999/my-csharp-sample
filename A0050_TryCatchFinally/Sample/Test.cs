using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0050_TryCatchFinally.Sample
{
    class Test
    {


        /// <summary>
        /// 测试基本的 try / catch / finally 逻辑.
        /// </summary>
        public void TestBase()
        {
            Console.WriteLine("测试基本的 try  catch  finally 逻辑.");

            int i = 1;
            try
            {
                // 触发一个 除0错误.
                i = i / (i - 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally Code.....");
            }
        }




        /// <summary>
        /// 测试 在 try 中，不触发异常，return, 依然可以执行到 finally 的代码.
        /// </summary>
        /// <returns></returns>
        public int TestReturn()
        {
            Console.WriteLine("测试在 try 中，不触发异常，return, 依然可以执行到 finally 的代码..");

            int i = 1;
            try
            {
                i++ ;
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally Code.....");
            }
            return i;
        }


    }

}
