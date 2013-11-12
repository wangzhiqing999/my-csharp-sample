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
    /// 接收消息类.
    /// </summary>
    public class SocketMessageReceiver : IMessageReceiver
    {

        /// <summary>
        /// 消息编码解码类.
        /// </summary>
        private QueuingMachineMessageCoding queuingMachineMessageCoding = new QueuingMachineMessageCoding();

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
        public QueuingMachineMessage ReceiveMessage()
        {
            byte[] bytes = new byte[256];
            Socket.Receive(bytes);
            stream = new MemoryStream(bytes);

            BinaryReader reader = new BinaryReader(stream);
            QueuingMachineMessage result = new QueuingMachineMessage();
            queuingMachineMessageCoding.Decode(reader, result);
            return result;
        }


    }
}
