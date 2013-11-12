using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0031_QueuingMachine.Message
{

    /// <summary>
    /// 申请新号码 请求消息.
    /// 
    /// 顾客在排队机上， 申请一个新号码.
    /// </summary>
    public class NewWorkNumberRequest : MessageBody
    {

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
            if (obj is NewWorkNumberRequest)
            {
                NewWorkNumberRequest oMessageBody = obj as NewWorkNumberRequest;
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
                "NewWorkNumberRequest [ServiceCode={0}]",
                this.ServiceCode);
        }


    }

}
