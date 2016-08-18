using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using System.IO;
using System.Threading;


namespace WS001_HelloWorld
{

    /// <summary>
    /// 测试的 Windows 服务.
    /// 
    /// 
    /// 在VS中添加Installer也很简单，操作如下：
    /// 右键 HelloWorldService.cs  (也就是本文件) 选择 [视图设计器]
    /// 再到View Desiger [视图设计器] 视图中右键, 选择 [添加安装程序]
    /// Installer 就添加好了。
    /// 
    /// 此操作完成后， 项目中会产生一组 ProjectInstaller.cs 的文件。
    /// 
    /// </summary>
    public partial class HelloWorldService : ServiceBase
    {

        /// <summary>
        /// 输出文件.
        /// </summary>
        private const String TEXT_FILE_NAME = @"d:\HelloWorldService.txt";


        /// <summary>
        /// 服务线程.
        /// </summary>
        private Thread serviceThread;



        public HelloWorldService()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 创建时自动创建的 空白方法。
        /// OnStart为启动服务时调用的方法
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            ThreadStart ts = new ThreadStart(ThreadFunc);
            serviceThread = new Thread(ts);
            serviceThread.Start();
        }


        /// <summary>
        /// 创建时自动创建的 空白方法。
        /// OnStop为停止服务时调用的方法。
        /// </summary>
        protected override void OnStop()
        {
            // 如果服务线程， 正在运行过程中的， 那么强制停止掉.
            if (serviceThread != null && serviceThread.IsAlive)
            {
                serviceThread.Abort();
            }
        }



        /// <summary>
        /// 简单的 线程执行的 方法.
        /// </summary>
        public void ThreadFunc()
        {
            try
            {

                using (StreamWriter sw = new StreamWriter(TEXT_FILE_NAME, true, Encoding.UTF8))
                {
                    // 线程停止运行的标志位.
                    bool done = false;

                    // 计数器
                    int count = 0;

                    while (!done)
                    {

                        sw.WriteLine(String.Format("HelloWorldService 运行中，当前处理数据：{0}。", count));
                        sw.Flush();

                        // 休眠60秒.
                        Thread.Sleep(60000);

                        // 计数器递增
                        count++;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
