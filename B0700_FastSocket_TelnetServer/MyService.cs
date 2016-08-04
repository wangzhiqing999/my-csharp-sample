using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Sodao.FastSocket.Server;
using Sodao.FastSocket.Server.Command;
using Sodao.FastSocket.SocketBase;


namespace B0700_FastSocket_TelnetServer
{
    /// <summary>
    /// 实现自定义服务
    /// </summary>
    public class MyService : CommandSocketService<StringCommandInfo>
    {
        /// <summary>
        /// 当连接时会调用此方法
        /// </summary>
        /// <param name="connection"></param>
        public override void OnConnected(IConnection connection)
        {
            base.OnConnected(connection);
            Console.WriteLine(connection.RemoteEndPoint.ToString() + " connected");
            connection.BeginSend(PacketBuilder.ToCommandLine("welcome"));
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
        /// 处理未知命令
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandInfo"></param>
        protected override void HandleUnKnowCommand(IConnection connection, StringCommandInfo commandInfo)
        {
            commandInfo.Reply(connection, "unknow command:" + commandInfo.CmdName);
        }
    }
}
