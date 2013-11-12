using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.Sample
{
    /// <summary>
    /// 终结符表达式，实现与文法中的终结符相关联的解释操作。
    /// 实现抽象表达式中所要求的接口，主要是一个interpret方法，
    /// 文中每一个终结符都有一个具体中介表达式与之相对应。
    /// </summary>
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }
}
