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
    /// 接收消息类.
    /// </summary>
    public class SocketMessageReceiver : IMessageReceiver
    {

        /// <summary>
        /// 消息编码解码类.
        /// </summary>
        private SystemMessageCoding queuingMachineMessageCoding = new SystemMessageCoding();

        /// <summary>
        /// 内存数据流.
        /// </summary>
        private MemoryStream stream;


        /// <summary>
        /// 用于发送消息的 Socket.
        /// </summary>
        public Socket Socket { set; get; }



        /// <summary>
        /// 接受消息.
        /// </summary>
        /// <returns></returns>
        public SystemMessage ReceiveMessage()
        {
            byte[] bytes = new byte[1024];
            Socket.Receive(bytes);
            stream = new MemoryStream(bytes);

            BinaryReader reader = new BinaryReader(stream);
            SystemMessage result = new SystemMessage();
            queuingMachineMessageCoding.Decode(reader, result);
            return result;
        }


    }
}
