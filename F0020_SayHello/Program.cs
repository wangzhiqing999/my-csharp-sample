using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace F0020_SayHello
{

    // 将 默认的 Workflow1.xaml 修改为 SayHello.xaml 以后。
    // 需要 双击在设计器打开 SayHello.xaml 
    // 点击设计器空白 处（不要选择任何activity）
    // 在 属性窗口中， 修改名称.


    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new SayHello());
        }
    }
}
