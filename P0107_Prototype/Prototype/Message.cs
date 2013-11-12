using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0107_Prototype.Prototype
{


    /// <summary>
    /// 本类是“原型”模式中的 ConcretePrototype（具体原型类）
    /// 
    /// 本例子模拟一个消息. (测试浅层克隆)
    /// </summary>
    public class Message : ICloneable
    {
        /// <summary>
        /// 消息发送方.
        /// </summary>
        public string From { set; get; }

        /// <summary>
        /// 消息接收方.
        /// </summary>
        public string To { set; get; }

        /// <summary>
        /// 消息内容.
        /// </summary>
        public string Data { set; get; }


        /// <summary>
        /// 克隆.
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {
            return this.MemberwiseClone();
        }



        public override string ToString()
        {
            return  
                String.Format(
                    "从{0}向{1}发送消息{2}",
                    From,
                    To,
                    Data
                );
        }
    }
}
