using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace P0205_Proxy.Virtual
{

    /// <summary>
    /// 本接口是“代理”模式的 真实主题角色
    /// </summary>
    public class LongTimeServiceImpl : ILongTimeService
    {
        public void LongTimeProcess()
        {
            Console.WriteLine("@@@ 真实主题角色执行的处理开始...... @@@");
            Thread.Sleep(3000);
            Console.WriteLine("@@@ 真实主题角色执行的处理结束...... @@@");
        }
    }
}
