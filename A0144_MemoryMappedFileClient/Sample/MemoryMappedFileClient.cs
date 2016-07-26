using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;


namespace A0144_MemoryMappedFileClient.Sample
{
    class MemoryMappedFileClient
    {


        // 从第 20个 字符开始.
        static long offset = 20;

        // 长度 64
        static long length = 64;



        public static void Test()
        {

            // 打开内存映射文件.
            using (var mmf = MemoryMappedFile.OpenExisting("TextA"))
            {
                using (var accessor = mmf.CreateViewAccessor(offset, length))
                {
                    for (long i = 0; i < length; i++)
                    {
                        // 数据读取.
                        byte dataChar = accessor.ReadByte(i);

                        // 输出.
                        Console.Write((char)dataChar);

                        // 数据写入.
                        accessor.Write(i, (byte)(dataChar - 1));
                    }
                }

                Console.WriteLine();
            }


            Console.WriteLine("程序修改了部分内存映射文件。");
        }

    }
}
