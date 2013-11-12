using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.Sample
{
    class Demo
    {

        /// <summary>
        /// 测试中介者模式
        /// </summary>
        public static void ShowDemo()
        {
            Console.WriteLine("##### 简单的 2 同事的 中介. #####");

            ConcreteMediator m = new ConcreteMediator();

            ///让两个具体同事类认识中介者
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            ///让中介者认识具体对象
            m.Colleague1 = c1;
            m.Colleague2 = c2;

            Console.WriteLine("同事1发送消息给同事2");
            c1.Send("吃饭了没?");

            
            Console.WriteLine("同事2回消息给同事1");
            c2.Send("没呢，你打算请客?");


        }

    }
}
