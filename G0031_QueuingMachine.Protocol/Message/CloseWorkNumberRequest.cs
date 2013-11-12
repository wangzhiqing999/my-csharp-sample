using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;


namespace G0031_QueuingMachine.Message
{
    /// <summary>
    /// 完成服务处理请求消息.
    /// 
    /// 当服务台显示： XXXX号，请到YYYY柜台 后.
    /// 
    /// 如果多次显示，还没有顾客来，或者立即有顾客来了。
    /// 那么这个 XXXX号， 需要从队列中消除掉.
    /// 
    /// 这个情况下， 需要发送本消息.
    /// </summary>
    public class CloseWorkNumberRequest : MessageBody
    {
        /// <summary>
        /// 构造函数.
        /// </summary>
        public CloseWorkNumberRequest()
        {
        }

        /// <summary>
        /// 服务台代码 (要求唯一).
        /// </summary>
        public string ServiceCode { set; get; }

        /// <summary>
        /// 叫号代码.
        /// </summary>
        public string WorkNumber { set; get; }


        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = ServiceCode.Length + 1;
            result += (WorkNumber.Length + 1);
            return result;
        }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is CloseWorkNumberRequest)
            {
                CloseWorkNumberRequest oMessageBody = obj as CloseWorkNumberRequest;
                return (oMessageBody.ServiceCode == this.ServiceCode
                    && oMessageBody.WorkNumber == this.WorkNumber);
            }
            return false;
        }

        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ServiceCode.GetHashCode() + this.WorkNumber.GetHashCode();
        }


        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "CloseWorkNumberRequest [ServiceCode={0}; WorkNumber={1}]",
                this.ServiceCode, this.WorkNumber);
        }

    }
}
