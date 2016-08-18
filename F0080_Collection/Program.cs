using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace F0080_Collection
{


    // 
    // 参考：
    // http://www.cnblogs.com/foundation/archive/2009/12/17/1626611.html
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new Workflow1());
        }
    }
}
