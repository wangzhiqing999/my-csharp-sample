using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

using System.IO;
using System.Diagnostics;


using A0803_Excel.Model;
using A0803_Excel.Service;
using A0803_Excel.ServiceImpl;



namespace A0803_Excel
{
    class Program
    {

        static void Main(string[] args)
        {

            if (File.Exists("test1.xls"))
            {
                File.Delete("test1.xls");
            }

            // Excel 导出格式.
            ExcelDataExportFormater<TestData> format1 = new TestDataExcelExportFormater1();

            // Excel 异步导出处理
            AsynchronousExcelExportProcess<ExcelDataExportFormater<TestData>, TestData> exper =
                new AsynchronousExcelExportProcess<ExcelDataExportFormater<TestData>, TestData>();


            // 设置 格式化.
            exper.ExcelDataExportFormater = format1;

            // 设置输出文件.
            exper.OutputFileName = "test1.xls";


            // 开始异步处理.
            exper.StartAsynchronousProcess();



            // 模拟 分页数据读取.
            for (int i = 0; i < 10; i++)
            {
                // 队列加入数据.
                List<TestData> newList = GetTestData(i);
                exper.AddReportData(newList);
 
            }

            // 结束异步处理.
            exper.FinishAsynchronousProcess();



            Console.WriteLine("异步生成 Excel 处理结束，按回车键开始 异步 Excel 读取！");

            Console.ReadLine();





            ExcelDataImportFormater<TestData> iformat1 = new TestDataExcelImportFormater1();

            AsynchronousExcelImportProcess<ExcelDataImportFormater<TestData>, TestData> impor =
                new AsynchronousExcelImportProcess<ExcelDataImportFormater<TestData>, TestData>();


            // 设置 格式化.
            impor.ExcelDataImportFormater = iformat1;

            // 设置输出文件.
            impor.InputFileName = "test1.xls";

            // 设置窗口大小.
            impor.WindowsSize = 3;


            // 设置 触发事件.
            impor.DataReaderStep += new AsynchronousExcelImportProcess<ExcelDataImportFormater<TestData>, TestData>.DataReaderStepHandler(DataReaderStepHandler);
            impor.DataReaderFinish += new AsynchronousExcelImportProcess<ExcelDataImportFormater<TestData>, TestData>.DataReaderFinishHandler(DataReaderFinishHandler);


            // 开始异步处理.
            impor.StartAsynchronousProcess();


            while (true)
            {
                if (isFinish)
                {
                    break;
                }
                Thread.Sleep(500);
            }


            Console.ReadLine();
        }



        /// <summary>
        /// 事件的操作代码.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="obj"></param>
        /// <param name="cancel"></param>
        private static void DataReaderStepHandler(List<TestData> dataList)
        {
            Console.WriteLine("Excel 数据被读取出来了！");

            foreach (TestData data in dataList)
            {
                Console.WriteLine("UserName = {0}, City = {1}, Zip ={2}",
                    data.UserName,
                    data.City,
                    data.Zip);
            }
            
        }



        static bool isFinish = false;

        private static void DataReaderFinishHandler()
        {
            Console.WriteLine("Excel 数据读取完毕了！");
            isFinish = true;
        }



        private static List<TestData> GetTestData(int index)
        {
            Console.WriteLine("获取数据{0} AT {1}", index, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


            List<TestData> resultList = new List<TestData>();


            for (int i = 0; i < index; i++)
            {

                TestData result = new TestData();

                result.UserName = "User" + index;
                result.City = "City" + index;
                result.Zip = "Zip" + index;


                resultList.Add(result);
            }



            // 模拟长时间处理
            Thread.Sleep(1000);

            return resultList;
        }

    }
}
