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
    /// 接收消息类.
    /// </summary>
    public class UdpClientMessageReceiver : IMessageReceiver
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
        public IPEndPoint IPEndPoint {
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
        /// 接受消息.
        /// </summary>
        /// <returns></returns>
        public SystemMessage ReceiveMessage()
        {
            byte[] bytes = this.UdpClient.Receive(ref this.myIPEndPoint);
            stream = new MemoryStream(bytes);

            BinaryReader reader = new BinaryReader(stream);
            SystemMessage result = new SystemMessage();
            queuingMachineMessageCoding.Decode(reader, result);
            return result;
        }
    }


}
