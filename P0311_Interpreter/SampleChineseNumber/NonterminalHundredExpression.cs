using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{
    /// <summary>
    /// 非终结表达式角色
    /// 解释百位数
    /// </summary>
    public class NonterminalHundredExpression : Expression
    {
        public override string GetPostifix()
        {
            return "百";
        }
        public override int Multiplier() { return 100; }
        public override int GetLength()
        {
            return 2;
        }
    }

}
