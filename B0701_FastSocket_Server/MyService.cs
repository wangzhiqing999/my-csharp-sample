using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using Sodao.FastSocket.Server;
using Sodao.FastSocket.Server.Command;
using Sodao.FastSocket.SocketBase;



namespace B0701_FastSocket_Server
{


    /// <summary>
    /// 实现自定义服务
    /// </summary>
    public class MyService : CommandSocketService<AsyncBinaryCommandInfo>
    {


        /// <summary>
        /// 当连接时会调用此方法
        /// </summary>
        /// <param name="connection"></param>
        public override void OnConnected(IConnection connection)
        {
            base.OnConnected(connection);
            Console.WriteLine(connection.RemoteEndPoint.ToString() + " connected");
        }


        /// <summary>
        /// 当连接断开时会调用此方法
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="ex"></param>
        public override void OnDisconnected(IConnection connection, Exception ex)
        {
            base.OnDisconnected(connection, ex);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(connection.RemoteEndPoint.ToString() + " disconnected");
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        /// <summary>
        /// 当发生错误时会调用此方法
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="ex"></param>
        public override void OnException(IConnection connection, Exception ex)
        {
            base.OnException(connection, ex);
            Console.WriteLine("error: " + ex.ToString());
        }


        /// <summary>
        /// 当服务端发送Packet完毕会调用此方法
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="e"></param>
        public override void OnSendCallback(IConnection connection, SendCallbackEventArgs e)
        {
            base.OnSendCallback(connection, e);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("send " + e.Status.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        /// <summary>
        /// 处理未知的命令
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandInfo"></param>
        protected override void HandleUnKnowCommand(IConnection connection, AsyncBinaryCommandInfo commandInfo)
        {
            Console.WriteLine("unknow command: " + commandInfo.CmdName);
        }

    }


}
