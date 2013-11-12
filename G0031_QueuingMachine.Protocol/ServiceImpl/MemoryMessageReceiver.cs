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
    /// 内存 消息接收.
    /// </summary>
    public class MemoryMessageReceiver : IMessageReceiver
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
        /// 接受消息.
        /// </summary>
        /// <returns></returns>
        public QueuingMachineMessage ReceiveMessage()
        {
            BinaryReader reader = new BinaryReader(stream);
            QueuingMachineMessage result = new QueuingMachineMessage();
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
