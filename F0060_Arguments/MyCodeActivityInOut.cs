using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace F0060_Arguments
{

    public sealed class MyCodeActivityInOut : CodeActivity
    {
        // 定义一个字符串类型的活动 输入/输出 参数.
        public System.Activities.InOutArgument<string> myInOut { set; get; }




        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {


            string s2 = context.GetValue(myInOut);
            context.SetValue(myInOut, "Test : " + s2);


        }
    }
}
