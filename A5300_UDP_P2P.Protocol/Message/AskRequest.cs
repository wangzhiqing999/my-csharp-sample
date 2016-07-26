using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 请求独立通话 请求.
    /// </summary>
    public class AskRequest : MessageBody
    {

        /// <summary>
        /// 用户令牌.
        /// </summary>
        public Guid UserToken { set; get; }


        /// <summary>
        /// 目标用户名.
        /// </summary>
        public string AskUserName { set; get; }




        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = 16;
            result = result + 4 + Encoding.UTF8.GetByteCount(AskUserName);
            return result;
        }




        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AskRequest)
            {
                AskRequest oMessageBody = obj as AskRequest;
                return (oMessageBody.UserToken == this.UserToken && oMessageBody.AskUserName == this.AskUserName);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (this.UserToken).GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "AskRequest [UserToken={0}; AskUserName={1}]",
                this.UserToken, this.AskUserName);
        }


    }
}
