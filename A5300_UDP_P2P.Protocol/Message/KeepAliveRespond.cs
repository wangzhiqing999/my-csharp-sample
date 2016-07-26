using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{


    /// <summary>
    /// 心跳包应答
    /// </summary>
    public class KeepAliveRespond : MessageBody
    {

        /// <summary>
        /// 状态.
        /// </summary>
        public int Status { set; get; }




        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = 4;
            return result;

            
        }




        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is KeepAliveRespond)
            {
                KeepAliveRespond oMessageBody = obj as KeepAliveRespond;
                return (oMessageBody.Status == this.Status);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (this.Status).GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "KeepAliveRespond [Status={0}]",
                this.Status);
        }

    }


}
