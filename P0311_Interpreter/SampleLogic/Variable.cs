using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{
    
    /// <summary>
    /// Variable 对象代表一个 有名字的变量.
    /// </summary>
    public class Variable : Expression
    {
        private String name;


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="value"></param>
        public Variable(String name)
        {
            this.name = name;
        }


        /// <summary>
        /// 解释操作.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public override bool interpret(Context ctx)
        {
            return ctx.lookup(this);
        }


        /// <summary>
        /// 校验两个表达式在结构上是否相同.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            if (o != null && o is Variable)
            {
                return this.name == (((Variable)o).name);
            }
            return false;
        }




        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }


        /// <summary>
        /// 变量 ToString.
        /// 就是直接返回 变量名
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }
    }
    


}
