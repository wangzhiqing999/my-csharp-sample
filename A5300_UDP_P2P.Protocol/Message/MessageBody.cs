using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 消息体.
    /// </summary>
    public abstract class MessageBody
    {

        /// <summary>
        /// 取得消息体长度.
        /// </summary>
        /// <returns></returns>
        public abstract int GetBodyLength();


    }
}
