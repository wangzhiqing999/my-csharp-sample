using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0146_SocketAsyncEventArgsClient.Sample;

namespace A0146_SocketAsyncEventArgsClient
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
