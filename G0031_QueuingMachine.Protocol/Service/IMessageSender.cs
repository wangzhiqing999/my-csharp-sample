using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G0031_QueuingMachine.Message;

namespace G0031_QueuingMachine.Service
{

    /// <summary>
    /// 消息发送接口.
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// 发送一条消息.
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(QueuingMachineMessage message);
    }


}
