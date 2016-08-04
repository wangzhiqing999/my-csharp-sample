using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Command;



namespace B0602_SuperSocket_TelnetServer
{

    /// <summary>
    /// AppServer 代表了监听客户端连接，承载TCP连接的服务器实例。
    /// 理想情况下，我们可以通过AppServer实例获取任何你想要的客户端连接，服务器级别的操作和逻辑应该定义在此类之中。
    /// </summary>
    public class TelnetServer : AppServer<TelnetSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }


        protected override void OnStarted()
        {
            base.OnStarted();



            // 这个例子， 是通过  Command 体系， 来处理不同的命令.
            Dictionary<string, ICommand<TelnetSession, StringRequestInfo>> cmds = new Dictionary<string, ICommand<TelnetSession, StringRequestInfo>>();

            cmds.Add("ECHO", new ECHO());
            cmds.Add("ADD", new ADD());
            cmds.Add("MULT", new MULT());


            this.SetupCommands(cmds);
        }


        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }







    #region  实现请求处理  


    /// <summary>
    /// 定义一个名为"ECHO"的类去处理Key为"ECHO"的请求:
    /// </summary>
    public class ECHO : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body);
        }
    }



    /// <summary>
    /// 定义一个名为"ADD"的类去处理Key为"ADD"的请求:
    /// </summary>
    public class ADD : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
        }
    }




    /// <summary>
    /// 定义一个名为"MULT"的类去处理Key为"MULT"的请求
    /// </summary>
    public class MULT : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            var result = 1;

            foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
            {
                result *= factor;
            }

            session.Send(result.ToString());
        }
    }



    #endregion


}
