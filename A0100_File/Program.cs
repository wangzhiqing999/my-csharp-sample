using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0100_File.Sample;


namespace A0100_File
{
    class Program
    {
        static void Main(string[] args)
        {
            // 构造例子类.  演示 文本文件写入与读取
            TextFile textFile = new TextFile();
            // 写入文件
            textFile.TestWrite();
            // 读取文件.
            textFile.TestRead();



            // 构造例子类.  演示 二进制文件写入与读取
            BinFile binFile = new BinFile();
            // 写入文件
            binFile.TestWrite();
            // 读取文件.
            binFile.TestRead();

            Console.ReadLine();

        }
    }
}
