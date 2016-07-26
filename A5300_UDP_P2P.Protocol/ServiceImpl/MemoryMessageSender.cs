using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A5300_UDP_P2P.Message;
using A5300_UDP_P2P.MessageCoding;
using A5300_UDP_P2P.Service;

namespace A5300_UDP_P2P.ServiceImpl
{
    /// <summary>
    /// 内存消息发送.
    /// </summary>
    public class MemoryMessageSender : IMessageSender
    {

        /// <summary>
        /// 消息编码解码类.
        /// </summary>
        private SystemMessageCoding queuingMachineMessageCoding = new SystemMessageCoding();


        /// <summary>
        /// 内存数据流.
        /// </summary>
        private MemoryStream stream = new MemoryStream();


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(SystemMessage message)
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
