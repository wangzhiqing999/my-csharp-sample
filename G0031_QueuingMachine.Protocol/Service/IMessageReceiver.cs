using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G0031_QueuingMachine.Message;

namespace G0031_QueuingMachine.Service
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
        QueuingMachineMessage ReceiveMessage();

    }


}
