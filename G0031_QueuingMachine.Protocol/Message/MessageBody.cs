using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0031_QueuingMachine.Message
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
