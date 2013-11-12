using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.Sample
{
    /// <summary>
    /// 非终结符表达式，为文法的非终结符实现解释操作。对文法中每一条规则
    /// 都需要一个具体的非终结符表达式类。通过实现抽象表达式的interpret
    /// 方法实现解释操作，解释操作以递归的方式调用实例变量
    /// </summary>
    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }
}
