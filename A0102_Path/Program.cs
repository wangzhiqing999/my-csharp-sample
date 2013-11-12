using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


namespace A0102_Path
{
    class Program
    {




        /// <summary>
        /// 本例子用于 演示 获取程序 当前路径的例子.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.WriteLine("System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName");
            Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Console.WriteLine();


  




            Console.WriteLine("System.Environment.CurrentDirectory");
            Console.WriteLine(System.Environment.CurrentDirectory);
            Console.WriteLine();


            Console.WriteLine("System.IO.Directory.GetCurrentDirectory()");
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Console.WriteLine();


            Console.WriteLine("System.AppDomain.CurrentDomain.BaseDirectory");
            Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine();

            Console.WriteLine("System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase");
            Console.WriteLine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            Console.WriteLine();



            string path = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo parentPath1 = Directory.GetParent(path);
            DirectoryInfo parentPath2 = Directory.GetParent(parentPath1.FullName);
            DirectoryInfo parentPath3 = Directory.GetParent(parentPath2.FullName);

            Console.WriteLine("当前路径: {0}", path);
            Console.WriteLine("当前路径上1级: {0}", parentPath1.FullName);
            Console.WriteLine("当前路径上2级: {0}", parentPath2.FullName);
            Console.WriteLine("当前路径上3级: {0}", parentPath3.FullName);



            Console.ReadLine();
        }


    }
}


/* 运行结果演示.

 
C:\Users\wangzhiqing>D:\MyTools\my-csharp-sample\A0102_Path\bin\Debug\A0102_Path.exe

System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
D:\MyTools\my-csharp-sample\A0102_Path\bin\Debug\A0102_Path.exe

System.Environment.CurrentDirectory
C:\Users\wangzhiqing

System.IO.Directory.GetCurrentDirectory()
C:\Users\wangzhiqing

System.AppDomain.CurrentDomain.BaseDirectory
D:\MyTools\my-csharp-sample\A0102_Path\bin\Debug\

System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
D:\MyTools\my-csharp-sample\A0102_Path\bin\Debug\


*/