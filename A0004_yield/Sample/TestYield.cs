using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace A0004_yield.Sample
{
    class TestYield
    {


        /// <summary>
        /// 使用  yield  的例子.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetDataListWithYield()
        {
            for (int i = 0; i < 10; i++)
            {
                // 这里模拟一个操作
                // 假设 这个方法， 对于每一行数据，都要花费一段时间处理， 才能返回.
                Thread.Sleep(1000);


                // 加这一行的目的， 是为了测试， 外部的 for each 中断的时候， 会不会中断内部的处理.
                // 相当于：一大堆的 CheckList, 必须全部检查合格了，才能通过。
                // 当按顺序，检查到第一个不合格的情况下，就可以直接中断了。
                // 不需要检查全部之后，再列出来，哪几个合格，哪几个不合格。
                Console.WriteLine($"yield return {i}");


                yield return i;
            }
        }




        /// <summary>
        /// 不使用  yield  的例子.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetDataListWithoutYield()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                // 这里模拟一个操作
                // 假设 这个方法， 对于每一行数据，都要花费一段时间处理， 才能返回.
                Thread.Sleep(1000);
                result.Add(i);
            }
            return result;
        }

    }
}
