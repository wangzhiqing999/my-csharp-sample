using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0204_Decorator.Component;

namespace P0204_Decorator.ConcreteComponent
{

    /// <summary>
    /// 本类是“装饰”模式的 ConcreteComponent（具体构件）
    /// 窗口.
    /// </summary>
    public class Window : ComponentUI
    {
        public override void Display()
        {
            Console.WriteLine("显示窗体!");
        }
    }


    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox : ComponentUI
    {
        public override void Display()
        {
            Console.WriteLine("显示文本框!");
        }
    }


    /// <summary>
    /// 列表框
    /// </summary>
    public class ListBox: ComponentUI
    {
        public override void Display()
        {
            Console.WriteLine("显示列表框!");
        }
    }

}
