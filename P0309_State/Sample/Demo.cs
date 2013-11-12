using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.Sample
{
    class Demo
    {

        public static void ShowDemo()
        {
            Console.WriteLine("===== 基本的 状态模式 体系结构演示 =====");

            Context context = new Context(new ConcreteStateA());

            context.Request();

            context.Request();

            context.Request();



        }

    }
}
