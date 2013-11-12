using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using B0010_NVelocity.Sample;

namespace B0010_NVelocity
{
    class Program
    {
        static void Main(string[] args)
        {
            NVelocitySample sample = new NVelocitySample();

            sample.Process(@"example.vm");

            Console.ReadLine();
        }
    }
}
