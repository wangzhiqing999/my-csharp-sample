using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O0301_DotNetCallJava
{


    // Install-Package IKVM -Version 7.2.4630.5  -ProjectName O0301_DotNetCallJava
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试 C# 调用 Java 代码！");


            test.TestJavaClass testJavaClass = new test.TestJavaClass();
            Console.WriteLine(testJavaClass.Hello());











            Console.WriteLine("测试 C# 与 Java， GBK 编码的差异性！");


            string sourceText = "珺";


            Console.WriteLine("使用 C#， 获取 {0} 的 GBK 编码", sourceText);
            byte[] bytes = GetGbkByteArray(sourceText);
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine(bytes[i]);
            }


            Console.WriteLine("使用 Java， 获取 {0} 的 GBK 编码", sourceText);
            bytes = testJavaClass.getGbkByteArray(sourceText);
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine(bytes[i]);
            }

            // 注意： 这里测试， C# 与 Java， 结果是一致的。
            // 但是在外部， Java.exe test.TestJavaClass 珺 的情况下。
            // 高位输出是不一致的。
            // 因为： java里一个byte取值范围是-128~127, 而C#里一个byte是0~255.
            // 首位不同. 但是底层I/O存储的数据是一样的。
            





            Console.ReadLine();
        }







        /// <summary>
        /// 取得目标字符串的 GBK 编码字节数组.
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        static byte[] GetGbkByteArray(string sourceText)
        {
            byte[] result = Encoding.GetEncoding("GBK").GetBytes(sourceText);

            return result;
        }





    }
}
