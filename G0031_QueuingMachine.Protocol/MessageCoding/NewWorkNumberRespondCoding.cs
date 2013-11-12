using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.MessageCoding
{


    /// <summary>
    /// 申请新号码相应  编码、解码处理.
    /// </summary>
    public class NewWorkNumberRespondCoding : AbstractMessageCoding<NewWorkNumberRespond>
    {

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, NewWorkNumberRespond bodyData)
        {
            // 写入 叫号代码.
            writer.Write(bodyData.ResultWorkNumber);

            // 写入 队列首代码.
            writer.Write(bodyData.TopWorkNumber);

            // 写入 队列长度
            writer.Write(bodyData.QueueLength);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, NewWorkNumberRespond bodyData)
        {
            // 读取 叫号代码.
            byte len = reader.ReadByte();
            char[] d = reader.ReadChars(len);
            bodyData.ResultWorkNumber = new string(d);

            // 读取 队列首代码
            len = reader.ReadByte();
            d = reader.ReadChars(len);
            bodyData.TopWorkNumber = new string(d);

            // 读取 队列长度
            bodyData.QueueLength = reader.ReadInt32();
        }


    }
}
