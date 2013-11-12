using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Threading;


namespace A1021_CPU_Info.Sample
{
    class GetCpuInfo
    {

        //性能计数器
        private PerformanceCounter pp = new PerformanceCounter("Processor", "% Processor Time", "_Total");



        public void ShowCpuInfo()
        {
            while (true)
            {
                Console.WriteLine(" CPU使用情况：{0} %", pp.NextValue());
                Thread.Sleep(1000);
            }
        }
    }
}
