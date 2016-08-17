using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEF_0001_Service.Sample
{

    /// <summary>
    /// 用于测试的接口.
    /// </summary>
    public interface IDemoInterface
    {

        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="msg"></param>
        void Send(string msg);

    }



}
