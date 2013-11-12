using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


using A4002_PI.Sample;

namespace A4002_PI
{
    class Program
    {
        static void Main(string[] args)
        {


            Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
            long[] pi = new Pi().Compute(Pi.DIGITS / Pi.LEN);
            timer.Stop();
            Console.Error.WriteLine("{0} seconds", timer.Elapsed.TotalSeconds);
            Console.Write(pi[pi.Length - 1] + ".");
            
            //for (long i = pi.Length - 2; i > 0; i--)
            //    Console.Write(pi[i].ToString("D" + Pi.LEN));

            Console.ReadLine();
        }


    }
}
