using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.IO;


namespace W0700_FileUpload.Client
{

    public class UploadClient
    {

        /// <summary>
        /// Post 上传文件.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryString"></param>
        public static void UploadFile(string url, string fileName)
        {

            Console.WriteLine("使用 WebClient 获取向 {0} ， Post {1} 数据......", url, fileName);

            try
            {
                WebClient webClient = new WebClient();

                // 采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                // 得到返回字符流  
                byte[] responseData = webClient.UploadFile(url, "POST", fileName );

                // 解码 
                string srcString = Encoding.UTF8.GetString(responseData);

                Console.WriteLine(srcString);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
