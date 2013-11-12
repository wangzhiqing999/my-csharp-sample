using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using A0800_Excel.Sample;
using A0800_Excel.Test;

using A0801_Excel.Sample;
using A0801_Excel.Test;



namespace A0801_Excel
{
    class Program
    {
        static void Main(string[] args)
        {


            if (File.Exists("test.xls"))
            {
                File.Delete("test.xls");
            }


            // 用于测试的数据列表.
            List<TestData> testDataList = new List<TestData>();

            testDataList.Add(new TestData { UserName = "用户1", City = "上海", Zip = "200000" });
            testDataList.Add(new TestData { UserName = "用户2", City = "桂林" });
            testDataList.Add(new TestData { UserName = "用户3" });


            // 首先数据导出到 Excel。
            ExcelExportProcessPlus<TestDataPlus, TestData> exper =
                new ExcelExportProcessPlus<TestDataPlus, TestData>();
            // 设置基准对象.
            exper.BaseDefineObject = new TestDataPlus();
            // 导出.
            exper.CreateExcelReport(testDataList, "test.xls");


            Console.ReadLine();
        }
    }
}
