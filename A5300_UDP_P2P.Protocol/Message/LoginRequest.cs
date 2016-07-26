using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 登录请求.
    /// </summary>
    public class LoginRequest : MessageBody
    {


        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }



        /// <summary>
        /// 密码.
        /// </summary>
        public string Password { set; get; }




        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = 4 + Encoding.UTF8.GetByteCount(UserName);
            result = result + 4 + Encoding.UTF8.GetByteCount(Password);
            return result;
        }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is LoginRequest)
            {
                LoginRequest oMessageBody = obj as LoginRequest;
                return (oMessageBody.UserName == this.UserName && oMessageBody.Password == this.Password);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (this.UserName + this.Password).GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "LoginRequest [UserName={0}; Password={1}]",
                this.UserName, this.Password);
        }



    }




}
