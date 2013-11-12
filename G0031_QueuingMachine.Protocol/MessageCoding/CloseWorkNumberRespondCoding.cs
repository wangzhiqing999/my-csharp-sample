using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.MessageCoding
{
    /// <summary>
    /// 完成服务处理反馈消息    编码、解码处理.
    /// 
    /// 因为是空消息体， 所以简单定义类即可.
    /// </summary>
    public class CloseWorkNumberRespondCoding : AbstractMessageCoding<CloseWorkNumberRespond>
    {
    }
}
