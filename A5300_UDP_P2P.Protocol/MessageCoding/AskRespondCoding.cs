using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


using A5300_UDP_P2P.Message;


namespace A5300_UDP_P2P.MessageCoding
{

    /// <summary>
    /// 请求独立通话 应答 消息编码.
    /// </summary>
    public class AskRespondCoding : AbstractMessageCoding<AskRespond>
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, AskRespond bodyData)
        {
            // 写入 状态.
            writer.Write(bodyData.Status);

            // 写入用户名.
            base.WriteString(writer, bodyData.UserName);

            // 写入 ip.
            base.WriteString(writer, bodyData.IpAddress);

            // 写入端口.
            writer.Write(bodyData.Port);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, AskRespond bodyData)
        {
            // 读取 状态.
            bodyData.Status = reader.ReadInt32();

            // 读取用户名.
            bodyData.UserName = base.ReadString(reader);

            // 读取 ip.
            bodyData.IpAddress = base.ReadString(reader);

            // 读取端口.
            bodyData.Port = reader.ReadInt32();

        }
    }
}
