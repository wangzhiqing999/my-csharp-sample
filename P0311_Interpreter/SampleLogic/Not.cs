using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{

    /// <summary>
    ///  非 的操作。
    /// </summary>
    public class Not : Expression
    {
        private Expression exp;


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="exp"></param>
        public Not(Expression exp)
        {
            this.exp = exp;
        }


        /// <summary>
        /// 解释操作.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public override bool interpret(Context ctx)
        {
            return !exp.interpret(ctx) ;
        }


        /// <summary>
        /// 校验两个表达式在结构上是否相同.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            if (o != null && o is And)
            {
                return this.exp.Equals(((Not)o).exp);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return " (Not " + exp.ToString() + ")";
        }
    }

}
