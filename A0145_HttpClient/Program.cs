using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using A0145_HttpClient.Sample;


namespace A0145_HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 测试 Get.
            TestHttpClient.TestGetData("https://www.baidu.com");



            Console.ReadLine();
        }
    }
}
