using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0500_LINQ.Sample;


namespace A0500_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqSample sample = new LinqSample();
            sample.BaseDemo();
            sample.BaseDemo2();
            sample.BaseDemo3();
            sample.BaseDemo4();


            LinqSample2 sample2 = new LinqSample2();
            sample2.BaseDemo();



            Console.ReadLine();
        }

    }
}
