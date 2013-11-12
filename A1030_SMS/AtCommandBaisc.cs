using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1030_SMS
{
    /// <summary>
    /// AT指令：一般命令
    /// </summary>
    public class AtCommandBaisc
    {

        /// <summary>
        /// 模块厂商的标识.
        /// </summary>
        public static readonly string CGMI = "AT+CGMI";


        /// <summary>
        /// 模块标识
        /// </summary>
        public static readonly string CGMM = "AT+CGMM";


        /// <summary>
        /// 改订的软件版本
        /// </summary>
        public static readonly string CGMR = "AT+CGMR";


        /// <summary>
        /// GSM模块的IMEI（国际移动设备标识）序列号
        /// </summary>
        public static readonly string CGSN = "AT+CGSN";




    }


}
