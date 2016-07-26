using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;


namespace A0145_HttpClient.Sample
{
    class TestHttpClient
    {

        /// <summary>
        /// 尝试获取 Web 数据.
        /// </summary>
        /// <param name="url"></param>
        public static void TestGetData(string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");


            // 注意： 
            // 这里的 GetStringAsync 是 支持 异步处理的方法。 
            // 本测试，仅仅为了 测试 是否能获取数据，通过  .Result  变更成 同步处理的逻辑了。
            String result = httpClient.GetStringAsync(new Uri(url)).Result;


            

            Console.WriteLine(result);
        }




    }
}
