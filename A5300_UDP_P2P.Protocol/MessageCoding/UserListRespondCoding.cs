using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A5300_UDP_P2P.Message;



namespace A5300_UDP_P2P.MessageCoding
{

    public class UserListRespondCoding : AbstractMessageCoding<UserListRespond>
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, UserListRespond bodyData)
        {
            // 人数.
            writer.Write(bodyData.UserList.Count);

            // 依次写入
            foreach (string userName in bodyData.UserList)
            {
                base.WriteString(writer, userName);
            }

        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, UserListRespond bodyData)
        {
            // 人数.
            bodyData.UserCount = reader.ReadInt32();

            bodyData.UserList = new List<string>();

            // 依次读取.
            for (int i = 0; i < bodyData.UserCount; i++)
            {
                string oneUserName = base.ReadString(reader);
                bodyData.UserList.Add(oneUserName);
            }
        }

    }


}
