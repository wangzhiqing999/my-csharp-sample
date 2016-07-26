using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.IO;



namespace A0145_WebRequest_WebClient.Sample
{
    class TestHttpWebRequest
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

                // WebRequest 可以设置超时.
                request.Timeout = 5000;


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






        /// <summary>
        /// 测试上传文件.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="localFileName"></param>
        public static int TestUploadFile(string url, string localFileName, string saveName)
        {
            int returnValue = 0;

            // 要上传的文件 
            FileStream fs = new FileStream(localFileName, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            //时间戳 
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");

            //请求头部信息 
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);

            // 根据uri创建HttpWebRequest对象 
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpReq.Method = "POST";

            //对发送的数据不使用缓存 
            httpReq.AllowWriteStreamBuffering = false;

            //设置获得响应的超时时间（300秒） 
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                //progressBar.Maximum = int.MaxValue;
                //progressBar.Minimum = 0;
                //progressBar.Value = 0;

                //每次上传4k 
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength];

                //已上传的字节数 
                long offset = 0;

                //开始上传时间 
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();

                //发送请求头部消息 
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    //progressBar.Value = (int)(offset * (int.MaxValue / length));
                    
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;



                    //lblTime.Text = "已用时：" + second.ToString("F2") + "秒";
                    //if (second > 0.001)
                    //{
                    //    lblSpeed.Text = " 平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                    //}
                    //else
                    //{
                    //    lblSpeed.Text = " 正在连接…";
                    //}
                    //lblState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                    //lblSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    //Application.DoEvents();


                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳 
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();

                //获取服务器端的响应 
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                StreamReader sr = new StreamReader(s);

                //读取服务器端返回的消息 
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString == "Success")
                {
                    returnValue = 1;
                }
                else if (sReturnString == "Error")
                {
                    returnValue = 0;
                }

            }
            catch
            {
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }

            return returnValue; 
        }

    }
}
