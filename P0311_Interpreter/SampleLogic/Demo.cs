using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{
    class Demo
    {

        private static Context ctx;
        private static Expression exp;


        public static void ShowDemo()
        {

            Console.WriteLine("===== 布尔类型解释的 演示 (From Java与模式 54章) =====");

            ctx = new Context();

            Variable x = new Variable("x");
            Variable y = new Variable("y");
            Constant c = new Constant(true);

            ctx.assign(x, false);
            ctx.assign(y, true);

            exp = new Or(new And(c, x), new And(y, new Not(x)));
            Console.WriteLine("x = " + x.interpret(ctx));
            Console.WriteLine("y = " + y.interpret(ctx));
            Console.WriteLine(exp.ToString() + " = " + exp.interpret(ctx));

        }


    }
}
