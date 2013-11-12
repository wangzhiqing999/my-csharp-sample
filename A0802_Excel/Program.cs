using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;


using A0802_Excel.Model;
using A0802_Excel.Service;
using A0802_Excel.ServiceImpl;



namespace A0802_Excel
{

    class Program
    {



        static void Main(string[] args)
        {


            if (File.Exists("test1.xls"))
            {
                File.Delete("test1.xls");
            }

            if (File.Exists("test2.xls"))
            {
                File.Delete("test2.xls");
            }


            // 用于测试的数据列表.
            List<TestData> testDataList = new List<TestData>();

            testDataList.Add(new TestData { UserName = "用户1", City = "上海", Zip = "200000" });
            testDataList.Add(new TestData { UserName = "用户2", City = "桂林" });
            testDataList.Add(new TestData { UserName = "用户3" });



            ExcelDataExportFormater<TestData> format1 = new TestDataExcelExportFormater1();

            ExcelDataExportFormater<TestData> format2 = new TestDataExcelExportFormater2();



            // 数据导出到 Excel。
            ExcelExportProcess<ExcelDataExportFormater<TestData>, TestData> exper =
                new ExcelExportProcess<ExcelDataExportFormater<TestData>, TestData>();


            // 设置 格式化.
            exper.ExcelDataExportFormater = format1;
            // 导出.
            exper.CreateExcelReport(testDataList, "test1.xls");



            Debug.WriteLine("输出到 test1.xls 完毕！");
            


            // 设置 格式化.
            exper.ExcelDataExportFormater = format2;
            // 导出.
            exper.CreateExcelReport(testDataList, "test2.xls");


            Debug.WriteLine("输出到 test2.xls 完毕！");






            ExcelDataImportFormater<TestData> iformat1 = new TestDataExcelImportFormater1();
            ExcelDataImportFormater<TestData> iformat2 = new TestDataExcelImportFormater2();

            ExcelImportProcess<ExcelDataImportFormater<TestData>, TestData> impr = 
                new ExcelImportProcess<ExcelDataImportFormater<TestData>,TestData>();


            // 从 test1.xls 读取.
            impr.ExcelDataImportFormater = iformat1;
            List<TestData> fileList1 = impr.ReadDataFromExcelReport("test1.xls");

            Console.WriteLine("从 test1.xls 读取数据！");

            foreach (TestData data in fileList1)
            {
                Console.WriteLine("UserName = {0}, City = {1}, Zip ={2}",
                    data.UserName,
                    data.City,
                    data.Zip);
            }



            // 从 test2.xls 读取.
            impr.ExcelDataImportFormater = iformat2;
            List<TestData> fileList2 = impr.ReadDataFromExcelReport("test2.xls");

            Console.WriteLine("从 test2.xls 读取数据！");

            foreach (TestData data in fileList2)
            {
                Console.WriteLine("UserName = {0}, City = {1}, Zip ={2}",
                    data.UserName,
                    data.City,
                    data.Zip);
            }



            Console.ReadLine();
        }



    }
}
