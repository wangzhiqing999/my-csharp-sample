using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0520_LINQ_DataSet.Sample;


namespace A0520_LINQ_DataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqDataSetSample sample = new LinqDataSetSample();
            sample.TestQuery1();


            LinqDataSetSample2 sample2 = new LinqDataSetSample2();
            sample2.Test1();

            Console.ReadLine();
        }
    }
}
