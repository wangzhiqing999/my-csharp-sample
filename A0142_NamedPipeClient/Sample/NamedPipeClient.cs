using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.IO;
using System.IO.Pipes;



namespace A0142_NamedPipeClient.Sample
{
    class NamedPipeClient
    {


        public static void StartClient()
        {

            using (NamedPipeClientStream pipeClient =
                       new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
            {

                // Connect to the pipe or wait until the pipe is available.
                Console.Write("尝试连接管道...");
                pipeClient.Connect();


                Console.WriteLine("连接到管道.");
                Console.WriteLine("There are currently {0} pipe server instances open.",
                   pipeClient.NumberOfServerInstances);




                try
                {
                    StreamReader sr = new StreamReader(pipeClient);
                    StreamWriter sw = new StreamWriter(pipeClient);

                    sw.AutoFlush = true;

                    for (int i = 9; i > 0; i--)
                    {


                        Console.WriteLine("向服务器的发送: {0}", i);
                        sw.WriteLine(i.ToString());


                        // Display the read text to the console
                        string temp = sr.ReadLine();
                        Console.WriteLine("来自服务器的反馈: {0}", temp);



                        System.Threading.Thread.Sleep(1000);
                    }


                    sw.WriteLine("bye");

                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }

            }

        }



    }
}
