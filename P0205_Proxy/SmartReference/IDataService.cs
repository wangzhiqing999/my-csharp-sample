using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0205_Proxy.SmartReference
{
    /// <summary>
    /// 本接口是“代理”模式的 抽象主题角色
    /// 数据接口服务.
    /// </summary>
    public interface IDataService
    {

        /// <summary>
        /// 此方法为 模拟某个 业务逻辑.
        /// </summary>
        void DoSomething();

    }
}
