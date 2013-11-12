using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using G0031_QueuingMachine.Message;


namespace G0031_QueuingMachine.MessageCoding
{

    /// <summary>
    /// 消息体编码、解码.
    /// </summary>
    public abstract class AbstractMessageCoding<T> 
    {
        /// <summary>
        /// 将消息体，写入到二进制消息.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public virtual void Encode(BinaryWriter writer, T bodyData)
        {
            // Do Nothing.
        }


        /// <summary>
        /// 读取二进制信息 到消息体.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public virtual void Decode(BinaryReader reader, T bodyData)
        {
            // Do Nothing.
        }
    }

}
