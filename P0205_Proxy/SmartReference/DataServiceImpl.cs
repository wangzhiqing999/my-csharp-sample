using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0205_Proxy.SmartReference
{

    /// <summary>
    /// 本接口是“代理”模式的 真实主题角色
    /// </summary>
    public class DataServiceImpl : IDataService
    {

        public void DoSomething()
        {
            Console.WriteLine("@@@ 真实主题角色执行的处理...... @@@");
        }
    }

}
