using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using B0400_7zip.Util;


namespace B0400_7zip
{
    class Program
    {

        private static string ZIP_FILE_NAME = "cjyw.7z";

        private static string UPZIP_PATH_NAME = "Result";


        static void Main(string[] args)
        {

            // 如果 压缩文件已存在，先删除.
            if (File.Exists(ZIP_FILE_NAME))
            {
                File.Delete(ZIP_FILE_NAME);
            }

            // 如果解压缩目录不存在，那么创建.
            if (!Directory.Exists(UPZIP_PATH_NAME)) 
            {
                Directory.CreateDirectory(UPZIP_PATH_NAME);
            }
         

            Console.WriteLine("测试调用 7z.exe 来 压缩 / 解压缩.");


            Zip7 ziper = new Zip7();

            Console.WriteLine("测试压缩.");
            ziper.Zip("cjyw.xml", ZIP_FILE_NAME);
            Console.WriteLine("压缩完毕.");


            Console.WriteLine("测试解压.");
            ziper.UnZip(ZIP_FILE_NAME, UPZIP_PATH_NAME);
            Console.WriteLine("解压完毕.");


            Console.ReadLine();
        }
    }
}
