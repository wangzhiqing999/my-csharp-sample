using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace G0031_QueuingMachine.Message
{

    /// <summary>
    /// 完成服务处理反馈消息.
    /// 
    /// 当服务台提交完成服务处理请求消息后.
    /// 
    /// 服务器简单返回本消息.
    /// </summary>
    public class CloseWorkNumberRespond : MessageBody
    {

        /// <summary>
        /// 构造函数.
        /// </summary>
        public CloseWorkNumberRespond()
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
            if (obj is CloseWorkNumberRespond)
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
            return "CloseWorkNumberRespond []";
        }


    }
}
