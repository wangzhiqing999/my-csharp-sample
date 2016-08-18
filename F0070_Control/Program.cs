using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace F0070_Control
{
    // 参考：
    // http://www.cnblogs.com/foundation/archive/2009/11/28/1612470.html
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new Workflow1());
        }
    }
}
