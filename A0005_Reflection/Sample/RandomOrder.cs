using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0005_Reflection.Sample
{

    /// <summary>
    /// 一个用于测试泛型方法的例子.
    /// 
    /// 功能是 随机排序.
    /// </summary>
    class RandomOrder<T>
    {
        /// <summary>
        /// 随机排序处理.
        /// </summary>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public List<T> DoRandomOrder(List<T> paramList)
        {
            // 随机排序.
            var query =
                from data in paramList
                orderby Guid.NewGuid()
                select data;

            return query.ToList();
        }

    }
}
