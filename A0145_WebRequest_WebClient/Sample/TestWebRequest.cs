using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.IO;


namespace A0145_WebRequest_WebClient.Sample
{

    public class TestWebRequest
    {


        /// <summary>
        /// 尝试获取 Web 数据.
        /// </summary>
        /// <param name="url"></param>
        public static void TestGetData(string url)
        {
            Console.WriteLine("使用 WebRequest 获取 {0} 数据......", url);

            try
            {
                //访问该链接
                WebRequest wrt = WebRequest.Create(url);
                //获得返回值
                WebResponse wrs = wrt.GetResponse();
                // 从 Internet 资源返回数据流。
                Stream s = wrs.GetResponseStream();

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
