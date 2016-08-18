using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace F0040_Sequence
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new Workflow1());
        }
    }
}
