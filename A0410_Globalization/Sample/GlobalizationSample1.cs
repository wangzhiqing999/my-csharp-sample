using System;
using System.Threading;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0410_Globalization.Sample
{

    
    class GlobalizationSample1
    {


        public void ReadAllCultureInfo()
        {
            // 获取由指定 CultureTypes 参数筛选的支持的区域性列表。
            // CultureTypes.AllCultures = .NET Framework 附带的所有区域性，包括非特定区域性和特定区域性、Windows 操作系统中安装的区域性以及用户创建的自定义区域性。
            CultureInfo[] cultureInfoList = CultureInfo.GetCultures(CultureTypes.AllCultures);


            Console.WriteLine(" .NET Framework 附带的所有区域性 如下：");
            foreach (CultureInfo cultureInfo in cultureInfoList)
            {
                Console.WriteLine(cultureInfo);
            }

        }



        /// <summary>
        /// 显示 信息.
        /// 
        /// 1.工程添加资源文件
        ///   资源文件命名方式 [资源文件主题名].[语言区域.].resx   
        ///   这里是 Resource1.en.resx 与 Resource1.zh-CN.resx
        ///   资源文件 默认为 “不复制”  “嵌入的资源”
        /// 
        ///
        /// 2.获取资源文件管理器
        ///   资源文件名的构成为 [项目命名空间].[资源文件主题名]
        ///   这里是 A0410_Globalization.Resource1
        /// 
        /// 3.获取当前进程的语言区域
        /// 
        /// 4.从资源文件中按项目名获取值
        /// 
        ///
        /// 
        /// 前台国际化环境的选择(改变当前程序进程中的区域信息的方式达到改变)
        /// Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
        /// Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
        /// Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja-JP");
        /// 
        /// </summary>
        public void ShowInfo()
        {
            // 获取资源文件管理器
            ResourceManager rm = new ResourceManager("A0410_Globalization.Resource1", Assembly.GetExecutingAssembly());

            // 获取当前进程的语言区域
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;

            // 从资源文件中按项目名获取值
            String hello = rm.GetString("Hello", ci);
            String desc = rm.GetString("Desc", ci);

            Console.WriteLine("使用 {0} 的情况下：{1}, {2}", ci, hello, desc);



            // 换一种 语言区域
            CultureInfo ciEn = new System.Globalization.CultureInfo("en-us");

            // 从资源文件中按项目名获取值
            hello = rm.GetString("Hello", ciEn);
            desc = rm.GetString("Desc", ciEn);

            Console.WriteLine("使用 {0} 的情况下：{1}, {2}", ciEn, hello, desc);
        }


    }

}

