using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.International.Formatters;
using Microsoft.International;
using System.Globalization;
using System.Diagnostics;


namespace A0415_NumericFormatting
{

    /// <summary>
    /// 运行此项目， 需要开发计算机， 安装 Microsoft Visual Studio International Feature Pack 2.0
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("简体中文: "
                + InternationalNumericFormatter.FormatWithCulture("Ln", 456789, null, new CultureInfo("zh-CHS")));

            Console.WriteLine("繁体中文: "
                + InternationalNumericFormatter.FormatWithCulture("Lc", 456789, null, new CultureInfo("zh-CHT")));

            Console.WriteLine("日文: "
                + InternationalNumericFormatter.FormatWithCulture("L", 456789, null, new CultureInfo("ja")));

            // Console.WriteLine("韩文: " + InternationalNumericFormatter.FormatWithCulture("L", 12345, null, new CultureInfo("ko")));
            // Console.WriteLine("阿拉伯: " + InternationalNumericFormatter.FormatWithCulture("L", 12345, null, new CultureInfo("ar")));

            Console.ReadLine();
        }
    }
}
