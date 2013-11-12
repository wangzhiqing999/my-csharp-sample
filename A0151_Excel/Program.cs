using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0151_Excel.Sample;

namespace A0151_Excel
{
    class Program
    {
        static void Main(string[] args)
        {

            string excelFileName = System.AppDomain.CurrentDomain.BaseDirectory + "Test.xls";
            CreateWriteExcel cwExcel = new CreateWriteExcel();
            cwExcel.TestWriteExcel(excelFileName);



            ReadExcel rExcel = new ReadExcel();
            // 测试读取 前面创建 的 Excel 文件.
            rExcel.TestRead(excelFileName, String.Empty, true);


            // 测试读取 标题不在 第一行的情况。
            rExcel.TestRead("Report.xls", "A4:C100", true);


            // 测试读取 没有标题 的情况。
            rExcel.TestRead("Test2.xls", String.Empty, false);



            // 注意：下面这种情况， 第一行需要是空白的
            // 测试读取 没有标题  且数据不在第一行的情况。
            rExcel.TestRead("Report2.xls", "A4:C100", true);


            Console.ReadLine();
        }
    }
}
