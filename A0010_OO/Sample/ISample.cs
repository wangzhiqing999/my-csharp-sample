using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.Sample
{

    /// <summary>
    /// 测试 接口例子.
    /// </summary>
    public interface ISample
    {

        /// <summary>
        /// 定义一个 SayHello 方法.
        /// </summary>
        void SayHello(String name);


        /// <summary>
        /// 接口中定义一个属性.
        /// </summary>
        String Week
        {
            get;
            set;
        }
        
    }

}
