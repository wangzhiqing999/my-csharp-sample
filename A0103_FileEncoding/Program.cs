using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0103_FileEncoding.Sample;


namespace A0103_FileEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // 测试例子类.
            ConvertSample sample = new ConvertSample();






            // 首先写一个 UTF-8 文件.
            sample.TestWrite(
                "test_UTF8.txt", 
                Encoding.UTF8, 
                @"测试文件 编码转换！
本测试过程，为模拟 UTF-8 编码的文件， 转换为 其他编码格式的文件！

注意：
本代码仅仅为 演示的例子。
算法为一次把整个文件内容读取进内存，然后再做转换。
如果文件超大的话，会出问题。

实际处理中，可以修改为 同时 打开源文件 与 目标文件。
源文件读取一行， 目标文件写入一行。
的方式来处理！
");

            // 读取前面的 UTF-8 文件中的内容.
            string text = sample.TestRead("test_UTF8.txt", Encoding.UTF8);





            // 将前面读取到的信息，写入到 新的编码格式下.
            sample.TestWrite(
                "test_Unicode.txt",
                Encoding.Unicode,
                text);

            // 读取
            text = sample.TestRead("test_Unicode.txt", Encoding.Unicode);






            // 写入.
            sample.TestWrite(
                "test_GB2312.txt",
                Encoding.GetEncoding("GB2312"),
                text);

            // 读取
            text = sample.TestRead("test_GB2312.txt", Encoding.GetEncoding("GB2312"));





            // 在一个 方法里面作转换处理.
            // 读取一行、写入一行.
            sample.FileEncodingConvert(
                "test_UTF8.txt",
                "test_Default.txt",
                Encoding.UTF8,
                Encoding.Default);





            IdentifyEncoding test = new IdentifyEncoding();

            Console.WriteLine("test_UTF8.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("test_UTF8.txt"))
            );


            Console.WriteLine("test_Unicode.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("test_Unicode.txt"))
            );

            Console.WriteLine("test_GB2312.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("test_GB2312.txt"))
            );


            Console.WriteLine("test_Default.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("test_Default.txt"))
            );





            Console.WriteLine("text\\GB2312.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("text\\GB2312.txt"))
            );


            Console.WriteLine("text\\Unicode.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("text\\Unicode.txt"))
            );


            Console.WriteLine("text\\UTF8.txt 文件编码为：{0}",
                test.GetEncodingString(new System.IO.FileInfo("text\\UTF8.txt"))
            );

            Console.ReadLine();
        }
    }
}
