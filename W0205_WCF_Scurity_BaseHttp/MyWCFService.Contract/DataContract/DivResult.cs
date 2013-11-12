using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MyWCFService.DataContract
{


    /// <summary>
    /// 这个类是 WCF 服务中.
    /// 当服务过程传递的参数、或者返回值
    /// 不是原始数据类型，而是自定义的类的情况下
    /// 需要做的定义设置
    /// 
    /// 请注意类定义前，必须要加那个 [DataContract]
    /// </summary>
    [DataContract]
    public class DivResult
    {

        /// <summary>
        /// 计算除法处理的结果。
        /// 
        /// 请注意类定义前，必须要加那个 [DataMember]
        /// </summary>
        [DataMember]
        public int DivData { set; get; }



        /// <summary>
        /// 除法处理后的余数。
        /// 
        /// </summary>
        [DataMember]
        public int ModData { set; get; }

    }


}
