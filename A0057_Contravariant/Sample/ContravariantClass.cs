using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0057_Contravariant.Sample
{

    /// <summary>
    /// 这里是定义一个   支持 逆变 的接口.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContravariantAble<in T>
    {
        void PrintData(T data);
    }



    /// <summary>
    /// 实现接口的类.
    /// </summary>
    public class ContravariantClass<T> : IContravariantAble<T>
    {
        #region IContravariantAble<T> 成员

        public void PrintData(T data)
        {
            Console.WriteLine(data.ToString());
        }

        #endregion
    }
}
