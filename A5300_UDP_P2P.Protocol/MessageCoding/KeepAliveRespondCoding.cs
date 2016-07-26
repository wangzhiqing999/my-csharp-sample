using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


using A5300_UDP_P2P.Message;


namespace A5300_UDP_P2P.MessageCoding
{

    /// <summary>
    /// 心跳包应答消息编码.
    /// </summary>
    public class KeepAliveRespondCoding : AbstractMessageCoding<KeepAliveRespond>
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, KeepAliveRespond bodyData)
        {
            // 写入 状态.
            writer.Write(bodyData.Status);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, KeepAliveRespond bodyData)
        {
            // 读取 状态.
            bodyData.Status = reader.ReadInt32();
        }
    }
}
