using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Message
{


    /// <summary>
    /// 登出应答.
    /// </summary>
    public class LogoutRespond : MessageBody
    {

        /// <summary>
        /// 构造函数.
        /// </summary>
        public LogoutRespond()
        {
        }


        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            // 应答无消息体.
            return 0;
        }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is LogoutRespond)
            {
                // 因为本消息体中， 无任何内容，因此只要对象类型一致， 就是相同的.
                return true;
            }
            return false;
        }

        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }


        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "LogoutRespond []";
        }


    }


}
