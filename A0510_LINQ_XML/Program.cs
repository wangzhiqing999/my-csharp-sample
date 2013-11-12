using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0510_LINQ_XML.Sample;


namespace A0510_LINQ_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqXmlSample sample = new LinqXmlSample();

            sample.TestParse();

            sample.TestParse2();

            sample.TestParse3();


            Console.ReadLine();
        }
    }
}
