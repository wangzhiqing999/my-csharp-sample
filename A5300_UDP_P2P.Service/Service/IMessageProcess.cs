using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using A5300_UDP_P2P.Message;

namespace A5300_UDP_P2P.Service
{
    interface IMessageProcess
    {

        
        /// <summary>
        /// 消息处理.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        SystemMessage DoMessageProcess(IPEndPoint ipEndPoint, SystemMessage message);

    }
}
