using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using C0100_SignXML.Sample;

namespace C0100_SignXML
{
    class Program
    {
        static void Main(string[] args)
        {

            SignXML.DoTest();

            VerifyXML.DoTest();

            Console.ReadLine();
        }
    }
}
