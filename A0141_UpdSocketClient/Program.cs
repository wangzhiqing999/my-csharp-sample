using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0141_UpdSocketClient.Sample;

namespace A0141_UpdSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {

            UpdSocketClient.ReceiveData();

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
