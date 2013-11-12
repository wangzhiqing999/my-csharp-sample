using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.Sample
{
    /// <summary>
    /// 抽象中介者类
    /// </summary>
    abstract class Mediator
    {
        /// <summary>
        /// 得到同事对象和发送消息的抽象方法
        /// </summary>
        /// <param name="message"></param>
        /// <param name="colleague"></param>
        public abstract void Send(string message, Colleague colleague);
    }

}
