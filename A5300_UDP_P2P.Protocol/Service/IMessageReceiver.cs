using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A5300_UDP_P2P.Message;

namespace A5300_UDP_P2P.Service
{

    /// <summary>
    /// 消息接收接口.
    /// </summary>
    public interface IMessageReceiver
    {

        /// <summary>
        /// 接收一条消息.
        /// </summary>
        /// <returns></returns>
        SystemMessage ReceiveMessage();

    }


}
