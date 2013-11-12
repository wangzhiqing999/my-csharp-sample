using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0500_LINQ.Sample
{


    /// <summary>
    /// 简单的 LINQ 例子
    /// </summary>
    class LinqSample
    {


        /// <summary>
        /// 最基本的演示
        /// </summary>
        public void BaseDemo()
        {
            Console.WriteLine("[01]LINQ 需要三个部分： 数据源、查询、查询的执行。");
            
            //  这里是数据源，一个 int 数组.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("LINQ 数据源：");
            foreach (int num in numbers)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine();


            
            // 这里创建一个 LINQ 的查询.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            Console.WriteLine("[01]LINQ 查询：");
            Console.WriteLine("  from num in numbers ");
            Console.WriteLine("  where (num % 2) == 0 ");
            Console.WriteLine("  select num; ");



            // 这里执行 LINQ 查询，显示结果：
            Console.WriteLine("[01]LINQ 查询结果：");
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine();





            // 这里直接使用 where
            var numQuery2 = numbers.Where(num => num % 2 == 0);

            Console.WriteLine("[01]LINQ 查询： Where(num => num % 2 == 0)");

            // 这里执行 LINQ 查询，显示结果：
            Console.WriteLine("[01]LINQ 查询结果：");
            foreach (int num in numQuery2)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine();



        }



        /// <summary>
        /// 进一步的演示说明
        /// </summary>
        public void BaseDemo2()
        {
            //  这里是数据源，一个 int 数组.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 在 LINQ 中，查询的执行与查询本身截然不同；换句话说，如果只是创建查询变量，则不会检索任何数据。
            // 在上面一个例子里面
            // 查询执行的时间，是在 foreach 的时候，才开始处理的

            // 这里演示的是 “强制立即执行”

            var evenNumQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            int evenNumCount = evenNumQuery.Count();
            int sumNum = evenNumQuery.Sum();
            int maxNum = evenNumQuery.Max();
            int minNum = evenNumQuery.Min();
            double avgNum = evenNumQuery.Average();

            int firstNum = evenNumQuery.First();
            int lastNum = evenNumQuery.Last();

            Console.WriteLine("[02] LINQ 使用 Count() 执行的结果为：{0}", evenNumCount);
            Console.WriteLine("[02] LINQ 使用 Sum() 执行的结果为：{0}", sumNum);
            Console.WriteLine("[02] LINQ 使用 Max() 执行的结果为：{0}", maxNum);
            Console.WriteLine("[02] LINQ 使用 Min() 执行的结果为：{0}", minNum);
            Console.WriteLine("[02] LINQ 使用 Average() 执行的结果为：{0}", avgNum);

            Console.WriteLine("[02] LINQ 使用 First() 执行的结果为：{0}", firstNum);
            Console.WriteLine("[02] LINQ 使用 Last() 执行的结果为：{0}", lastNum);



            // 这里在 定义 LINQ 查询的同时，就执行查询，并把结果存储到 列表中.
            List<int> numQuery2 =
                (from num in numbers
                 where (num % 2) == 0
                 select num).ToList();

            Console.WriteLine("[02]LINQ 定义时直接 ToList() 的结果为：{0}", numQuery2);
            

        }






        
        /// <summary>
        /// 进一步的演示  翻页处理.
        /// </summary>
        public void BaseDemo3()
        {
            Console.WriteLine("==========  翻页处理  =========="); 

            // 初始化一个  长度为 100 的数组.
            int[] testArray = Enumerable.Range(1, 100).ToArray();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("第{0}页", i+1);
                List<int> pageDataList = testArray.Skip( i * 10).Take(10).ToList();

                foreach (int val in pageDataList)
                {
                    Console.Write("{0}   ", val);
                }
                Console.WriteLine();
            }



        }





        /// <summary>
        /// 进一步的演示  随机排序.
        /// </summary>
        public void BaseDemo4()
        {
            Console.WriteLine("==========  随机排序 Top 10.  ==========");

            // 初始化一个  长度为 100 的数组.
            int[] testArray = Enumerable.Range(1, 100).ToArray();

            var query =
                from data in testArray
                orderby Guid.NewGuid()
                select data;


            List<int> top10DataList = query.Take(10).ToList();

            foreach (int val in top10DataList)
            {
                Console.Write("{0}   ", val);
            }
            Console.WriteLine();
        }

    }
}
