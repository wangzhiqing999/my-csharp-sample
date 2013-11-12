using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{

    /// <summary>
    /// 终结符表达式角色
    /// 如果能换算成数字则直接换算后返回
    /// </summary>
    class NumTerminalExpression : Expression
    {
        /// <summary>
        /// 重写解释方法
        /// </summary>
        /// <param name="context">环境角色</param>
        public override void Interpret(ContextcnNum context)
        {
            int i = 0;
            try
            {
                i = int.Parse(context.statement);
                //如果是数字则说明能够直接转换
                //也就是说用不到非终结表达式角色
                context.statement = "";
                context.data = i;
            }
            catch
            {
                //说明输入的是汉字数字,不做任何处理
            }
        }
        public override string GetPostifix()
        {
            return "";
        }
        public override int Multiplier() { return 1; }
    }

}
