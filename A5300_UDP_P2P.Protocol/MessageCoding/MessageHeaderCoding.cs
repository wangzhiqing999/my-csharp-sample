using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A5300_UDP_P2P.Message;


namespace A5300_UDP_P2P.MessageCoding
{
    /// <summary>
    /// 消息头 编码、解码处理.
    /// </summary>
    public class MessageHeaderCoding : AbstractMessageCoding<MessageHeader>
    {

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="headerData"></param>
        public override void Encode(BinaryWriter writer, MessageHeader headerData)
        {
            // 命令长度.
            writer.Write(headerData.CommandLength);
            // 命令代码.
            writer.Write(headerData.CommandID);
            // 序列号.
            writer.Write(headerData.SequenceNo);
        }


        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="headerData"></param>
        public override void Decode(BinaryReader reader, MessageHeader headerData)
        {
            // 命令长度.
            headerData.CommandLength = reader.ReadInt32();
            // 命令代码.
            headerData.CommandID = reader.ReadUInt32();
            // 序列号.
            headerData.SequenceNo = reader.ReadUInt32();
        }


    }
}
