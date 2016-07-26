using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{

    /// <summary>
    /// 取得用户列表反馈.
    /// </summary>
    public class UserListRespond : MessageBody
    {

        /// <summary>
        /// 用户数.
        /// </summary>
        public int UserCount { set; get; }


        /// <summary>
        /// 用户列表.
        /// </summary>
        public List<string> UserList { set; get; }



        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = 4;

            foreach (string user in UserList)
            {
                result = result + 4 + Encoding.UTF8.GetByteCount(user);
            }
            return result;
        }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is UserListRespond)
            {
                UserListRespond oMessageBody = obj as UserListRespond;

                if (oMessageBody.UserCount != this.UserCount)
                {
                    return false;
                }

                if (oMessageBody.UserList.Count != this.UserList.Count)
                {
                    return false;
                }

                return String.Join(",", oMessageBody.UserList) ==  String.Join(",",  this.UserList);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.UserList.GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "UserListRespond [UserCount={0}; UserList={1}]",
                this.UserCount, String.Join(";", this.UserList));
        }


    }
}
