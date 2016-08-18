using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace F0030_CodeActivity
{

    // 

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new CodeActivitySayHelloInCode());
        }
    }
}
