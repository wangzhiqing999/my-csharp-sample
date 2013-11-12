using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0065_Switch.Sample;

namespace A0065_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            SwitchSample sample = new SwitchSample();

            Console.WriteLine("==========  TestCase1 ==========  ");
            for (int i = 10; i <= 25; i++)
            {
                sample.TestCase1(i);
            }

            Console.WriteLine();
            Console.WriteLine("==========  TestCase2 ==========  ");
            for (int i = 10; i <= 25; i++)
            {
                sample.TestCase2(i);
            }

            Console.WriteLine();
            Console.WriteLine("==========  TestCase3 ==========  ");
            for (int i = 10; i <= 25; i++)
            {
                sample.TestCase3(i);
            }


            Console.ReadLine();
        }
    }
}
