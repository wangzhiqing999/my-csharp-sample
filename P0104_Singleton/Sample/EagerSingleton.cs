using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0104_Singleton.Sample
{
    /// <summary>
    /// 饿汉式 单例类.
    /// </summary>
    public class EagerSingleton
    {
        /// <summary>
        /// 单例模式的 静态内部实例.
        /// 
        /// 饿汉式 的处理机制， 就是在类被加载的时候，静态变量就被初始化好了.
        /// </summary>
        private static readonly EagerSingleton m_instance = new EagerSingleton();

        /// <summary>
        /// 对于 单例类.
        /// 构造函数需要设置为私有。
        /// 
        /// 以避免外部类 new 一个.
        /// 
        /// 同时。由于 构造函数是 私有的，因此这个类也不能被继承.
        /// </summary>
        private EagerSingleton()
        {
        }


        /// <summary>
        /// 对于 单例模式 
        /// 需要有一个 静态的 方法，获取实例.
        /// </summary>
        /// <returns></returns>
        public static EagerSingleton GetInstance()
        {
            return m_instance;
        }



        /// <summary>
        /// 用于测试 是否单例的属性.
        /// </summary>
        public int DemoCount { set; get; }

    }

}
