using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0143_AnonymousPipeClient.Sample;


namespace A0143_AnonymousPipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                AnonymousPipeClient.StartClient(args[0]);
            }

        }
    }
}
