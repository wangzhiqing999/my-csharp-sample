using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


using A5300_UDP_P2P.Message;



namespace A5300_UDP_P2P.MessageCoding
{

    /// <summary>
    /// 通话 请求 消息编码.
    /// </summary>
    public class TalkRequestCoding : AbstractMessageCoding<TalkRequest>
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, TalkRequest bodyData)
        {
            // 写入 发送者.
            base.WriteString(writer, bodyData.FromUser);
            // 写入 消息.
            base.WriteString(writer, bodyData.TalkMessage);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, TalkRequest bodyData)
        {
            // 读取发送者.
            bodyData.FromUser = base.ReadString(reader);
            // 读取 消息.
            bodyData.TalkMessage = base.ReadString(reader);
        }

    }
}
