using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A5300_UDP_P2P.Message;


namespace A5300_UDP_P2P.MessageCoding
{

    /// <summary>
    /// 消息体编码、解码.
    /// </summary>
    public abstract class AbstractMessageCoding<T> 
    {
        /// <summary>
        /// 将消息体，写入到二进制消息.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="bodyData"></param>
        public virtual void Encode(BinaryWriter writer, T bodyData)
        {
            // Do Nothing.
        }


        /// <summary>
        /// 读取二进制信息 到消息体.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="bodyData"></param>
        public virtual void Decode(BinaryReader reader, T bodyData)
        {
            // Do Nothing.
        }








        /// <summary>
        /// 写入字符串信息.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="text"></param>
        protected void WriteString(BinaryWriter writer, string text)
        {
            // 取得 字符串 长度（按照 utf8 编码处理.）
            int count = Encoding.UTF8.GetByteCount(text);
            // 写入长度.
            writer.Write(count);
            // 写入 utf8编码的 字节数组.
            writer.Write(Encoding.UTF8.GetBytes(text));
        }


        /// <summary>
        /// 读取字符串信息.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected string ReadString(BinaryReader reader)
        {
            // 取得字符串长度.
            int len = reader.ReadInt32();
            // 读取指定字节数.
            byte[] d = reader.ReadBytes(len);
            // 字节数足编码为字符串.
            string result = Encoding.UTF8.GetString(d);
            // 返回.
            return result;
        }




        /// <summary>
        /// 写入 Guid 信息.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="data"></param>
        protected void WriteGuid(BinaryWriter writer, Guid data)
        {
            // Guid 转换为 byte 数组.
            byte[] byteArray = data.ToByteArray();

            // 写入数组.
            writer.Write(byteArray);
        }


        /// <summary>
        /// 读取 Guid 信息.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected Guid ReadGuid(BinaryReader reader)
        {
            // 读取指定字节数.
            byte[] d = reader.ReadBytes(16);

            return new Guid(d);   
        }



    }

}
