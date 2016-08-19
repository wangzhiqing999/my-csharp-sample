using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace B1000_Fody_Costura
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Test");


            log.Info("本项目为测试 Costura.Fody ！");

            log.Info("目的：把C#程序（含多个Dll）合并成一个Exe ！");

            log.Info("结果：编译完毕后， 删除 log4net.dll， 程序能正常运行！");


            Console.ReadKey();
        }
    }
}
