using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0060_Enum.Sample;

namespace A0060_Enum
{






    class Program
    {
        static void Main(string[] args)
        {

            EnumSample sample = new EnumSample();

            // 测试遍历 枚举的所有元素.
            sample.ViewAll();

            // 测试 解析字符串.
            sample.TestParse();


            // 测试通过 得到枚举的某一值对应的名称
            sample.TestGetName();

            // 测试根据枚举， 获取枚举的 Int 数值.
            sample.TestGetValue();


            //  测试 int 强制转换为 枚举.
            sample.TestIntToEnum();





            EnumSample2 sample2 = new EnumSample2();

            sample2.DoTestAll();


            Console.ReadLine();
        }
    }
}
