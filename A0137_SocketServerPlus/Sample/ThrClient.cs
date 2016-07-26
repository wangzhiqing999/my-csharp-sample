using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace A0137_SocketServerPlus.Sample
{


    public class ThrClient
    {


        private static readonly StringBuilder sb = new StringBuilder();


        /// <summary>
        /// 服务端 Socket.
        /// </summary>
        private Socket skServer;


        /// <summary>
        /// 客户端 Socket.
        /// </summary>
        private Socket skClient;

        /// <summary>
        /// 客户端 IP 地址与端口 信息.
        /// </summary>
        private IPEndPoint clientIP;


        /// <summary>
        /// 发送的信息
        /// </summary>
        private byte[] sendData;

        /// <summary>
        /// 接收信息
        /// </summary>
        private byte[] receiveData = new byte[128];



        /// <summary>
        /// 接收到的字节数.
        /// </summary>
        private int receiveN;


        
        /// <summary>
        /// 客户端 ID.
        /// </summary>
        private int netID;




        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="pSkServer"> 服务端 Socket </param>
        /// <param name="pSkClient"> 客户端 Socket</param>
        public ThrClient(Socket pSkServer, Socket pSkClient)
        {
            this.skServer = pSkServer;
            this.skClient = pSkClient;


            // 取得 客户端  IP 地址与端口 信息.
            this.clientIP = (IPEndPoint)this.skClient.RemoteEndPoint;
            Console.WriteLine();
            Console.WriteLine("New Client!!!  IP:{0}  Port:{1}", clientIP.Address , clientIP.Port);



            // 发送信息: success
            this.sendData = Encoding.UTF8.GetBytes("success");
            try
            {
                this.skClient.Send(sendData, sendData.Length, SocketFlags.None);//发送信息
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }




        /// <summary>
        /// 启动的线程处理.
        /// </summary>
        public void Run()
        {

            while (true)
            {
                try
                {
                    // 接收数据.
                    this.receiveN = skClient.Receive(this.receiveData);
                    if (this.receiveN == 0)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    break;
                }

                this.sendData = this.GetData();

                try
                {
                    skClient.Send(this.sendData);//发送
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    break;
                }



                string s = Encoding.UTF8.GetString(receiveData, 0, this.receiveN);
                if (s == "exit")
                {
                    skClient.Close();

                    break;
                }

            }
        }




        /// <summary>
        /// 取得返回的数据.
        /// </summary>
        /// <returns></returns>
        private byte[] GetData()
        {

            // 取得接收到的数据.
            string s = Encoding.UTF8.GetString(receiveData, 0, this.receiveN);

            // 以 : 符号分割.
            string[] s1 = s.Split(':');
            
            // 预期返回的字符串.
            string sendStr = "null";


            if (s1.Length >= 2)
            {
                switch (s1[0])
                {
                    case "netid":
                        this.netID =  Convert.ToInt32(s1[1]);
                        sendStr = "1";
                        break;

                    default:
                        sendStr = this.netID + " " + s;
                        break;
                }
            }
            else
            {
                // 未知的情况，简单地，接收到什么，就返回什么.
                sendStr = s;
            }



            if (s.Split('-').Length > 2)
            {
                //若执行到这里，说明并发有问题
                Console.Write(sendStr + " | ");
            }


            Console.Write(sendStr + " | ");//需要删除
            return Encoding.UTF8.GetBytes(sendStr + " | ");
        }
    }


}
