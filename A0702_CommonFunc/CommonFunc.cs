using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace A0702_CommonFunc
{

    /// <summary>
    /// 引用文件的测试。
    /// 有2个项目 间接引用当前文件。
    /// 
    /// 原因：
    ///   主程序会更新子程序
    ///   子程序会更新主程序
    ///   其中某些数据的下载，版本的判断，更新的逻辑，是相同的
    ///   
    /// 功能代码在主程序，子程序，各写一遍，会导致
    ///   如果发生代码逻辑的修改，需要额外在两个项目之间复制代码。
    ///   而且功能基本上大多数是相同的。
    ///   
    /// 把这个类，单独做成一个 DLL，会导致 
    ///   主程序运行的时候，引用了这个DLL，结果只能更新子程序。
    ///   子程序运行的时候，也引用了这个DLL，结果只能更新主程序。
    ///   最后这个共通的DLL，主程序子程序，谁也更新不了。
    /// 
    /// 修改引用的方式：
    ///   首先在目标项目中，新增本文件。
    ///   结果是这个文件，被复制到目标项目中。
    ///   然后，保存目标项目。
    ///   用文本编辑器，修改目标项目的 csproj 文件。
    ///   找到本文件的定义
    ///   将其由 Compile Include="CommonFunc.cs"
    ///   修改为 Compile Include="..\A0702_CommonFunc\CommonFunc.cs"
    ///   保存项目文件。
    ///   进入Visual Studio ， 提示重新加载项目。会看到本文件的图标，变成与其他项目不同的图标了。
    /// </summary>
    public class CommonFunc
    {

        /// <summary>
        /// 主程序名.
        /// </summary>
        private const string MAIN_FILE = "A0700_Main.exe";

        /// <summary>
        /// 子程序 [自动更新] 程序名.
        /// </summary>
        private const string SUB_FILE = "A0701_AutoUpdate.exe";


        /// <summary>
        /// 删除主程序.
        /// </summary>
        public void DeleteMain()
        {

            if (File.Exists(MAIN_FILE))
            {
                File.Delete(MAIN_FILE);
            }
            Console.WriteLine("主程序被成功地删除了！");
            Console.ReadLine();
        }



        /// <summary>
        /// 删除子程序 [自动更新] 程序.
        /// </summary>
        public void DeleteAutoUpdate()
        {

            if (File.Exists(SUB_FILE))
            {
                File.Delete(SUB_FILE);
            }
            Console.WriteLine("子程序被成功地删除了！");
            Console.ReadLine();
        }

    }
}
