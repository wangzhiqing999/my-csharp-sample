using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


using A5300_UDP_P2P.Message;



namespace A5300_UDP_P2P.MessageCoding
{


    /// <summary>
    /// 登录请求消息编码.
    /// </summary>
    public class LoginRequestCoding : AbstractMessageCoding<LoginRequest>
    {

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, LoginRequest bodyData)
        {
            // 写入 用户名.
            base.WriteString(writer, bodyData.UserName);
            base.WriteString(writer, bodyData.Password);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, LoginRequest bodyData)
        {
            // 读取用户名.
            bodyData.UserName = base.ReadString(reader);
            // 读取密码.
            bodyData.Password = base.ReadString(reader);
        }

    }



}
