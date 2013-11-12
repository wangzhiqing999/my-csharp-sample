using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0031_QueuingMachine.Message
{

    /// <summary>
    /// 消息头.
    /// </summary>
    public class MessageHeader
    {


        /// <summary>
        /// 申请新号码 请求消息.
        /// </summary>
        public const uint QM_NewWorkNumber_Req = 0x01;


        /// <summary>
        /// 申请新号码 反馈消息.
        /// </summary>
        public const uint QM_NewWorkNumber_Resp = 0x80000001;



        /// <summary>
        /// 叫号请求消息类型.
        /// </summary>
        public const uint QM_AskWorkNumber_Req = 0x02;

        /// <summary>
        /// 叫号反馈消息类型.
        /// </summary>
        public const uint QM_AskWorkNumber_Resp = 0x80000002;


        /// <summary>
        /// 完成服务处理请求消息类型.
        /// </summary>
        public const uint QM_CloseWorkNumber_Req = 0x04;

        /// <summary>
        /// 完成服务处理反馈消息类型.
        /// </summary>
        public const uint QM_CloseWorkNumber_Resp = 0x80000004;



        /// <summary>
        /// 消息长度.
        /// </summary>
        public int CommandLength { set; get; }


        /// <summary>
        /// 命令代码.
        /// </summary>
        public uint CommandID { set; get; }


        /// <summary>
        /// 命令流水号.
        /// </summary>
        public uint SequenceNo { set; get; }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is MessageHeader)
            {
                MessageHeader oMessageHeader = obj as MessageHeader;
                return (oMessageHeader.CommandLength == this.CommandLength
                    && oMessageHeader.CommandID == this.CommandID
                    && oMessageHeader.SequenceNo == this.SequenceNo);
            }
            return false;

        }

        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.CommandID.GetHashCode() +  this.SequenceNo.GetHashCode();
        }


        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "CommandLength={0};CommandID={1:X};SequenceNo={2}",
                this.CommandLength, this.CommandID, this.SequenceNo);
        }

    }


}
