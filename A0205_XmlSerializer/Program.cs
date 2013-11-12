using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0205_XmlSerializer.Sample;

namespace A0205_XmlSerializer
{
    public class Program
    {
        static void Main(string[] args)
        {

            XmlTest test = new XmlTest();

            // 写.
            test.TestWrite();

            // 读.
            test.TestRead();

            Console.ReadLine();
        }
    }
}
