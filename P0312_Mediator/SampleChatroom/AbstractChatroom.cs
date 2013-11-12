using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.SampleChatroom
{

    /// <summary>
    ///  抽象中介者类
    /// </summary>
    abstract class AbstractChatroom
    {
        /// <summary>
        /// 注册一个 “同事类”
        /// </summary>
        /// <param name="participant"></param>
        public abstract void Register(Participant participant);


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        public abstract void Send(string from, string to, string message);

    }

}
