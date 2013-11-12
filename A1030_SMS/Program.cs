using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1030_SMS
{
    class Program
    {
        static void Main(string[] args)
        {


            // 测试环境为
            // NOKIA E50 + 蓝牙
            // 端口号为  COM3
            GsmService service = new GsmService()
            {
                ComPort = "COM3",
                BaudRate = 9600
            };


            service.OpenComm();


            /*

            // 模块厂商的标识 
            ShowAtCmdInfo(service, AtCommandBaisc.CGMI);

            // 模块标识 
            ShowAtCmdInfo(service, AtCommandBaisc.CGMM);

            // 改订的软件版本 
            ShowAtCmdInfo(service, AtCommandBaisc.CGMR);

            // GSM模块的IMEI（国际移动设备标识）序列号 
            ShowAtCmdInfo(service, AtCommandBaisc.CGSN);


            */



            service.SendMsg("手机号码", "测试测试！", MsgType.AUSC2);





            service.CloseComm();



            Console.ReadLine();

        }



        /// <summary>
        /// 输出消息信息.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="msgList"></param>
        private static void ShowAtCmdInfo(GsmService service, string atCmd)
        {
            Console.WriteLine("尝试发送命令 {0} ", atCmd);
            string result = service.SendAT(atCmd);
            string[] resultArray = result.Split('\r');
            Console.WriteLine("返回结果：");
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.WriteLine(">{0}", resultArray[i]);
            }
            Console.WriteLine();
        }
    }
}
