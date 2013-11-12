using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.MessageCoding
{

    /// <summary>
    /// 完成服务处理请求消息 编码、解码处理.
    /// </summary>
    public class CloseWorkNumberRequestCoding : AbstractMessageCoding<CloseWorkNumberRequest>
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, CloseWorkNumberRequest bodyData)
        {
            // 写入 服务台代码.
            writer.Write(bodyData.ServiceCode);

            // 写入 叫号代码.
            writer.Write(bodyData.WorkNumber);
        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, CloseWorkNumberRequest bodyData)
        {
            // 读取 服务台代码.
            byte len = reader.ReadByte();
            char[] d = reader.ReadChars(len);
            bodyData.ServiceCode = new string(d);

            // 读取 叫号代码
            len = reader.ReadByte();
            d = reader.ReadChars(len);
            bodyData.WorkNumber = new string(d);
        }
    }
}
