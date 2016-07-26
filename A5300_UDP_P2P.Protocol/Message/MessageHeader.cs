using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 消息头.
    /// </summary>
    public class MessageHeader
    {


        /// <summary>
        /// 登录 请求消息.
        /// </summary>
        public const uint QM_Login_Req = 0x01;
        /// <summary>
        /// 登录 反馈消息.
        /// </summary>
        public const uint QM_Login_Resp = 0x80000001;




        /// <summary>
        /// 登出 请求消息.
        /// </summary>
        public const uint QM_Logout_Req = 0x02;
        /// <summary>
        /// 登出 反馈消息.
        /// </summary>
        public const uint QM_Logout_Resp = 0x80000002;




        /// <summary>
        /// 心跳包 请求消息.
        /// </summary>
        public const uint QM_KeepAlive_Req = 0x03;
        /// <summary>
        /// 心跳包 反馈消息.
        /// </summary>
        public const uint QM_KeepAlive_Resp = 0x80000003;




        /// <summary>
        /// 用户列表 请求消息.
        /// </summary>
        public const uint QM_UserList_Req = 0x04;
        /// <summary>
        /// 用户列表 反馈消息.
        /// </summary>
        public const uint QM_UserList_Resp = 0x80000004;




        /// <summary>
        /// 请求独立通话 请求消息.
        /// </summary>
        public const uint QM_Ask_Req = 0x05;
        /// <summary>
        /// 请求独立通话 反馈消息.
        /// </summary>
        public const uint QM_Ask_Resp = 0x80000005;








        /// <summary>
        /// 通话 请求消息.
        /// </summary>
        public const uint QM_Talk_Req = 0x11;
        /// <summary>
        /// 通话 反馈消息.
        /// </summary>
        public const uint QM_Talk_Resp = 0x80000011;




        /// <summary>
        /// 是否是请求消息.
        /// </summary>
        public bool IsRequestCommand
        {
            get
            {
                return ((this.CommandID & 0x80000000) == 0);                
            }
        }



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
