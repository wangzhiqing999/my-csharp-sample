﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 登出请求.
    /// </summary>
    public class LogoutRequest : MessageBody
    {
        /// <summary>
        /// 用户令牌.
        /// </summary>
        public Guid UserToken { set; get; }




        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = 16;
            return result;
        }




        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is LogoutRequest)
            {
                LogoutRequest oMessageBody = obj as LogoutRequest;
                return (oMessageBody.UserToken == this.UserToken);
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
                "LogoutRequest [UserToken={0}]",
                this.UserToken);
        }



    }

}
