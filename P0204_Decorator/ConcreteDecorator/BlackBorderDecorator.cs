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
    public class BlackBorderDecorator : ComponentDecorator
    {
        public BlackBorderDecorator(ComponentUI component)
            : base(component)
        {
        }

        public void setBlackBorder()
        {
            Console.WriteLine("为构件增加黑色边框！");
        }


        public override void Display()
        {
            // 装饰的代码.
            this.setBlackBorder();

            // 原有的代码.
            base.Display();
        }

    }
}
