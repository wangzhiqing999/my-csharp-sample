using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyServer.Util
{


    /// <summary>
    /// 简单的使用  SoapHeader  来实现  WebService 安全性
    /// </summary>
    public class SecuritySoapHeader : System.Web.Services.Protocols.SoapHeader
    {

        /// <summary>
        /// 用户代码.
        /// </summary>
        public string UserCode { set; get; }

        /// <summary>
        /// 密码.
        /// </summary>
        public string PassWord { set; get; }

    }


}