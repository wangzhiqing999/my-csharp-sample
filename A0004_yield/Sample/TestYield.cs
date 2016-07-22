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
            for (int i = 0; i < 5; i++)
            {
                // 这里模拟一个操作
                // 假设 这个方法， 对于每一行数据，都要花费一段时间处理， 才能返回.
                Thread.Sleep(1000);
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
            for (int i = 0; i < 5; i++)
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
