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
    /// 内存 消息接收.
    /// </summary>
    public class MemoryMessageReceiver : IMessageReceiver
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
        /// 接受消息.
        /// </summary>
        /// <returns></returns>
        public SystemMessage ReceiveMessage()
        {
            BinaryReader reader = new BinaryReader(stream);
            SystemMessage result = new SystemMessage();
            queuingMachineMessageCoding.Decode(reader, result);
            return result;
        }


        /// <summary>
        /// 消息Byte数组.
        /// </summary>
        public byte[] MessageData
        {
            set
            {
                stream = new MemoryStream(value);
            }
        }
    }
}
