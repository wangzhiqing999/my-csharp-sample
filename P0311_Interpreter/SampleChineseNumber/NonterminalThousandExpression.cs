using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{
    /// <summary>
    /// 非终结表达式角色
    /// 解释千位数
    /// </summary>
    public class NonterminalThousandExpression : Expression
    {
        public override string GetPostifix()
        {
            return "千";
        }
        public override int Multiplier() { return 1000; }
        public override int GetLength()
        {
            return 2;
        }
    }
}
