using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.Threading;
using System.Net.Sockets;



namespace A0147_SocketClientPlus.Sample
{


    public class CacheSocket
    {

        /// <summary>
        /// 客户端 Socket.
        /// </summary>
        public Socket skClient;


        /// <summary>
        /// 服务器 ip 地址.
        /// </summary>
        public string ip = string.Empty;

        /// <summary>
        /// 服务器端口号.
        /// </summary>
        public int port = -1;



        /// <summary>
        /// 客户端 ID.
        /// </summary>
        public int netID;


        



        /// <summary>
        /// 发送的信息
        /// </summary>
        private byte[] sendData;

        /// <summary>
        /// 接收的信息
        /// </summary>
        private byte[] receiveData = new byte[1024];


        /// <summary>
        /// 接收到的字节数.
        /// </summary>
        private int receiveN;



        private bool isErr = false;
        
        


        

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="pNetID"> 客户端ID. </param>
        public CacheSocket(int pNetID)
        {
            this.netID = pNetID;
            GetConfig();
            Connection();
            Cmd("netid:" + this.netID);
        }



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="pNetID"> 客户端ID. </param>
        /// <param name="pIP"> 服务器IP </param>
        /// <param name="pPort"> 服务器端口.</param>
        public CacheSocket(int pNetID, string pIP, int pPort)
        {
            this.ip = pIP;
            this.port = pPort;
            Connection();
            Cmd("netid:" + pNetID);
        }



        /// <summary>
        /// 向服务器发送一个命令.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Cmd(string key)
        {
            // 一个信息发送后再接收为一次完成过程
            lock (this)
            {
                this.sendData = Encoding.UTF8.GetBytes(key);


                // 发送数据.
                try
                {
                    this.skClient.Send(this.sendData);
                }
                catch (Exception ex)
                {
                    isErr = true;

                    Console.WriteLine(ex.StackTrace);

                    ReSocket(() => { this.skClient.Send(this.sendData); });
                }


                // 接收数据.
                try
                {
                    this.receiveN = this.skClient.Receive(this.receiveData);
                }
                catch (Exception ex)
                {
                    isErr = true;

                    Console.WriteLine(ex.StackTrace);


                    ReSocket(() => { this.receiveN = this.skClient.Receive(this.receiveData); });                    
                }

                return Encoding.UTF8.GetString(this.receiveData, 0, this.receiveN);
            }
        }




        public delegate void ReSocket_D();


        private void ReSocket(ReSocket_D d)
        {
            if (isErr)
            {
                Connection();

                this.sendData = Encoding.UTF8.GetBytes("netid:" + this.netID);
                this.skClient.Send(this.sendData);

                this.receiveN = this.skClient.Receive(this.receiveData);
                if (Encoding.UTF8.GetString(this.receiveData, 0, this.receiveN) != "1")
                {

                }

                d();
                this.isErr = false;
            }
        }







        #region 获取IP和端口

        private void GetConfig()
        {
            this.ip = "127.0.0.1";
            this.port = 1234;
        }

        #endregion




        #region 连接套接字


        /// <summary>
        /// 连接.
        /// </summary>
        private void Connection()
        {

            this.skClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(this.ip), this.port);//服务器的IP和端口
            skClient.Connect(ie);

            byte[] data = new byte[7];
            this.receiveN = this.skClient.Receive(data);

            string s = Encoding.UTF8.GetString(data, 0, this.receiveN);
            if (s != "success")
            {
                throw new Exception("连接不成功" + s);
            }
        }


        #endregion

    }


}
