using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using G0031_QueuingMachine.Message;



namespace G0031_QueuingMachine.MessageCoding
{

    /// <summary>
    /// 申请新号码请求  编码、解码处理.
    /// </summary>
    public class NewWorkNumberRequestCoding : AbstractMessageCoding<NewWorkNumberRequest>
    {

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public override void Encode(BinaryWriter writer, NewWorkNumberRequest bodyData)
        {
            // 写入 服务台代码.
            writer.Write(bodyData.ServiceCode);

        }




        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public override void Decode(BinaryReader reader, NewWorkNumberRequest bodyData)
        {
            // 读取 服务台代码.
            byte len = reader.ReadByte();
            char[] d = reader.ReadChars(len);
            bodyData.ServiceCode = new string(d);

        }

    }
}
