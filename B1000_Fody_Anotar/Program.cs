using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Anotar.Log4Net;


namespace B1000_Fody_Anotar
{
    class Program
    {


        static void Main(string[] args)
        {


            if (LogTo.IsDebugEnabled)
            {
                LogTo.Debug("测试 Anotar.Log4Net 来输出 DEBUG 日志的处理！");
            }


            if (LogTo.IsInfoEnabled)
            {
                LogTo.Info("测试 Anotar.Log4Net 来输出 INFO 日志的处理！");
            }


            Console.ReadKey();

        }


    }


}
