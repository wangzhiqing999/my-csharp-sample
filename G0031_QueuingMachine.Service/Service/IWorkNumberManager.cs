using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0031_QueuingMachine.Service
{


    /// <summary>
    /// 排队号码分配.
    /// </summary>
    public interface IWorkNumberManager
    {
        /// <summary>
        /// 获取下一个号码.
        /// </summary>
        /// <returns></returns>
        string GetNextWorkNumber();        


        /// <summary>
        /// 号码前缀.
        /// </summary>
        string WorkNumberPrefix{get;}

    }


}
