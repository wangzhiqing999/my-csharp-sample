using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0104_Singleton.Sample
{

    /// <summary>
    /// 懒汉式 单例类.
    /// </summary>
    public class LazySingleton
    {

        /// <summary>
        /// 单例模式的 静态内部实例.
        /// </summary>
        private static LazySingleton m_instance = null;

                /// <summary>
        /// 对于 单例类.
        /// 构造函数需要设置为私有。
        /// 
        /// 以避免外部类 new 一个.
        /// 
        /// 同时。由于 构造函数是 私有的，因此这个类也不能被继承.
        /// </summary>
        private LazySingleton()
        {
        }

        /// <summary>
        /// 对于 单例模式 
        /// 需要有一个 静态的 方法，获取实例.
        /// </summary>
        /// <returns></returns>
        public static LazySingleton GetInstance()
        {
            // 懒汉式 的处理机制， 就是当调用 获取实例函数的时候， 去判断。
            // 数据到底有没有初始化。
            // 如果没有，那么 做一次初始化的处理操作。
            if (m_instance == null)
            {
                m_instance = new LazySingleton();
            }
            return m_instance;
        }



        /// <summary>
        /// 用于测试 是否单例的属性.
        /// </summary>
        public int DemoCount { set; get; }


    }

}
