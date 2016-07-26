using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.IO.Pipes;
using System.Diagnostics;



namespace A0143_AnonymousPipeClient.Sample
{
    class AnonymousPipeClient
    {

        public static void StartClient(string pipeHandle)
        {

            // 匿名管道.
            using (PipeStream pipeClient =
                            new AnonymousPipeClientStream(PipeDirection.In, pipeHandle))
            {

                // Show that anonymous Pipes do not support Message mode.
                try
                {
                    Console.WriteLine("[CLIENT] 尝试设置管道当前的传输模式为： \"Message\".");
                    pipeClient.ReadMode = PipeTransmissionMode.Message;
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("[CLIENT] 异常:\n    {0}", e.Message);
                }



                Console.WriteLine("[CLIENT] 管道当前的传输模式: {0}.", pipeClient.TransmissionMode);



                using (StreamReader sr = new StreamReader(pipeClient))
                {

                    // Display the read text to the console
                    string temp;

                    // Wait for 'sync message' from the server.
                    do
                    {
                        Console.WriteLine("[CLIENT] 等待与服务器作数据同步...");
                        temp = sr.ReadLine();
                    }
                    while (!temp.StartsWith("SYNC"));



                    // Read the server data and echo to the console.
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("[CLIENT] Echo: " + temp);
                    }
                }
            }

        }

    }
}
