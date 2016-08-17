using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace O0101_DotNetCallPython
{
    class UmengTest
    {

        public static void Test()
        {

            // 加载外部 python 脚本文件.
            ScriptRuntime pyRumTime = Python.CreateRuntime();
            dynamic obj = pyRumTime.UseFile("umeng.py");


            Console.WriteLine("测试调用友盟推送方法！");

            Console.WriteLine(obj.push_unicast("AppKey", "App Master Secret", ""));


        }


    }
}
