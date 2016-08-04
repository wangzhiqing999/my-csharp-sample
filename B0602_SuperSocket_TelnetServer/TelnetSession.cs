using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;



namespace B0602_SuperSocket_TelnetServer
{


    /// <summary>
    /// AppSession 代表一个和客户端的逻辑连接，基于连接的操作应该定于在该类之中。
    /// 你可以用该类的实例发送数据到客户端，接收客户端发送的数据或者关闭连接。
    /// </summary>
    public class TelnetSession : AppSession<TelnetSession>
    {
        protected override void OnSessionStarted()
        {
            this.Send("Welcome to SuperSocket Telnet Server.......");
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("Unknow request");
        }

        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
        }


        protected override void OnSessionClosed(CloseReason reason)
        {
            //add you logics which will be executed after the session is closed
            base.OnSessionClosed(reason);
        }
    }
}
