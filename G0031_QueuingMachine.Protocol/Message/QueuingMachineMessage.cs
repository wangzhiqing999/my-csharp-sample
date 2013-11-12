using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace G0031_QueuingMachine.Message
{
    public class QueuingMachineMessage
    {

        /// <summary>
        /// 消息头.
        /// </summary>
        public MessageHeader Header { set; get; }


        /// <summary>
        /// 消息体.
        /// </summary>
        public MessageBody Body { set; get; }


        /// <summary>
        /// 设置消息头长度.
        /// </summary>
        public void SetCommandLength()
        {
            // 消息长度 = 头长度（固定为12） + 消息体长度
            this.Header.CommandLength = 12 + Body.GetBodyLength();
        }


        
        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is QueuingMachineMessage)
            {
                QueuingMachineMessage oMessageData = obj as QueuingMachineMessage;

                return this.Header.Equals(oMessageData.Header) && this.Body.Equals(oMessageData.Body);

            }
            return false;
        }


        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Header.GetHashCode() + this.Body.GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(@"消息头：{0}
消息体：{1}", this.Header, this.Body);
        }



    }
}
