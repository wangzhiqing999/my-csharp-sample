using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{

    /// <summary>
    /// 转换自 Java 与 模式 第54章 例子代码.
    /// 
    /// Abstraction of a class representing terminal and non-terminal classes of the following little grammar:<br> <pre>
    /// 
    /// BooleanExp ::=
    ///           BooleanExp AND BooleanExp
    ///         | BooleanExp OR BooleanExp
    ///         | NOT BooleanExp
    ///         | Variable
    ///         | Constant
    /// Variable ::= ... // a string of printable, non-white space characters
    /// Contant ::= "true" | "false"
    /// </pre>
    /// 
    /// </summary>
    public abstract class Expression
    {

        /// <summary>
        /// Given a BooleanExp object denoting a term, this method interprets this term relative to a Context object.
        /// 
        /// 以环境类为准，本方法解释给定的任何一个表达式.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public abstract bool interpret(Context ctx);


        /// <summary>
        /// Given a BooleanExp object denoting a term, this method test whether the given argument
        /// denoting another term is structurally the same.
        /// 
        /// 校验两个表达式在结构上是否相同.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override abstract bool Equals(Object o);

        /// <summary>
        /// Returns a hash code of this term. 
        /// </summary>
        /// <returns></returns>
        public override abstract int GetHashCode();

        
        /// <summary>
        ///  Converts a term into a string. Can be used as the basis for calculating the hashCode. 
        /// </summary>
        /// <returns></returns>
        public override abstract String ToString();

    }

}
