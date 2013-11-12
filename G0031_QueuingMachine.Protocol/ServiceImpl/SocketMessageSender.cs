using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;


using G0031_QueuingMachine.Message;
using G0031_QueuingMachine.MessageCoding;
using G0031_QueuingMachine.Service;


namespace G0031_QueuingMachine.ServiceImpl
{

    /// <summary>
    /// 发送消息类.
    /// </summary>
    public class SocketMessageSender : IMessageSender
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
        /// 用于发送消息的 Socket.
        /// </summary>
        public Socket Socket { set; get; }


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(QueuingMachineMessage message)
        {
            // 消息转换为 byte 数组.
            BinaryWriter writer = new BinaryWriter(stream);
            queuingMachineMessageCoding.Encode(writer, message);

            // 通过 Socket  发送.
            Socket.Send(stream.GetBuffer(), message.Header.CommandLength, SocketFlags.None);
        }
    }
}
