using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{

    /// <summary>
    /// 非终结表达式角色
    /// 解释十位数
    /// </summary>
    public class NonterminalTenExpression : Expression
    {
        public override string GetPostifix()
        {
            return "拾";
        }
        public override int Multiplier() { return 10; }
        public override int GetLength()
        {
            return 2;
        }
    }

}
