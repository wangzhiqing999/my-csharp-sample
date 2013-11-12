using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0204_Decorator.Component
{
    /// <summary>
    /// 本类是“装饰”模式的 Component（抽象构件）
    /// </summary>
    public abstract class ComponentUI
    {

        /// <summary>
        /// 显示.
        /// </summary>
        public abstract void Display();

    }
}
