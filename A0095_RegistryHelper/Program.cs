using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

using A0095_RegistryHelper.Sample;


namespace A0095_RegistryHelper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("判断指定注册表项是否存在！");
            Console.WriteLine(RegistryHelper.IsRegistryExist(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "IP"));
            Console.WriteLine(RegistryHelper.IsRegistryExist(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "Port"));



            Console.WriteLine("向注册表中写数据！");
            RegistryHelper.SetRegistryData(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "IP", "127.0.0.1");
            RegistryHelper.SetRegistryData(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "Port", "8080");


            // 注意：
            // 测试运行后。 
            // 数据被生成在  HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MyCsharpSample\RegistryHelper 下面。
            // 不是预期的  HKEY_LOCAL_MACHINE\SOFTWARE\MyCsharpSample\RegistryHelper 下


            Console.WriteLine("读取指定名称的注册表的值！");
            Console.WriteLine(RegistryHelper.GetRegistryData(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "IP"));
            Console.WriteLine(RegistryHelper.GetRegistryData(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "Port"));



            Console.WriteLine("删除注册表中指定的注册表项！");
            RegistryHelper.DeleteRegist(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "IP");
            RegistryHelper.DeleteRegist(Registry.LocalMachine, "SOFTWARE\\MyCsharpSample\\RegistryHelper", "Port");



            Console.WriteLine("按回车键结束！");
            Console.ReadLine();
        }
    }
}
