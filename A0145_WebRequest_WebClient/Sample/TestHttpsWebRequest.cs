using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.IO;

using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;


namespace A0145_WebRequest_WebClient.Sample
{


    /// <summary>
    /// 测试是用证书的情况来访问.
    /// 
    /// 
    /// 
    /// </summary>
    class TestHttpsWebRequest
    {



        /// <summary>
        /// 尝试获取 Web 数据.
        /// </summary>
        /// <param name="url"></param>
        public static void TestGetData(string url)
        {
            Console.WriteLine("使用 HttpWebRequest GET {0} 数据......", url);

            try
            {
                // 不要使用 HttpWebRequest 构造函数。 使用 WebRequest.Create 方法初始化新的 HttpWebRequest 对象。 如果统一资源标识符 (URI) 的方案是 http:// 或 https://，则 Create 返回 HttpWebRequest 对象。 
                //访问该链接
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);


                // X509Certificate cert = new X509Certificate(@"IE浏览器导出DER证书文件.cer");
                // X509Certificate cert = new X509Certificate(@"IE浏览器导出PKCS证书文件.p7b");

                // X509Certificate cert = new X509Certificate(@"IIS导出证书.pfx", "123456" );
                X509Certificate2 cert = new X509Certificate2(@"IIS导出证书.pfx", "123456", X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
				
				// 以上操作都失败了......

                request.ClientCertificates.Add(cert);

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




        /// <summary>
        /// 尝试 Post 提交数据.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryString"></param>
        public static void TestPostData(string url, string queryString)
        {
            Console.WriteLine("使用 HttpWebRequest 获取向 {0} ， Post {1} 数据......", url, queryString);


            try
            {

                // 不要使用 HttpWebRequest 构造函数。 使用 WebRequest.Create 方法初始化新的 HttpWebRequest 对象。 如果统一资源标识符 (URI) 的方案是 http:// 或 https://，则 Create 返回 HttpWebRequest 对象。 
                //访问该链接
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                X509Certificate2 cert = new X509Certificate2(@"IE浏览器导出PKCS证书文件.p7b");
                request.ClientCertificates.Add(cert);

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
