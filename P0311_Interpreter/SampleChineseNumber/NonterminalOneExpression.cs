using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{
    /// <summary>
    /// 非终结表达式角色
    /// 解释个位数
    /// </summary>
    public class NonterminalOneExpression : Expression
    {
        public override string GetPostifix()
        {
            return "";
        }
        public override int Multiplier() { return 1; }
        public override int GetLength()
        {
            return 1;
        }
    }

}
