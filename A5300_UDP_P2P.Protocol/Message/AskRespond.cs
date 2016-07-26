using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{
    /// <summary>
    /// 请求独立通话 应答.
    /// </summary>
    public class AskRespond : MessageBody
    {

        /// <summary>
        /// 状态数值.
        /// </summary>
        public int Status { set; get; }


        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// ip地址.
        /// </summary>
        public string IpAddress { set; get; }


        /// <summary>
        /// 端口号.
        /// </summary>
        public int Port { set; get; }




        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            // 状态数值
            int result = 4;
            //  用户名.
            result = result + 4 + Encoding.UTF8.GetByteCount(UserName);
            //  ip地址.
            result = result + 4 + Encoding.UTF8.GetByteCount(IpAddress);
            // 端口号.
            result = result + 4;
            return result;
        }




        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AskRespond)
            {
                AskRespond oMessageBody = obj as AskRespond;
                return (oMessageBody.Status == this.Status
                    && oMessageBody.UserName == this.UserName 
                    && oMessageBody.IpAddress == this.IpAddress
                    && oMessageBody.Port == this.Port);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (this.UserName + this.IpAddress + this.Port).GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "AskRespond [Status={0}; IpAddress={1}; Port={2}; UserName={3}]",
                this.Status, this.IpAddress, this.Port, this.UserName);
        }

    }

}
