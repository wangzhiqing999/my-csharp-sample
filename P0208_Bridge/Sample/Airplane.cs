using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0208_Bridge.Sample
{
    
    /// <summary>
    /// 桥梁模式（Bridge） 中的  抽象化（Abstraction）角色：
    /// 
    /// 抽象化给出的定义，并保存一个对实现化对象的引用。
    /// 
    /// 
    /// 飞机抽象类.
    /// </summary>
    public abstract class Airplane
    {
        /// <summary>
        /// 飞行的 抽象方法
        /// </summary>
        public abstract void Fly();


        /// <summary>
        /// 对实现化对象的引用。
        /// </summary>
        protected AirplaneMaker airplaneMaker;

    }


}
