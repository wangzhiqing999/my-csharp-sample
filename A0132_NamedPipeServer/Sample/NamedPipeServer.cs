using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Threading;

using System.IO;
using System.IO.Pipes;




namespace A0132_NamedPipeServer.Sample
{
    class NamedPipeServer
    {

        /// <summary>
        /// 最大线程数.
        /// </summary>
        private static int numThreads = 4;



        /// <summary>
        /// 启动服务器线程.
        /// </summary>
        /// <param name="data"></param>
        public static void StartServerThread()
        {

            NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("testpipe", PipeDirection.InOut, numThreads);

            // 当前线程 ID.
            int threadId = Thread.CurrentThread.ManagedThreadId;


            Console.WriteLine("等待客户端接入...");

            // Wait for a client to connect
            pipeServer.WaitForConnection();


            Console.WriteLine("检测到客户端接入. 服务线程代码=[{0}].", threadId);
            try
            {
                StreamReader sr = new StreamReader(pipeServer);
                StreamWriter sw = new StreamWriter(pipeServer);

                sw.AutoFlush = true;

                string result = null;

                while (true)
                {
                    result = sr.ReadLine();
                    if (result == null || result == "bye")
                        break;


                    Console.WriteLine("来自客户端的请求 : {0}", result); 

                    sw.WriteLine(result);                    
                }
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);

                Console.WriteLine(e.StackTrace);
            }
            pipeServer.Close();
        }

    }
}
