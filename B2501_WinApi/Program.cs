using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2501_WinApi
{
    internal class Program
    {

        [STAThread]
        static void Main(string[] args)
        {

            WeixinTest.TestExists();

            Console.WriteLine("----- Finish -----");
            // Console.ReadKey();
        }
    }
}
