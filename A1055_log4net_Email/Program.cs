using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using log4net;


using A1055_log4net_Email.Sample;



namespace A1055_log4net_Email
{
    class Program
    {
        static void Main(string[] args)
        {

            //在应用程序启动时运行的代码
            string configFile = "A1055_log4net_Email.exe.config";

            if (System.IO.File.Exists(configFile))
            {
                Console.WriteLine("加载 Log4net 配置信息...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(configFile));
            }


            // 准备开始测试.
            LoggingExample example = new LoggingExample();

            // 测试日志处理.
            example.TestLog();


            Console.WriteLine("Log4net 处理完毕， 按回车键结束处理！");
            Console.ReadLine();

        }
    }
}
