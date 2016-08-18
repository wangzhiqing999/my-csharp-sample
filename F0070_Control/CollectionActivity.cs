using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace F0070_Control
{

    public sealed class CollectionActivity : CodeActivity
    {

        /// <summary>
        /// 定义输出参数.
        /// </summary>
        public OutArgument<System.Collections.Generic.List<string>> myOutCollection { get; set; }



        protected override void Execute(CodeActivityContext context)
        {
            System.Collections.Generic.List<string> list = new List<string>();
            list.Add("abc");
            list.Add("def");
            list.Add("......");
            list.Add("xyz");

            context.SetValue(this.myOutCollection, list);
        }


    }
}
