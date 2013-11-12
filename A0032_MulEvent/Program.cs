using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0032_MulEvent.Sample;

namespace A0032_MulEvent
{
    class Program
    {

        /// <summary>
        /// 事件的操作代码.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="obj"></param>
        /// <param name="cancel"></param>
        private static void MyAgeChangeHandler1(int age, object obj, ref bool cancel)
        {
            Console.WriteLine("事件被触发！不能小于零！");

            if (age < 0)
            {
                Console.WriteLine("年龄小于0，不允许修改！");
                cancel = true;
            }
        }

        /// <summary>
        /// 事件的操作代码.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="obj"></param>
        /// <param name="cancel"></param>
        private static void MyAgeChangeHandler2(int age, object obj, ref bool cancel)
        {
            Console.WriteLine("事件被触发！不能大于150！");

            if (age > 150)
            {
                Console.WriteLine("年龄大于150，不允许修改！");
                cancel = true;
            }
        }


        /// <summary>
        /// 事件的操作代码.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="obj"></param>
        /// <param name="cancel"></param>
        private static void MyAgeChangeHandler3(int age, object obj, ref bool cancel)
        {
            Console.WriteLine("事件被触发！ 我只是个日志！ ");            
        }




        static void Main(string[] args)
        {
            Console.WriteLine("=====注册了事件处理的=====");
            // 构造类.
            Person p1 = new Person();
            // 注册事件.
            p1.AgeChange += new AgeChangeHandler(MyAgeChangeHandler1);
            p1.AgeChange += new AgeChangeHandler(MyAgeChangeHandler2);
            p1.AgeChange += new AgeChangeHandler(MyAgeChangeHandler3);

            Console.WriteLine("准备调用 Age = 250");
            p1.Age = 250;
            Console.WriteLine("调用后Age = {0}", p1.Age);

            Console.WriteLine("准备调用 Age = -1");
            p1.Age = -1;
            Console.WriteLine("调用后Age = {0}", p1.Age);

            Console.ReadLine();
        }
    }
}
