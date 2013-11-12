using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0107_Prototype.Prototype
{
    /// <summary>
    /// 本类是“原型”模式中的 ConcretePrototype（具体原型类）
    /// 
    /// 本例子模拟一个消息. (测试深层克隆)
    /// </summary>
    public class MessageLog : ICloneable
    {
        /// <summary>
        /// 日志ID.
        /// </summary>
        public int LogID { set; get; }

        /// <summary>
        /// 消息.
        /// </summary>
        public Message Message { set; get; }


        /// <summary>
        /// 浅层克隆
        /// </summary>
        /// <returns></returns>
        public MessageLog SimpleClone()
        {
            return this.MemberwiseClone() as MessageLog;
        }


        /// <summary>
        /// 深层克隆.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // 先 浅层克隆.             
            MessageLog result = this.MemberwiseClone() as MessageLog;

            // 然后额外设置 需要 深层次克隆的属性.
            result.Message = this.Message.Clone() as Message;

            // 返回.
            return result;
        }


        public override string ToString()
        {
            return
                String.Format(
                    "#{0}: 从{1}向{2}发送消息{3}",
                    LogID,
                    Message.From,
                    Message.To,
                    Message.Data
                );
        }
    }
}
