using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;


namespace A0100_File.Sample
{
    class TestFileInfo
    {

        public static void DoTest(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            Console.WriteLine(@"{0} 
创建时间：{1}
最后更新时间：{2}
访问的时间：{3}",
                fileName,
                fi.CreationTime,
                fi.LastWriteTime,
                fi.LastAccessTime
                );
        }






    }
}
