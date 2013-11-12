using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using G0031_QueuingMachine.Message;
using G0031_QueuingMachine.MessageCoding;
using G0031_QueuingMachine.Service;

namespace G0031_QueuingMachine.ServiceImpl
{
    /// <summary>
    /// 内存消息发送.
    /// </summary>
    public class MemoryMessageSender : IMessageSender
    {

        /// <summary>
        /// 消息编码解码类.
        /// </summary>
        private QueuingMachineMessageCoding queuingMachineMessageCoding = new QueuingMachineMessageCoding();


        /// <summary>
        /// 内存数据流.
        /// </summary>
        private MemoryStream stream = new MemoryStream();


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(QueuingMachineMessage message)
        {
            BinaryWriter writer = new BinaryWriter(stream);
            queuingMachineMessageCoding.Encode(writer, message);
        }


        /// <summary>
        /// 消息Byte数组..
        /// </summary>
        public byte[] MessageData
        {
            get
            {
                return stream.GetBuffer();
            }
        }




    }
}
