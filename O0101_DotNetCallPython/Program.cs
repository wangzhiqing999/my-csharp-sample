using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using IronPython.Hosting;
using Microsoft.Scripting.Hosting;



namespace O0101_DotNetCallPython
{
    class Program
    {

        static void Main(string[] args)
        {
            // 加载外部 python 脚本文件.
            ScriptRuntime pyRumTime = Python.CreateRuntime();
            dynamic obj = pyRumTime.UseFile("hello.py");



            // ==================================================
            // 简单调用脚本文件中的方法.
            Console.WriteLine(obj.welcome("Test C# Call Python."));
            Console.WriteLine(obj.welcome("测试中文看看是否正常！"));




            // ==================================================
            // 测试自定义对象.
            TestDataObject testObj = new TestDataObject()
            {
                UserName = "张三",
                Age = 20,
                Desc = "",
            };
            Console.WriteLine("调用脚本前对象数据：{0}", testObj);
            obj.testAddAge(testObj);
            Console.WriteLine("调用 testAddAge 脚本后，对象数据={0}", testObj);


            obj.testAddAge2(testObj);
            Console.WriteLine("调用 testAddAge2 脚本后，对象数据={0}", testObj);





            // ==================================================
            // 测试  List.
            IronPython.Runtime.List testList = new IronPython.Runtime.List();
            testList.Add("List数据1");
            testList.Add("List数据2");
            testList.Add("List数据3");

            // 测试参数为 List.
            string result = obj.testList(testList);
            Console.WriteLine("调用 testList ， 返回结果：{0}", result);




            // ==================================================
            // 测试  Set.
            IronPython.Runtime.SetCollection testSet = new IronPython.Runtime.SetCollection();
            testSet.add("Set数据1");
            testSet.add("Set数据2");
            testSet.add("Set数据3");


            // 测试参数为 Set.
            result = obj.testSet(testSet);
            Console.WriteLine("调用 testSet ， 返回结果：{0}", result);




            // ==================================================
            // 测试  Dictionary.
            IronPython.Runtime.PythonDictionary testDictionary = new IronPython.Runtime.PythonDictionary();
            testDictionary["Key1"] = "Value1";
            testDictionary["Key2"] = "Value2";
            testDictionary["Key3"] = "Value3";

            // 测试参数为 Dictionary.
            result = obj.testDictionary(testDictionary);
            Console.WriteLine("调用 testDictionary ， 返回结果：{0}", result);







            // 测试调用 MD5
            MD5Test.Test();
            MD5Test.Test2();



            // 测试调用 GetSysPath
            GetSysPathTest.Test();
            GetSysPathTest.Test2();




            UmengTest.Test();




            Console.ReadLine();




            

        }

    }
}
