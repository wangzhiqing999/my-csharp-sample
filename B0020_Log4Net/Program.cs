using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using B0020_Log4Net.Sample;



namespace B0020_Log4Net
{
    class Program
    {

       

        static void Main(string[] args)
        {

            // 初始化 lpg4net 的配置.
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4netconfig.xml"));



            LoggingExample example = new LoggingExample();
            example.TestLog();


            LoggingExample2 example2 = new LoggingExample2();
            example2.TestLog();
        }
    }
}
