using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A0104_ConvertHtmlToUTF8.Sample;


namespace A0104_ConvertHtmlToUTF8
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                // 指定了文件.
                ConvertProcesser.ConvertToUtf8(args[0]);
                return;
            }


            // 未指定文件的情况下， 当前目录下所有文件.
            string path = System.IO.Directory.GetCurrentDirectory();

            foreach (string file in Directory.GetFiles(path))
            {
                ConvertProcesser.ConvertToUtf8(file);
            }

        }
    }
}
