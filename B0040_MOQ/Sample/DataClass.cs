using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0040_MOQ.Sample
{
    /// <summary>
    /// 测试数据 （用于测试 Mock 属性设置/获取）
    /// </summary>
    public class DataClass
    {
        /// <summary>
        /// 测试ID
        /// </summary>
        public virtual int TestID { set; get; }


        /// <summary>
        /// 测试名.
        /// 
        /// 
        /// 注意： Mock 的属性， 必须是 virtual 的。 否则运行期间会出错！
        /// </summary>
        public virtual string TestName { set; get; }

    }
}
