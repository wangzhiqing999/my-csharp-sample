using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0055_GenericMethod.Sample
{


    /// <summary>
    /// 这里测试的， 是单纯 泛型方法， 因此， 类的定义这里， 没有 T .
    /// </summary>
    class RandomAdd
    {


        /// <summary>
        /// 这里定义的是  泛型方法.
        /// 
        /// where T : ICollection<Int32> 意味着， T 需要实现 ICollection<Int32>
        /// 后面的 new()  则是意味着， 在后续的代码中， 允许使用  new T() 这样的操作.
        /// 
        /// 注意：T 实现接口或者继承类的时候， 如果还允许 new() ， new () 要写在最后。
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetRandomData<T>() where T : ICollection<Int32>, new()
        {
            var result = new T();
            Random r = new Random();
            for (int i =0; i < 10; i++)
            {
                result.Add(r.Next());
            }            
            return result;            
        }


        /// <summary>
        /// 这里定义的是  泛型方法.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public static void ShowRandomData<T>(T data) where T : ICollection<Int32>
        {
            Console.WriteLine(data.GetType().Name);
            foreach (var x in data)
            {
                Console.WriteLine(x);
            }
        }


    }
}
