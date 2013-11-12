using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0140_SocketClient.Sample;

namespace A0140_SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // 构造客户端.
            StockClient client = new StockClient();

            client.SendMessage();


            Console.ReadLine();

        }
    }
}
