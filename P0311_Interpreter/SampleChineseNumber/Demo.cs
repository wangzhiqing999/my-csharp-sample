using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{
    class Demo
    {


        public static void ShowDemo()
        {

            Console.WriteLine("===== 处理 汉字数字大小写转换 的例子 =====");

            string roman = "伍千肆百参拾贰"; //5432
            ContextcnNum context = new ContextcnNum(roman);
            //构造抽象语法树
            List<Expression> tree = new List<Expression>();
            //加入终结符表达式
            //如果能直接转换成数字则直接返回
            tree.Add(new NumTerminalExpression());
            //非终结符,处理个位数
            tree.Add(new NonterminalOneExpression());
            //非终结符,处理十位数
            tree.Add(new NonterminalTenExpression());
            //非终结符,处理百位数
            tree.Add(new NonterminalHundredExpression());
            //非终结器,处理千位数
            tree.Add(new NonterminalThousandExpression());

            //对抽象语法树的每个枝节进行解释操作
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}", roman, context.data);

        }


    }
}
