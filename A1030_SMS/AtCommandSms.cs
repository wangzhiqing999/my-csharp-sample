using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1030_SMS
{


    /// <summary>
    /// AT指令：短消息
    /// </summary>
    public class AtCommandSms
    {
        /// <summary>
        /// 选择消息服务。支持的服务有GSM-MO、SMS-MT、SMS-CB。 
        /// </summary>
        public static readonly string CSMS = "AT+CSMS";


        /// <summary>
        /// 新信息确认应答。 
        /// </summary>
        public static readonly string CNMA = "AT+CNMA";



        /// <summary>
        /// 优先信息存储。这个命令定义用来读写信息的存储区域。 
        /// </summary>
        public static readonly string CPMS = "AT+CPMS";


    }


}
