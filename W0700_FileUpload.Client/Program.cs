using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W0700_FileUpload.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            // 上传文件.
            UploadClient.UploadFile("http://localhost:2906/Upload", System.AppDomain.CurrentDomain.BaseDirectory + "favicon.ico");

            Console.ReadLine();
        }
    }
}
