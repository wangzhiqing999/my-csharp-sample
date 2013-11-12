using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0065_Switch.Sample
{
    class SwitchSample
    {

        /// <summary>
        ///  SQL Server 的 RAISERROR 语句的 severity  参数的例子：
        /// 20 到 25 之间的严重级别被认为是致命的。如果遇到致命的严重级别，客户端连接将在收到消息后终止，并将错误记录到错误日志和应用程序日志。
        /// </summary>
        public void TestCase1(int severity)
        {
            switch (severity)
            {
                case 25:
                case 24:
                case 23:
                case 22:
                case 21:
                case 20:
                    Console.WriteLine("{0} ：致命错误！错误记录到错误日志和应用程序日志！", severity);
                    break;

                default:
                    Console.WriteLine("{0} ： 普通错误。简单提示错误信息！", severity);
                    break;
            }
        }




        /// <summary>
        ///  SQL Server 的 RAISERROR 语句的 severity  参数的例子：
        /// 20 到 25 之间的严重级别被认为是致命的。如果遇到致命的严重级别，客户端连接将在收到消息后终止，并将错误记录到错误日志和应用程序日志。
        /// 
        /// 假如又加新要求了， 要求  23-25 的， 认为 太严重的， 在保留原有的功能的情况下， 还要发送电子邮件给 网络管理员。
        /// </summary>
        public void TestCase2(int severity)
        {
            switch (severity)
            {
                case 25:
                case 24:
                case 23:
                    Console.WriteLine("{0} ：致命错误！发送错误信息给网络管理员 ！", severity);
                    // 注意下面这句话.
                    // 没有下面这句话， 将产生编译上的错误！
                    // 控制不能从一个 case 标签(“case 23:”)贯穿到另一个 case 标签
                    // 参考页面：http://technet.microsoft.com/zh-cn/library/843c4c28(v=vs.80).aspx
                    goto case 22;
                case 22:
                case 21:
                case 20:
                    Console.WriteLine("{0} ：致命错误！错误记录到错误日志和应用程序日志！", severity);
                    break;

                default:
                    Console.WriteLine("{0} ： 普通错误。简单提示错误信息！", severity);
                    break;
            }
        }



        /// <summary>
        ///  SQL Server 的 RAISERROR 语句的 severity  参数的例子：
        /// 20 到 25 之间的严重级别被认为是致命的。如果遇到致命的严重级别，客户端连接将在收到消息后终止，并将错误记录到错误日志和应用程序日志。
        /// 
        /// 假如又加新要求了， 要求  23-25 的， 认为 太严重的， 在保留原有的功能的情况下， 还要发送电子邮件给 网络管理员。
        /// 
        /// 如果需求又升级了， 说 25的 属于要命的错误， 还要额外 发 短消息给 DBA。 
        /// </summary>
        public void TestCase3(int severity)
        {
            switch (severity)
            {
                case 25:
                    Console.WriteLine("{0} ：致命错误！发送错误信息给 DBA ！", severity);
                    // 注意下面这句话。
                    // 原因 同 goto case 22
                    goto case 24;
                case 24:
                case 23:
                    Console.WriteLine("{0} ：致命错误！发送错误信息给网络管理员 ！", severity);
                    // 注意下面这句话.
                    // 没有下面这句话， 将产生编译上的错误！
                    // 控制不能从一个 case 标签(“case 23:”)贯穿到另一个 case 标签
                    // 参考页面：http://technet.microsoft.com/zh-cn/library/843c4c28(v=vs.80).aspx
                    goto case 22;
                case 22:
                case 21:
                case 20:
                    Console.WriteLine("{0} ：致命错误！错误记录到错误日志和应用程序日志！", severity);
                    break;

                default:
                    Console.WriteLine("{0} ： 普通错误。简单提示错误信息！", severity);
                    break;
            }
        }

    }
}
