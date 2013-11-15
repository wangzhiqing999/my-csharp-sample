using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A3003_Office_Word.Sample;


namespace A3003_Office_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();


            // test.TestReadTable("Test1.docx");
            // Console.ReadLine();

            test.TestReadTable("Test2.docx");

            Console.ReadLine();
        }
    }
}
