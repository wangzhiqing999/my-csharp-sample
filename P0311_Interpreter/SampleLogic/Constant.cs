using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{

    /// <summary>
    /// 一个 Constant 对象，代表一个 布尔常量.
    /// </summary>
    public class Constant : Expression
    {

        private bool value;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="value"></param>
        public Constant(bool value)
        {
            this.value = value;
        }


        /// <summary>
        /// 解释操作.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public override  bool interpret(Context ctx)
        {
            return value;
        }


        /// <summary>
        /// 校验两个表达式在结构上是否相同.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            if (o != null && o is Constant)
            {
                return this.value == ((Constant)o).value;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }


        /// <summary>
        /// 常量 ToString.
        /// 就是直接返回 true / false.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return value.ToString(); 
        }
    }

}
