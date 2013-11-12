using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace P0205_Proxy.Virtual
{

    /// <summary>
    /// 本接口是“代理”模式的  代理主题（Proxy）角色
    /// </summary>
    public class LongTimeServiceProxy : ILongTimeService
    {
        /// <summary>
        /// 代理主题角色内部包含有对真实主题的引用
        /// </summary>
        private ILongTimeService realService = new LongTimeServiceImpl();



        public void LongTimeProcess()
        {
            Console.WriteLine("正在处理中..... Please wait...");


            // 开一个新线程去执行长时间的处理.
            ThreadStart ts = new ThreadStart(realService.LongTimeProcess );
            Thread t = new Thread(ts);
            // 启动.
            t.Start();

            Console.WriteLine("正在处理中..... Please wait......");
        }
    }
}
