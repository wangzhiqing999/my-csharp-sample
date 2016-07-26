using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;


using A0137_SocketServerPlus.Sample;



namespace A0137_SocketServerPlus
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread thr = new Thread(ServerListen.Run);
            thr.Start();


        }
    }
}
