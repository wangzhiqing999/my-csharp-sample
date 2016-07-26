using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A0145_WebRequest_WebClient.Sample;



namespace A0145_WebRequest_WebClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("##### 测试 WebClient UploadFile 数据 #####");

            // 图片地址.
            string uploadImgUrl = @"http://113.106.63.156:40081/demo/gold/fileUpload.do";

            string uploadFile = "654325198311163726.jpg";

            TestWebClient.TestUploadImage(uploadImgUrl, uploadFile);



            Console.WriteLine("##### 测试 WebClient DownloadFile 数据 #####");

            // 图片地址.
            string imageUrl = @"https://www.baidu.com/img/bdlogo.png";

            string localFile = "bdlogo.png";

            if (File.Exists(localFile))
            {
                File.Delete(localFile);
            }

            TestWebClient.TestDownloadImage(imageUrl, localFile);




            Console.WriteLine("##### 测试 HttpWebRequest 上传文件 #####");

            string uploadUrl = @"http://localhost:4460/Upload";

            int uploadResult = TestHttpWebRequest.TestUploadFile(uploadUrl, localFile, localFile);

            Console.WriteLine("uploadResult = {0}", uploadResult);




            Console.WriteLine("##### 测试 WebClient Get 数据 #####");


            // Http Get 地址.
            string httpGetUrl = @"http://localhost:9900/Test/TestGet?code=123456&name=张三";

            // 测试 Get 数据.
            TestWebRequest.TestGetData(httpGetUrl);
            TestHttpWebRequest.TestGetData(httpGetUrl);
            TestWebClient.TestGetData(httpGetUrl);

            Console.WriteLine();





            Console.WriteLine("##### 测试 WebClient Post 数据 #####");

            // Http Post 地址.
            string httpPostUrl = @"http://localhost:9900/Test/TestPost";
            // Http Post 数据.
            string httpPostData = "code=654321&name=李四";


            // 测试 Post 数据.
            TestWebRequest.TestPostData(httpPostUrl, httpPostData);
            TestHttpWebRequest.TestPostData(httpPostUrl, httpPostData);
            TestWebClient.TestPostData(httpPostUrl, httpPostData);

            Console.WriteLine();







            Console.WriteLine("##### 测试 HttpsWebRequest  Https + 证书 #####");

            string httpsGetUrl = "https://localhost:9901/Test/TestGet?code=13579&name=王五";

            TestHttpsWebRequest.TestGetData(httpsGetUrl);

            Console.WriteLine();









            Console.WriteLine("##### 测试 Https （无证书）#####");

            // ######
            // ######  调用  https 的时候， 如果服务器安全证书存在问题 的解决办法.
            // ######


            string httpsGetUrl2 = "https://localhost:9901/Test/TestGet?code=24680&name=赵六";


            // 简单调用没有 信任证书的 https ，将报错.
            // 基础连接已经关闭: 未能为 SSL/TLS 安全通道建立信任关系。
            // 测试 Get 数据.
            TestWebRequest.TestGetData(httpsGetUrl2);
            TestHttpWebRequest.TestGetData(httpsGetUrl2);
            TestWebClient.TestGetData(httpsGetUrl2);

            Console.WriteLine();



            // 避免 “基础连接已经关闭: 未能为 SSL/TLS 安全通道建立信任关系” 错误！
            Util.SetCertificatePolicy();
            TestWebRequest.TestGetData(httpsGetUrl2);
            TestHttpWebRequest.TestGetData(httpsGetUrl2);
            TestWebClient.TestGetData(httpsGetUrl2);

            Console.WriteLine();










            Console.ReadLine();
        }
    }
}
