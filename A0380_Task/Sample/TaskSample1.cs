using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;




namespace A0380_Task.Sample
{
    class TaskSample1
    {

        private static Random r = new Random();


        /// <summary>
        /// 测试异步执行的方法.
        /// 
        /// 这个方法，定义的地方，被加上了 async 关键字.
        /// 
        /// async 的作用是异步执行.
        /// </summary>
        public static async void DoTest1()
        {

            // 先定义 Task.
            Task<int> t = new Task<int>(() => {
                Thread.Sleep(2000);

                return r.Next(100); 
            });

            // 执行 Task.
            t.Start();



            // await的作用是等待执行结果（会卡住异步方法中await以下的代码，但不会卡死主线程）。
            int val = await t;


            Console.WriteLine("DoTest1 Result = {0}", val);
        }







        /// <summary>
        /// 测试异步执行的方法.
        /// 
        /// 这个方法，定义的地方，被加上了 async 关键字.
        /// 
        /// async 的作用是异步执行.
        /// </summary>
        public static async void DoTest2()
        {

            // 定义 Task 并执行.
            var t = Task<int>.Run(() => { 
                Thread.Sleep(2000);                
                return r.Next(100); 
            });



            // await的作用是等待执行结果（会卡住异步方法中await以下的代码，但不会卡死主线程）。
            int val = await t;


            Console.WriteLine("DoTest2 Result = {0}", val);
        }  


    }

}
