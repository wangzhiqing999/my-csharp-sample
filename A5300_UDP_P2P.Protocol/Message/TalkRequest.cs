using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 对话请求.
    /// </summary>
    public class TalkRequest : MessageBody
    {

        /// <summary>
        /// 来源用户.
        /// </summary>
        public string FromUser { set; get; }


        /// <summary>
        /// 消息内容
        /// </summary>
        public string TalkMessage { set; get; }





        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = 4 + Encoding.UTF8.GetByteCount(FromUser);
            result = result + 4 + Encoding.UTF8.GetByteCount(TalkMessage);
            return result;
        }




        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is TalkRequest)
            {
                TalkRequest oMessageBody = obj as TalkRequest;
                return (oMessageBody.FromUser == this.FromUser && oMessageBody.TalkMessage == this.TalkMessage);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (this.FromUser + this.TalkMessage).GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "TalkRequest [FromUser = {0}; TalkMessage={1}",
                this.FromUser, this.TalkMessage);
        }
    }

}
