using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0204_Decorator.Component;
using P0204_Decorator.ConcreteComponent;
using P0204_Decorator.ConcreteDecorator;


namespace P0204_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();


            Console.WriteLine("---------- 追加需求后的处理 ----------");


            Test2();

            Console.ReadLine();
        }


        /// <summary>
        /// 初始状况.
        /// </summary>
        private static void Test1()
        {
            // 使用抽象构件定义
            ComponentUI component, componentSB;
            // 定义具体构件
            component = new Window();
            // 定义装饰后的构件
            componentSB = new ScrollBarDecorator(component);

            // 显示.
            componentSB.Display();
        }


        /// <summary>
        /// 增加需求后的修改代码.
        /// </summary>
        private static void Test2()
        {
            //全部使用抽象构件定义
            ComponentUI component, componentSB, componentBB;
            // 定义具体构件
            component = new Window();
            // 定义装饰后的构件
            componentSB = new ScrollBarDecorator(component);
            //将装饰了一次之后的对象继续注入到另一个装饰类中，进行第二次装饰
            componentBB = new BlackBorderDecorator(componentSB);

            // 显示.
            componentBB.Display();

        }


    }
}
