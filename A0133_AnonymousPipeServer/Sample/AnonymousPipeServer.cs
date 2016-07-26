using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.IO.Pipes;
using System.Diagnostics;


namespace A0133_AnonymousPipeServer.Sample
{

    /// <summary>
    /// 匿名管道提供本地计算机上的进程间通信。 
    /// 他们提供的功能比命名管道少，它需要的系统开销也少。 
    /// 可以使用匿名管道更加轻松地在本地计算机上进行进程间通信。 
    /// 不能使用匿名管道通过网络进行通信。
    /// </summary>
    class AnonymousPipeServer
    {


        public static void StartServer()
        {


            Process pipeClient = new Process();

            pipeClient.StartInfo.FileName = "A0143_AnonymousPipeClient.exe";



            // 匿名管道.
            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.Out,
                HandleInheritability.Inheritable))
            {


                // Show that anonymous pipes do not support Message mode.
                try
                {
                    Console.WriteLine("[SERVER] 尝试设置管道当前的传输模式为： \"Message\".");
                    pipeServer.ReadMode = PipeTransmissionMode.Message;
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("[SERVER] 异常:\n    {0}", e.Message);
                }


                Console.WriteLine("[SERVER] 管道当前的传输模式: {0}.", pipeServer.TransmissionMode);



                // 提供命令行参数， 启动客户端.
                // Pass the client process a handle to the server.
                pipeClient.StartInfo.Arguments = pipeServer.GetClientHandleAsString();
                pipeClient.StartInfo.UseShellExecute = false;
                pipeClient.Start();



                pipeServer.DisposeLocalCopyOfClientHandle();


                try
                {
                    // Read user input and send that to the client process.
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;


                        // Send a 'sync message' and wait for client to receive it.
                        sw.WriteLine("SYNC");
                        pipeServer.WaitForPipeDrain();


                        // Send the console input to the client process.
                        Console.Write("[SERVER] 输入需要发送给客户端的消息: ");
                        sw.WriteLine(Console.ReadLine());
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("[SERVER] Error: {0}", e.Message);
                }
            }


            pipeClient.WaitForExit();
            pipeClient.Close();
            Console.WriteLine("[SERVER] Client quit. Server terminating.");

        }


    }


}
