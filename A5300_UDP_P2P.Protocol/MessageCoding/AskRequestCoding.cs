using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


using A5300_UDP_P2P.Message;



namespace A5300_UDP_P2P.MessageCoding
{

    /// <summary>
    /// 请求独立通话 请求 消息编码.
    /// </summary>
    public class AskRequestCoding : AbstractMessageCoding<AskRequest>
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, AskRequest bodyData)
        {
            // 写入 用户令牌.
            base.WriteGuid(writer, bodyData.UserToken);

            // 写入 请求用户名.
            base.WriteString(writer, bodyData.AskUserName);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, AskRequest bodyData)
        {
            // 读取 用户令牌.
            bodyData.UserToken = base.ReadGuid(reader);

            // 读取 请求用户名.
            bodyData.AskUserName = base.ReadString(reader);
        }
    }
}
