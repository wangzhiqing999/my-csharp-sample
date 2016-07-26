using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A5300_UDP_P2P.Message;



namespace A5300_UDP_P2P.MessageCoding
{

    public class UserListRequestCoding : AbstractMessageCoding<UserListRequest>
    {

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, UserListRequest bodyData)
        {
            // 写入 用户令牌.
            base.WriteGuid(writer, bodyData.UserToken);

        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, UserListRequest bodyData)
        {
            // 读取 用户令牌.
            bodyData.UserToken = base.ReadGuid(reader);
        }

    }
}
