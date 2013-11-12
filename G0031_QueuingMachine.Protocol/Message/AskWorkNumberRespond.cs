using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;


namespace G0031_QueuingMachine.Message
{

    /// <summary>
    /// 叫号反馈消息.
    /// 
    /// 当空闲的服务台， 向服务器发送 叫号请求代码的时候。
    /// 服务器将返回这样一个消息，给服务台.
    /// 
    /// 服务台接受到这个消息后，将显示： XXXX号，请到YYYY柜台.
    /// </summary>
    [Serializable]
    public class AskWorkNumberRespond : MessageBody
    {

        /// <summary>
        /// 构造函数.
        /// </summary>
        public AskWorkNumberRespond()
        {
        }


        /// <summary>
        /// 结果为：没有任何 叫号代码 在队列中.
        /// </summary>
        public const int ResultIsWithoutAnyWorkNumber = 0;


        /// <summary>
        /// 结果为：存在有 叫号代码 在队列中.
        /// </summary>
        public const int ResultIsHadWorkNumber = 1;


        /// <summary>
        /// 反馈结果.
        /// </summary>
        public int ResultStatus { set; get; }



        /// <summary>
        /// 叫号代码.
        /// </summary>
        public string ResultWorkNumber { set; get; }



        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            // 反馈结果 int,  4字节.
            int result = 4;

            // 叫号代码 长度.
            result += (ResultWorkNumber.Length + 1);

            return result;
        }


        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AskWorkNumberRespond)
            {
                AskWorkNumberRespond oMessageBody = obj as AskWorkNumberRespond;
                return (oMessageBody.ResultStatus == this.ResultStatus
                    && oMessageBody.ResultWorkNumber == this.ResultWorkNumber);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ResultStatus.GetHashCode() + this.ResultWorkNumber.GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "AskWorkNumberRespond [ResultStatus={0}; ResultWorkNumber={1}]",
                this.ResultStatus, this.ResultWorkNumber);
        }
    }

}
