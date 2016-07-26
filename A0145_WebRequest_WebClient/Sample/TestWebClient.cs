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




        /// <summary>
        /// 尝试 Post 提交数据.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryString"></param>
        public static void TestPostData(string url, string queryString)
        {

            Console.WriteLine("使用 WebClient 获取向 {0} ， Post {1} 数据......", url, queryString);

            try
            {

                //编码，尤其是汉字，事先要看下抓取网页的编码方式 
                byte[] postData = Encoding.UTF8.GetBytes(queryString);

                WebClient webClient = new WebClient();
                //采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                //得到返回字符流  
                byte[] responseData = webClient.UploadData(url, "POST", postData);

                //解码 
                string srcString = Encoding.UTF8.GetString(responseData);

                Console.WriteLine(srcString);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        /// <summary>
        /// 测试下载文件.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="localFileName"></param>
        public static void TestDownloadImage(string url, string localFileName)
        {

            Console.WriteLine("使用 WebClient 下载 {0} 图片到本地的 {1} ......", url, localFileName);

            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                client.DownloadFile(url, localFileName);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        /// <summary>
        /// 测试上传文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="localFileName"></param>
        public static void TestUploadImage(string url, string localFileName)
        {

            Console.WriteLine("使用 WebClient 上传 {0} 图片到 {1} ......", localFileName, url);

            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                byte[] uploadResult = client.UploadFile(url, localFileName);

                Console.WriteLine("Upload Result = {0}", Encoding.UTF8.GetString(uploadResult));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




    }
}
