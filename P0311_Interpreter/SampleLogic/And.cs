using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{

    /// <summary>
    /// 与操作。
    /// </summary>
    public class And : Expression
    {


        private Expression left, right;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public And(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }


        /// <summary>
        /// 解释操作.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public override bool interpret(Context ctx)
        {
            return left.interpret(ctx) && right.interpret(ctx);
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
                return this.left.Equals(((And)o).left) &&
                this.right.Equals(((And)o).right);
            }
            return false;
        }


        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return "(" + left.ToString() + " AND " + right.ToString() + ")";
        }
    }
}
