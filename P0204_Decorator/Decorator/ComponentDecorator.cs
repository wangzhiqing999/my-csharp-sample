using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0204_Decorator.Component;
using P0204_Decorator.ConcreteComponent;


namespace P0204_Decorator.Decorator
{

    /// <summary>
    /// 本类是“装饰”模式的 Decorator（抽象装饰类）
    /// </summary>
    public class ComponentDecorator : Window
    {
        /// <summary>
        /// 维持对抽象构件类型对象的引用
        /// </summary>
        private ComponentUI component;



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="component"> 注入抽象构件类型的对象 </param>
        public ComponentDecorator(ComponentUI component)  
        {
            this.component = component;
        }



        public override void Display()
        {
            component.Display();
        }

    }
}
