using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0420_Log.Sample;

namespace A0420_Log
{
    class Program
    {
        static void Main(string[] args)
        {

            LogUseSample sample = new LogUseSample();


            sample.AppendRecords();
            sample.ReadRecords();

            Console.ReadLine();
        }
    }
}
