using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.Sample
{

    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        { }


        public void Send(string message)
        {
            mediator.Send(message, this);
        }


        public void Notify(string message)
        {
            Console.WriteLine("同事1得到消息：" + message);
        }
    }


    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("同事2得到消息：" + message);
        }
    }


}
