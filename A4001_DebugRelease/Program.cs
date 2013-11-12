using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4001_DebugRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            Properties.Settings config = Properties.Settings.Default;
            Console.WriteLine(config.TestName);
            Console.ReadLine();
        }
    }
}
