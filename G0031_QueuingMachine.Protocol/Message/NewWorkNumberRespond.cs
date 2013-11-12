using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0031_QueuingMachine.Message
{

    /// <summary>
    /// 申请新号码 反馈消息.
    /// 
    /// 顾客在排队机上， 申请一个新号码.
    /// 服务器将返回一个 具体的流水， 以及当前队列首号码. 排队人数信息.
    /// </summary>
    public class NewWorkNumberRespond : MessageBody
    {

        /// <summary>
        /// 叫号代码.
        /// </summary>
        public string ResultWorkNumber { set; get; }


        /// <summary>
        /// 队列首代码.
        /// </summary>
        public string TopWorkNumber { set; get; }


        /// <summary>
        /// 队列长度.
        /// </summary>
        public int QueueLength { set; get; }



        /// <summary>
        /// 返回消息体长度.
        /// </summary>
        /// <returns></returns>
        public override int GetBodyLength()
        {
            int result = ResultWorkNumber.Length + 1;
            result += (TopWorkNumber.Length + 1);
            result += 4;
            return result;
        }



        /// <summary>
        /// 覆盖 Equals 方法.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is NewWorkNumberRespond)
            {
                NewWorkNumberRespond oMessageBody = obj as NewWorkNumberRespond;
                return (oMessageBody.ResultWorkNumber == this.ResultWorkNumber
                    && oMessageBody.TopWorkNumber == this.TopWorkNumber
                    && oMessageBody.QueueLength == this.QueueLength);
            }
            return false;
        }



        /// <summary>
        /// 覆盖 GetHashCode 方法.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ResultWorkNumber.GetHashCode();
        }



        /// <summary>
        /// 覆盖 ToString 方法.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(
                "NewWorkNumberRespond [ResultWorkNumber={0}; TopWorkNumber={1}; QueueLength={2}]",
                this.ResultWorkNumber, this.TopWorkNumber, this.QueueLength);
        }




    }
}
