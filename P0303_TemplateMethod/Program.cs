using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0303_TemplateMethod.Sample;


namespace P0303_TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            AbstractMethod m1 = new OracleMethod();
            m1.Process();


            AbstractMethod m2 = new SybaseMethod();
            m2.Process();

            Console.ReadLine();
        }
    }
}
