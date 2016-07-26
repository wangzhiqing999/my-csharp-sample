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
            Console.WriteLine("使用 WebRequest GET {0} 数据......", url);

            try
            {
                //访问该链接
                WebRequest request = WebRequest.Create(url);
                //获得返回值
                WebResponse response = request.GetResponse();
                // 从 Internet 资源返回数据流。
                Stream s = response.GetResponseStream();

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




        /// <summary>
        /// 尝试 Post 提交数据.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryString"></param>
        public static void TestPostData(string url, string queryString)
        {
            Console.WriteLine("使用 WebRequest 获取向 {0} ， Post {1} 数据......", url, queryString);


            try
            {
                //访问该链接
                WebRequest request = WebRequest.Create(url);
                
                // 设置 POST 请求.
                request.Method = "POST";

                // POST 数据编码.
                byte[] byteArray = Encoding.UTF8.GetBytes(queryString);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                using (Stream dataStream = request.GetRequestStream())
                {
                    // Write the data to the request stream.
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }


                // Get the response.
                using (WebResponse response = request.GetResponse())
                {
                    // 从 Internet 资源返回数据流。
                    using (Stream s = response.GetResponseStream())
                    {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
