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
            regexSample.DemoRegexUse8();





            Console.WriteLine("===========Uri 类使用的例子！===========");

            UriSample uriSample = new UriSample();
            uriSample.ShowBasicProp(@"https://mbd.baidu.com/newspage/data/landingsuper?context=%7B%22nid%22%3A%22news_10169213394206363137%22%7D&n_type=0&p_from=1");


            Console.ReadLine();
        }
    }
}
