using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0401_String.Sample;


namespace A0401_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========String 类使用的例子！==========");

            StringSample sample = new StringSample();
            sample.DemoStringUse();




            Console.WriteLine("===========Regex 类使用的例子！===========");

            RegexSample regexSample = new RegexSample();
            regexSample.DemoRegexUse1();
            regexSample.DemoRegexUse2();
            regexSample.DemoRegexUse3();
            regexSample.DemoRegexUse4();
            regexSample.DemoRegexUse5();

            regexSample.DemoRegexUse6();
            regexSample.DemoRegexUse7();


            Console.ReadLine();
        }
    }
}
