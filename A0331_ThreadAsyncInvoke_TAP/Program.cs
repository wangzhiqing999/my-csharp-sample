using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using A0331_ThreadAsyncInvoke_TAP.Sample;


namespace A0331_ThreadAsyncInvoke_TAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();


            Console.WriteLine("==============================");
            Console.WriteLine("### 调用同步方法开始！");
            client.Test();
            Console.WriteLine("### 调用同步方法结束！");


            Console.WriteLine("==============================");
            Console.WriteLine("### 调用异步方法开始！");
            client.TestTap();
            Console.WriteLine("### 调用异步方法结束！");
            Console.WriteLine("==============================");


            Console.WriteLine("========== 主进程执行结束！！！");
            Console.ReadLine();
        }
    }
}
