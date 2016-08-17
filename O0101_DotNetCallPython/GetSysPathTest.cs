using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using IronPython.Hosting;
using Microsoft.Scripting.Hosting;



namespace O0101_DotNetCallPython
{
    class GetSysPathTest
    {

        public static void Test()
        {

            // 加载外部 python 脚本文件.
            ScriptRuntime pyRumTime = Python.CreateRuntime();
            dynamic obj = pyRumTime.UseFile("get_sys_path.py");


            Console.WriteLine("测试调用 get_sys_path 方法！");

            Console.WriteLine(obj.get_sys_path());


        }




        public static void Test2()
        {

            // 加载外部 python 脚本文件.
            ScriptEngine pyEngine = Python.CreateEngine();
            ScriptScope pyScope = pyEngine.CreateScope();
            dynamic py = pyEngine.ExecuteFile("get_sys_path.py");



            Console.WriteLine("测试调用 get_sys_path 方法！");

            Console.WriteLine(py.get_sys_path());


        }


    }
}
