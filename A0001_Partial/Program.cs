using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0001_Partial.Sample;


namespace A0001_Partial
{
    class Program
    {
        static void Main(string[] args)
        {


            Test test = new Test() { UserName = "test", Passwrod = "1234" };


            Console.WriteLine("{0}: IsAdmin={1}; IsAcceptPassword={2}",
                test.UserName,
                test.IsAdmin,
                test.IsAcceptPassword);



            Console.ReadLine();

        }
    }
}
