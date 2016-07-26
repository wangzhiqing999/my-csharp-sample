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




            Console.WriteLine("桌面的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Console.WriteLine("桌面的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

            Console.WriteLine("“我的音乐” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            Console.WriteLine("“我的图片” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            Console.WriteLine("“我的文档” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.WriteLine("“我的视频” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));


            Console.WriteLine("“发送” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
            Console.WriteLine("“开始” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            Console.WriteLine("“启动” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.Startup));            

            Console.WriteLine("“字体” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.Fonts));

            Console.WriteLine("“Windows” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.Windows));

            Console.WriteLine("“System” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.System));
            Console.WriteLine("“System X86” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));

            Console.WriteLine("“Program files” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            Console.WriteLine("“Program files X86” 的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));





            // 很多 所有用户 公用的， 是以 Common 开头的.
            Console.WriteLine("所有用户桌面的路径：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            Console.WriteLine("所有用户的“Documents”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
            Console.WriteLine("所有用户的“Music”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
            Console.WriteLine("所有用户的“Pictures”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
            Console.WriteLine("所有用户的“Videos”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
            Console.WriteLine("所有用户的“StartMenu”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
            Console.WriteLine("所有用户的“Programs”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms));
            Console.WriteLine("所有用户的“Startup”：" + System.Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup));


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