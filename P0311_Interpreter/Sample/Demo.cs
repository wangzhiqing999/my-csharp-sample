using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.Sample
{
    class Demo
    {

        public static void ShowDemo()
        {
            Console.WriteLine("===== 基本的 解释器模式 演示. =====");

            Context context = new Context();
            IList<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
        }


    }
}
