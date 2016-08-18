using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace F0060_Arguments
{

    public sealed class MyCodeActivityOut : CodeActivity
    {

        /// <summary>
        /// 定义一个字符串类型的活动输入参数
        /// </summary>
        public System.Activities.OutArgument<string> myOut { set; get; }




        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 1
            string s1 = myOut.Get(context);
            myOut.Set(context, "123456" + s1);

            //2
            string s2 = context.GetValue(myOut);
            context.SetValue(myOut, "654321" + s2);

        }



    }
}
