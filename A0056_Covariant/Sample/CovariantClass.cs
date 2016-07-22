using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0056_Covariant.Sample
{

    /// <summary>
    /// 这里是定义一个   支持 协变 的接口.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICovariantAble<out T> {


        /// <summary>
        /// 注意： 由于要支持协变， 接口这里定义的时候， 属性不能有  set;
        /// </summary>
        T Data { get; }

        void PrintData();
    }


    /// <summary>
    /// 实现接口的类.
    /// </summary>
    public class CovariantClass<T> : ICovariantAble<T>
    {

        #region ICovariantAble<T> 成员

        public T Data {get; set;}


        public void PrintData()
        {
            Console.WriteLine(Data.ToString());
        }

        #endregion
    }

}
