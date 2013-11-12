using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


using log4net;


namespace G0001_Sudoku
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //在应用程序启动时运行的代码
            string configFile = "G0001_Sudoku.exe.config";

            if (System.IO.File.Exists(configFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(configFile));
            }


            // 日志处理类
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
