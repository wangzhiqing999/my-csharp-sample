using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0205_Proxy.Virtual
{

    /// <summary>
    /// 本接口是“代理”模式的 抽象主题角色
    /// 长时间处理的 接口服务.
    /// </summary>
    public interface ILongTimeService
    {
        /// <summary>
        /// 某个长时间的处理.
        /// </summary>
        void LongTimeProcess();

    }

}
