using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0020_Function.Sample;


namespace A0020_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FunctionSample sample = new FunctionSample();

            sample.PrintAll(1, "2", 3.1415926F, "Hello~");


            int i = 0;
            Console.WriteLine("i={0}", i);
            sample.TestRef(ref i);
            Console.WriteLine("i={0}", i);


            String testOut = null;
            Console.WriteLine("testOut={0}", testOut);
            sample.TestOut(out testOut);
            Console.WriteLine("testOut={0}", testOut);


            Console.ReadLine();
        }
    }
}
