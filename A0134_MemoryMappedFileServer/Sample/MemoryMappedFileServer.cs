using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;



namespace A0134_MemoryMappedFileServer.Sample
{


    /// <summary>
    /// 
    /// 参考页面.
    /// 
    /// https://msdn.microsoft.com/zh-cn/library/dd997372(v=vs.100).aspx
    /// 
    /// 
    /// 本例子为 持久内存映射文件
    /// 
    /// 如果要用 非持久内存映射文件， 参考网页后面的例子.
    /// </summary>
    class MemoryMappedFileServer
    {

        // 从第 10个 字符开始.
        static long offset = 10;

        // 长度 64
        static long length = 64;


        public static void Test()
        {

            // 创建内存映射文件.
            using (var mmf = MemoryMappedFile.CreateFromFile(@"TestMemoryMappedFile.txt", FileMode.Open, "TextA"))
            {

                // 读取内存映射文件的一个片断.
                using (var accessor = mmf.CreateViewAccessor(offset, length))
                {                   
                    for (long i = 0; i < length; i ++)
                    {
                        // 数据读取.
                        byte dataChar = accessor.ReadByte(i);

                        // 输出.
                        Console.Write((char)dataChar);

                        // 数据写入.
                        accessor.Write(i, (byte)(dataChar + 1));
                    }
                }



                Console.WriteLine();
                Console.WriteLine("按回车键关闭内存映射文件.");
                Console.ReadLine();
            }            
        }


    }
}
