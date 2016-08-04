using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Sodao.FastSocket.Server.Command;
using Sodao.FastSocket.SocketBase;



namespace B0701_FastSocket_Server
{
    /// <summary>
    /// sum command
    /// 用于将一组int32数字求和并返回
    /// </summary>
    public sealed class SumCommand : ICommand<AsyncBinaryCommandInfo>
    {
        /// <summary>
        /// 返回服务名称
        /// </summary>
        public string Name
        {
            get { return "sum"; }
        }
        /// <summary>
        /// 执行命令并返回结果
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandInfo"></param>
        public void ExecuteCommand(IConnection connection, AsyncBinaryCommandInfo commandInfo)
        {
            if (commandInfo.Buffer == null || commandInfo.Buffer.Length == 0)
            {
                Console.WriteLine("sum参数为空");
                connection.BeginDisconnect();
                return;
            }
            if (commandInfo.Buffer.Length % 4 != 0)
            {
                Console.WriteLine("sum参数错误");
                connection.BeginDisconnect();
                return;
            }

            int skip = 0;
            var arr = new int[commandInfo.Buffer.Length / 4];
            for (int i = 0, l = arr.Length; i < l; i++)
            {
                arr[i] = BitConverter.ToInt32(commandInfo.Buffer, skip);
                skip += 4;
            }

            commandInfo.Reply(connection, BitConverter.GetBytes(arr.Sum()));
        }
    }
}
