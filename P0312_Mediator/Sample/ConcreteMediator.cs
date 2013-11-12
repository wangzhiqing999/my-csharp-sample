using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.Sample
{
    /// <summary>
    /// 具体中介者
    /// </summary>
    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;

        private ConcreteColleague2 colleague2;


        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }


        /// <summary>
        /// 重写发送信息的方法，根据所传对象发送到指定对象消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="colleague"></param>
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                //同事1给同事2消息
                colleague2.Notify(message);
            }
            else
            {
                //同事2给同事1消息
                colleague1.Notify(message);
            }
        }
    }
}
