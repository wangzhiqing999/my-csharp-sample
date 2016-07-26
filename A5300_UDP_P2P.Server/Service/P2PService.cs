using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.Net.Sockets;
using System.Threading;


using System.IO;


using A5300_UDP_P2P.Model;
using A5300_UDP_P2P.Message;
using A5300_UDP_P2P.ServiceImpl;


namespace A5300_UDP_P2P.Service
{

    class P2PService
    {

        /// <summary>
        /// 配置.
        /// </summary>
        private Properties.Settings config = Properties.Settings.Default;


        /// <summary>
        /// 服务器端消息监听.
        /// </summary>
        private UdpClient _server; 



        /// <summary>
        /// 服务器线程.
        /// </summary>
        private Thread _serverThread;


        /// <summary>
        /// 远程用户请求的IP地址及端口 
        /// </summary>
        private IPEndPoint _remotePoint;




        private IPEndPoint serverPoint;




        /// <summary>
        /// 消息处理器.
        /// </summary>
        private ServerMessageProcess messageProcess = ServerMessageProcess.GetInstance();




        /// <summary> 
        /// 构造器 
        /// </summary> 
        public P2PService()
        {


            // 服务器接入点.
            serverPoint = new IPEndPoint(IPAddress.Parse(config.ServerIp), config.ServerPort);




            _remotePoint = new IPEndPoint(IPAddress.Any, 0);


            _serverThread = new Thread(new ThreadStart(Run));
        }



        /// <summary> 
        /// 开始启动线程 
        /// </summary> 
        public void Start()
        {
            try
            {
                // 启动服务器端消息监听
                _server = new UdpClient(serverPoint);
                _serverThread.Start();
                Console.WriteLine("服务器 {0} 已经启动，监听端口: {1}，等待客户连接...", 
                    config.ServerIp, config.ServerPort);
            }
            catch (Exception ex)
            {
                Console.WriteLine("启动服务器发生错误: " + ex.Message);
                throw ex;
            }
        }


        /// <summary> 
        /// 停止线程 
        /// </summary> 
        public void Stop()
        {
            Console.WriteLine("停止服务器...");
            try
            {
                _serverThread.Abort();
                _server.Close();
                Console.WriteLine("服务器已停止.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("停止服务器发生错误: " + ex.Message);
                throw ex;
            }
        }




        /// <summary>
        /// 线程主方法
        /// </summary> 
        private void Run()
        {
            // 消息接收器.
            UdpClientMessageReceiver receiver = new UdpClientMessageReceiver();
            receiver.UdpClient = _server;
            receiver.IPEndPoint = _remotePoint;

            // 消息发送器.
            UdpClientMessageSender sender = new UdpClientMessageSender();
            sender.UdpClient = _server;



            while (true)
            {
                // 接收消息.
                SystemMessage message = receiver.ReceiveMessage();
                Console.WriteLine("接收-({0}:{1})>{2}", receiver.IPEndPoint.Address, receiver.IPEndPoint.Port, message.ToString());


                SystemMessage resultMessage = messageProcess.DoMessageProcess(receiver.IPEndPoint, message);


                // 设置接收方.
                sender.IPEndPoint = receiver.IPEndPoint;                               
                // 发送.
                sender.SendMessage(resultMessage);
                Console.WriteLine("答复-({0}:{1})>{2}", sender.IPEndPoint.Address, sender.IPEndPoint.Port, resultMessage.ToString());
            }
        }



    }


}
