using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using WebSocket4Net;
using SuperSocket.ClientEngine;


namespace W2002_WebSocket4Net_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WebSocket 客户端!");


            EchoClient client = new EchoClient();



            Console.ReadLine();
        }
    }



    class EchoClient
    {

        WebSocket websocket;


        public EchoClient()
        {
            Console.WriteLine("初始化 EchoClient.");

            websocket = new WebSocket("ws://127.0.0.1:8181/Echo");
            websocket.Opened += new EventHandler(websocket_Opened);
            websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
            websocket.Closed += new EventHandler(websocket_Closed);
            websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            websocket.Open();
        }


        /// <summary>
        /// WebScoket 打开.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void websocket_Opened(object sender, EventArgs e)
        {
            websocket.Send("Hello World!");
        }

        /// <summary>
        /// WebScoket 关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Web Socket Closed!");
        }


        /// <summary>
        /// 接收到消息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {

            Thread.Sleep(2000);

            Console.WriteLine("接收到消息， 原样发送回去！ {0}", e.Message);
            websocket.Send(e.Message);
        }

        private void websocket_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error!!!");
        }

    }


}
