using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0007_Reflection_ModelCopyer.Model;

namespace A0007_Reflection_ModelCopyer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试使用 反射方式， 在两个对象之间复制属性！");


            // 构造源对象.
            TestModelFrom testFrom = new TestModelFrom()
            {
                TestNormal = "正常属性",
                TestFromOnly = "源 特有属性",
                TestFromWriteOnly = "源只写属性",
                TestToReadOnly = "目标只读属性",
                TestToWriteOnly = "目标只写属性",
            };

            Console.WriteLine("源对象：{0}", testFrom);


            // 目标对象.
            TestModelTo testTo = new TestModelTo();


            Console.WriteLine("复制前 目标对象：{0}", testTo);

            CommonModelCopyer.ModelCopy(testFrom, testTo);

            Console.WriteLine("复制后 目标对象：{0}", testTo);


            Console.ReadLine();
        }
    }
}
