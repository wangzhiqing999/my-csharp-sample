using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Logging;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketEngine;




namespace B0601_SuperSocket_TelnetServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press any key to start the server!");

            Console.ReadKey();
            Console.WriteLine();

            var appServer = new AppServer();



            // 设置 appServer.
            if (!appServer.Setup(2012))  // Setup with listening port
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            // Try to start the appServer
            if (!appServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }



            // 注册会话新建事件处理方法
            appServer.NewSessionConnected += new SessionHandler<AppSession>(appServer_NewSessionConnected);




            // 注册请求处理方法
            appServer.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(appServer_NewRequestReceived);


            




            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //Stop the appServer
            appServer.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }



        /// <summary>
        /// 会话新建事件处理方法
        /// </summary>
        /// <param name="session"></param>
        static void appServer_NewSessionConnected(AppSession session)
        {
            session.Send("Welcome to SuperSocket Telnet Server");
        }




        #region  实现请求处理  

        /// <summary>
        /// 实现请求处理.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        static void appServer_NewRequestReceived(AppSession session, StringRequestInfo requestInfo)
        {

            // 注意： 这个例子， 是硬编码， switch/case  判断输入的命令.
            switch (requestInfo.Key.ToUpper())
            {
                case ("ECHO"):
                    session.Send(requestInfo.Body);
                    break;

                case ("ADD"):
                    session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
                    break;

                case ("MULT"):

                    var result = 1;

                    foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
                    {
                        result *= factor;
                    }

                    session.Send(result.ToString());
                    break;
            }
        }


        #endregion










    }
}
