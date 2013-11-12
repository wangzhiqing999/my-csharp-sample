using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using A1021_CPU_Info.Sample;

namespace A1021_CPU_Info
{
    class Program
    {
        static void Main(string[] args)
        {

            GetCpuInfo getCpuInfo = new GetCpuInfo();

            ThreadStart ts = new ThreadStart(getCpuInfo.ShowCpuInfo);

            Thread t = new Thread(ts);
            // 启动.
            t.Start();

            // 等待回车键.
            Console.ReadLine();

            // 结束线程.
            t.Abort();
        }
    }
}
