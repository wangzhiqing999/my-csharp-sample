using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0145_WebRequest_WebClient.Sample;



namespace A0145_WebRequest_WebClient
{
    class Program
    {
        static void Main(string[] args)
        {

            TestWebRequest.TestGetData(@"http://m.weather.com.cn/data/101010100.html");
            TestWebClient.TestGetData(@"http://m.weather.com.cn/data/101010100.html");


            Console.WriteLine();


            TestWebRequest.TestGetData(@"http://www.dianping.com/search/category/1/10/g101");
            TestWebClient.TestGetData(@"http://www.dianping.com/search/category/1/10/g101");



            Console.ReadLine();
        }
    }
}
