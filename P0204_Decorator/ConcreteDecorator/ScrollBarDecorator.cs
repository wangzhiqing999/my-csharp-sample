using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0204_Decorator.Component;
using P0204_Decorator.Decorator;

namespace P0204_Decorator.ConcreteDecorator
{
    /// <summary>
    /// 本类是“装饰”模式的 ConcreteDecorator（具体装饰类）
    /// 
    /// 滚动条装饰类
    /// </summary>
    public class ScrollBarDecorator : ComponentDecorator
    {
        public ScrollBarDecorator(ComponentUI component)
            : base(component)
        {
        }


        public void setScrollBar()
        {
            Console.WriteLine("为构件增加滚动条！");
        }


        public override void Display()
        {
            // 装饰的代码.
            this.setScrollBar();

            // 原有的代码.
            base.Display();
        }

    }


}
