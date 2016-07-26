using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;


using A5300_UDP_P2P.Message;
using A5300_UDP_P2P.MessageCoding;
using A5300_UDP_P2P.Service;


namespace A5300_UDP_P2P.ServiceImpl
{

    /// <summary>
    /// 发送消息类.
    /// </summary>
    public class SocketMessageSender : IMessageSender
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
        /// 用于发送消息的 Socket.
        /// </summary>
        public Socket Socket { set; get; }


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(SystemMessage message)
        {
            // 消息转换为 byte 数组.
            BinaryWriter writer = new BinaryWriter(stream);
            queuingMachineMessageCoding.Encode(writer, message);

            // 通过 Socket  发送.
            Socket.Send(stream.GetBuffer(), message.Header.CommandLength, SocketFlags.None);
        }


    }
}
