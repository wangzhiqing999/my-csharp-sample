using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;
using Quartz.Impl;


namespace B0251_QuartzConfig
{
    class Program
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        static void Main(string[] args)
        {

            var scheduler = new StdSchedulerFactory().GetScheduler().Result;
            scheduler.Start();

            
            
            


            Console.WriteLine("----- Press Enter To Quit. -----");
            Console.ReadLine();
        }
    }
}
