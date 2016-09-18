using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using A1020_i18n.Properties;

namespace A1020_i18n
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试读取资源文件信息！");


            Console.WriteLine("当前环境的区域性的信息， Resources.HelloMessage = {0}", Resources.HelloMessage);
            Console.WriteLine();


            // 用于测试 切换区域信息的处理.
            CultureInfo[] testArea = new CultureInfo[] {
                new CultureInfo("zh-CN"),
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("fr-FR"),
                new CultureInfo("ja-JP"),

                // 下面这些，是用于测试，当资源文件中没有指定语言的情况下，是否使用默认的 Resources 中的数据。
                new CultureInfo("ko-KR"),
                new CultureInfo("zh-HK"),
                new CultureInfo("es-ES"),
            };

            foreach (var area in testArea)
            {
                Resources.Culture = area;
                Console.WriteLine("区域性的信息 = {0}; Resources.HelloMessage = {1}", Resources.Culture, Resources.HelloMessage);
            }

            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
