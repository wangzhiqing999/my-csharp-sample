using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0090_Resource.Sample;

namespace A0090_Resource
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceSample sample = new ResourceSample();


            Console.WriteLine("读写资源文件的例子！");

            // 写入资源文件.
            sample.WriteChinaResource();
            sample.WriteEnglishResource();

            // 读取资源文件.
            sample.DisplayHello("China");
            sample.DisplayHello("English");


            Console.ReadLine();
        }
    }
}
