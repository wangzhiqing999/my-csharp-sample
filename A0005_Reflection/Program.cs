using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0005_Reflection.Sample;


namespace A0005_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            ReflectionSample sample = new ReflectionSample();

            // 测试创建实例.
            sample.TestNewClass();

            // 测试 GET/SET
            sample.TestGetSetProp();

            // 测试 调用方法.
            sample.TestCall();

            Console.ReadLine();
        }
    }
}
