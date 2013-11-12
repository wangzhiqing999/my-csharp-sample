using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace G0031_QueuingMachine.Message
{

    /// <summary>
    /// 叫号请求消息.
    /// 
    /// 当服务台的一个顾客服务完毕后. 进入空闲状态.
    /// 通过向服务器发送这样一个消息，来获取一个新的服务号码.
    /// (如果有的话)
    /// </summary>
    public class AskWorkNumberRequest : MessageBody
    {

        /// <summary>
        /// 构造函数.
        /// </summary>
        public AskWorkNumberRequest()
        {
        }



        /// <summary>
        /// 服务台代码 (要求唯一).
        /// </summary>
        public string ServiceCode { set; get; }




        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = ServiceCode.Length + 1;
            return result;
        }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AskWorkNumberRequest)
            {
                AskWorkNumberRequest oMessageBody = obj as AskWorkNumberRequest;
                return (oMessageBody.ServiceCode == this.ServiceCode);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ServiceCode.GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "AskWorkNumberRequest [ServiceCode={0}]",
                this.ServiceCode);
        }




    }

}
