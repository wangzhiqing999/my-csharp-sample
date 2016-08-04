using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Diagnostics;

namespace B0400_7zip.Util
{
    public class Zip7
    {

        private string zipPath = @"C:\Program Files\7-zip\7z.exe";

        public string ZipPath
        {
            set
            {
                zipPath = value;
            }
            get
            {
                return zipPath;
            }
        }


        /// <summary>
        /// 压缩.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="resultFile"></param>
        public void Zip(string sourceFile, string resultFile)
        {
            Process process = new Process();

            // 7zip.exe 的目录.
            process.StartInfo.FileName = zipPath;

            // 压缩参数.
            process.StartInfo.Arguments = String.Format(@" a -r {0} {1}", resultFile, sourceFile) ;

            // 运行.
            process.Start();
        }



        /// <summary>
        /// 解压缩.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="resultPath"></param>
        public void UnZip(string sourceFile, string resultPath)
        {
            Process process = new Process();

            // 7zip.exe 的目录.
            process.StartInfo.FileName = zipPath;

            // 压缩参数.
            // -y 意味着 所有提示，都回答 yes.
            // -o 为指定目标目录.
            process.StartInfo.Arguments = String.Format(@" e {0} -y -o{1}", sourceFile, resultPath);

            // 运行.
            process.Start();
        }

    }
}
