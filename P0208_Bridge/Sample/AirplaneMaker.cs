using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0208_Bridge.Sample
{

    /// <summary>
    /// 桥梁模式（Bridge） 中的  实现化（Implementor）角色
    /// 
    /// 这个角色给出实现化角色的接口，但不给出具体的实现。
    /// 必须指出的是，这个接口不一定和抽象化角色的接口定义相同，实际上，这两个接口可以非常不一样。
    /// 实现化角色应当只给出底层操作，而抽象化角色应当们给出基于底层操作的更高一层的操作。
    /// 
    /// 
    /// 飞机制造商实现
    /// </summary>
    public abstract class AirplaneMaker
    {

        /// <summary>
        /// 获取制造商名称.
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();


        /// <summary>
        /// 获取发动机
        /// </summary>
        /// <returns></returns>
        public abstract string GetEngine();


        /// <summary>
        /// 获取起落架.
        /// </summary>
        /// <returns></returns>
        public abstract string GetLandingGear();

    }

}
