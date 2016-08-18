using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace W0300_WCF_Ajax.Login
{

    /// <summary>
    /// 登录数据结果.
    /// </summary>
    [DataContract]
    public class LoginHandleResult : CommonHandleResult
    {

        /// <summary>
        /// 用户的昵称.
        /// </summary>
        [DataMember]
        public string NackName { set; get; }

    }

}