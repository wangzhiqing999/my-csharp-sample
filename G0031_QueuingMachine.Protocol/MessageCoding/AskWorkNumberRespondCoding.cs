using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using G0031_QueuingMachine.Message;


namespace G0031_QueuingMachine.MessageCoding
{

    /// <summary>
    /// 叫号反馈消息  编码、解码处理.
    /// </summary>
    public class AskWorkNumberRespondCoding : AbstractMessageCoding<AskWorkNumberRespond>
    {

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, AskWorkNumberRespond bodyData)
        {
            // 写入 反馈结果.
            writer.Write(bodyData.ResultStatus);

            // 写入 叫号代码.
            writer.Write(bodyData.ResultWorkNumber);
        }


        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, AskWorkNumberRespond bodyData)
        {
            // 读取 反馈结果.
            bodyData.ResultStatus = reader.ReadInt32();

            // 读取 叫号代码
            byte len = reader.ReadByte();
            char[] d = reader.ReadChars(len);
            bodyData.ResultWorkNumber = new string(d);   
        }


    }
}
