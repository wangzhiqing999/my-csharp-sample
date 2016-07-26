using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0147_SocketClientPlus.Sample;



namespace A0147_SocketClientPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int clientID = 2;
            if (args.Length > 0)
            {
                clientID = Convert.ToInt32(args[0]);
            }

            CacheSocket cac = new CacheSocket(clientID);


            Console.WriteLine("Input exit to Finish.");

            while (true)
            {
                // 获取输入数据.
                string strInputData = Console.ReadLine();

                if (String.IsNullOrEmpty(strInputData))
                {
                    // 不发送空白数据.
                    continue;
                }


                cac.Cmd(strInputData);


                if (strInputData == "exit")
                {
                    break;
                }
            }
                        

        }
    }
}
