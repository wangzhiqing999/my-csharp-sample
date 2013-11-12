using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0410_Globalization.Sample;

namespace A0410_Globalization
{
    class Program
    {
        static void Main(string[] args)
        {

            GlobalizationSample1 sample = new GlobalizationSample1();


            sample.ReadAllCultureInfo();

            sample.ShowInfo();

            Console.ReadLine();
        }
    }
}
