using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0331_ThreadAsyncInvoke_EAP.Sample;


namespace A0331_ThreadAsyncInvoke_EAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();

            c.Test();


            Console.WriteLine("回车键结束！");
            Console.ReadLine();
        }
    }
}
