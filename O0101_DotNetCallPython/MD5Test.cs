using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using IronPython.Hosting;
using Microsoft.Scripting.Hosting;



namespace O0101_DotNetCallPython
{
    class MD5Test
    {

        public static void Test()
        {

            // 加载外部 python 脚本文件.
            ScriptRuntime pyRumTime = Python.CreateRuntime();
            dynamic obj = pyRumTime.UseFile("md5.py");


            Console.WriteLine("测试调用 MD5 方法！");

            Console.WriteLine(obj.md5("12345678901234567890123456789012345678901234567890"));


        }




        public static void Test2()
        {

            // 加载外部 python 脚本文件.
            ScriptEngine pyEngine = Python.CreateEngine();
            ScriptScope pyScope = pyEngine.CreateScope();
            dynamic py = pyEngine.ExecuteFile("md5.py");



            Console.WriteLine("测试调用 MD5 方法！");

            Console.WriteLine(py.md5("12345678901234567890123456789012345678901234567890"));


        }


    }
}
