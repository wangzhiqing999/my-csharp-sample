using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A5300_UDP_P2P.Message;

namespace A5300_UDP_P2P.Service
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
        void SendMessage(SystemMessage message);
    }


}
