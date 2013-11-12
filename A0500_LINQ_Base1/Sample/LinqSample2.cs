using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0500_LINQ.Sample
{

    /// <summary>
    /// 简单的 LINQ 处理二维数组的例子
    /// </summary>
    class LinqSample2
    {

        /// <summary>
        /// 最基本的演示
        /// </summary>
        public void BaseDemo()
        {
            Console.WriteLine("==========  基本的二维数组查询  =========="); 


            // 二维数组.
            int[,] myArray = new int[10, 10];

            // 初始华 0-99.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    myArray[i, j] = i * 10 + j;
                }
            }


            // 检索 二维数组中的每一个数据.
            var intQuery = 
                from i in myArray.Cast<int>()
                where i > 50 && i <= 60
                select i;

            foreach (int i in intQuery)
            {
                Console.WriteLine(i);  
            }

        }

    }

}
