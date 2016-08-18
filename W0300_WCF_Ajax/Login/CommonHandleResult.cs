using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;



namespace W0300_WCF_Ajax.Login
{
    /// <summary>
    /// 通用的处理结果.
    /// </summary>
    [DataContract]
    public class CommonHandleResult
    {

        /// <summary>
        /// 处理结果.
        /// </summary>
        [DataMember]
        public bool Result { set; get; }



        /// <summary>
        /// 结果信息.
        /// </summary>
        [DataMember]
        public string ResultMessage { set; get; }

    }
}