using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.IO;


namespace A0145_WebRequest_WebClient.Sample
{
    public class TestWebClient
    {
        /// <summary>
        /// 尝试获取 Web 数据.
        /// </summary>
        /// <param name="url"></param>
        public static void TestGetData(string url)
        {

            Console.WriteLine("使用 WebClient 获取 {0} 数据......", url);

            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream s = client.OpenRead(url);

                using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                {
                    int lineIndex = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        lineIndex++;

                        if (lineIndex > 10)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
