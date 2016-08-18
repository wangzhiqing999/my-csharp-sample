using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace F0030_CodeActivity
{

    public sealed class CodeActivitySayHelloInCode : CodeActivity
    {





        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            System.Console.Write("请输入内容:");
            string inputString = System.Console.ReadLine();

            string outputString = string.Format("你输入的是:{0}", inputString);
            System.Console.WriteLine(outputString);
        }


    }
}
