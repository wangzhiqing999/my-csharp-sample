using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
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
    public class UdpClientMessageSender : IMessageSender
    {


        /// <summary>
        /// 消息编码解码类.
        /// </summary>
        private SystemMessageCoding queuingMachineMessageCoding = new SystemMessageCoding();


        /// <summary>
        /// 内存数据流.
        /// </summary>
        private MemoryStream stream; // = new MemoryStream();


        /// <summary>
        /// 用于发送/接收 消息的 UdpClient.
        /// </summary>
        public UdpClient UdpClient { set; get; }



        /// <summary>
        /// 网络端点
        /// </summary>
        private IPEndPoint myIPEndPoint;

        /// <summary>
        /// 网络端点.
        /// </summary>
        public IPEndPoint IPEndPoint
        {
            set
            {
                this.myIPEndPoint = value;
            }
            get
            {
                return this.myIPEndPoint;
            }
        }



        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(SystemMessage message)
        {
            stream = new MemoryStream();

            // 消息转换为 byte 数组.
            BinaryWriter writer = new BinaryWriter(stream);
            queuingMachineMessageCoding.Encode(writer, message);

            // 通过 Socket  发送.
            UdpClient.Send(stream.GetBuffer(), message.Header.CommandLength, this.myIPEndPoint);
        }


    }
}
