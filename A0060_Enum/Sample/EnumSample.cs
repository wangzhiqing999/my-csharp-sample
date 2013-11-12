using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0060_Enum.Sample
{

    /// <summary>
    /// 枚举例子1.
    /// 
    /// 注意： 枚举的 数值，默认从0开始，逐步递增。
    /// 因此，假如要自行设定枚举的数值，需要 全部都指定好。
    /// 或者注意避免使用前面使用到的数据
    /// 
    /// 下面的例子
    /// Red 没有指定值，那么默认是从 0 开始了
    /// 后面又有一个 White = 0
    /// 
    /// </summary>
    public enum EnumSample1
    {
        Red,
        Yellow,
        Green,
        White = 0,
        Blcak = 255,
        Unknow = -1
    }


    class EnumSample
    {

        /// <summary>
        /// 用于查看 枚举中，所有的 名称与 对应的数值.
        /// </summary>
        public void ViewAll()
        {

            String[] names = Enum.GetNames(typeof(EnumSample1));
            int[] values = (int[])Enum.GetValues(typeof(EnumSample1));

            Console.WriteLine("遍历枚举的名称：");
            foreach (String name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("遍历枚举的数值：");
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }


        /// <summary>
        /// 测试：通过 字符串，解析为枚举类型.
        /// </summary>
        public void TestParse()
        {
            // 解析 字符创串 red ， 忽略大小写
            EnumSample1 data = (EnumSample1) Enum.Parse(typeof(EnumSample1), "red", true);
            Console.WriteLine("解析 red 的结果为：{0}", data);

            // 解析一个  枚举中没有的字符串 将导致异常.
            try
            {
                data = (EnumSample1)Enum.Parse(typeof(EnumSample1), "blue", true);
                Console.WriteLine("解析 blue 的结果为：{0}", data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }


        /// <summary>
        /// 测试：得到枚举的某一值对应的名称
        /// </summary>
        public void TestGetName()
        {
            Console.WriteLine("测试：得到枚举的某一值对应的名称");
            String name = Enum.GetName(typeof(EnumSample1), -1);
            Console.WriteLine("{0}对应的名称为{1}", -1, name);

            
            Console.WriteLine("测试：得到枚举的某一值对应的名称[当该数值是重复的时候]");
            name = Enum.GetName(typeof(EnumSample1), 0);
            Console.WriteLine("{0}对应的名称为{1}", 0, name);

            Console.WriteLine("测试：当指定的值，枚举中没有时：");
            name = Enum.GetName(typeof(EnumSample1), -100);
            Console.WriteLine("{0}对应的名称为{1}", -100, name);



        }



        /// <summary>
        /// 测试： 根据枚举， 获取枚举的 Int 数值.
        /// </summary>
        public void TestGetValue()
        {
            EnumSample1 data = EnumSample1.Blcak;
            Console.WriteLine("枚举{0} 对应的 int 数值为 {1}", data,  Convert.ToInt32(data));
        }


        /// <summary>
        /// 测试 int 强制转换为 枚举.
        /// </summary>
        public void TestIntToEnum()
        {
            int iVal = 255;
            EnumSample1 data = (EnumSample1)iVal;

            Console.WriteLine("强制转换 {0} 的结果为：{1}", iVal, data);
        }

    }
}
